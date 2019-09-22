using Firebase.Database;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public Animator listPanel;
    public string[] scoreList = new string[11];

    private const int MaxScores = 10;
    public static int stageNum;
    private static string userID;
    private static bool test = false;

    public static string UserID
    {
        get
        {
            if (string.IsNullOrEmpty(userID))
            {
                if (PlayerPrefs.HasKey("GUID"))
                    //userID = "Player#" + UnityEngine.Random.Range(1000, 9999);
                    userID = PlayerPrefs.GetString("GUID");
                else
                {
                    userID = "Player#" + UnityEngine.Random.Range(1000, 9999);
                    //userID = Guid.NewGuid().ToString();
                    PlayerPrefs.SetString("GUID", userID);
                    PlayerPrefs.Save();
                }
            }

            return userID;
        }
        set
        {
            userID = "Player#" + UnityEngine.Random.Range(1000, 9999);
            //userID = value;
        }
    }

    public static string[] ScoreCollectionName = { "EVADEBESTSCORE", "SNAKEBESTSCORE", "ARROWBESTSCORE", "PUNCHGAMESCORE", "ROPEGAMESCORE",
        "JUMPGAMESCORE", "JUMPROPEBESTSCORE", "BOXGAMEBESTSCORE", "COLORGAMEBESTSCORE", "RUNBESTSCORE", "CATCHBESTSCORE" };

    public static DatabaseReference[] ScoresReference = new DatabaseReference[ScoreCollectionName.Length];

    private void Start()
    {
        for (int i = 0; i < ScoreCollectionName.Length; i++)
        {
            ScoresReference[i] = FirebaseDatabase.DefaultInstance.GetReference(ScoreCollectionName[i]);
            //Toggle(false);
            SnapScrolling.myScoreText = new string[ScoreCollectionName.Length];
            GetScores(i);
        }
        //test = false;
    }

    //public void Toggle(bool isOn)
    //{
    //    if (isOn)
    //        GetScores();
    //    else
    //        Off();
    //}

    private void On()
    {
        if (!listPanel.GetCurrentAnimatorStateInfo(0).IsName("Show"))
            listPanel.SetTrigger("Show");
    }

    private void Off()
    {
        if (!listPanel.GetCurrentAnimatorStateInfo(0).IsName("Hide"))
            listPanel.SetTrigger("Hide");
    }

    public static void AddScore(long score, int num)
    {
        ScoresReference[num].GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted && task.IsCanceled)
            {
            }
            else if (task.IsCompleted)
            {
                //OnCompleted?.Invoke(task.Result);
                DataSnapshot snapshot = task.Result;

                // DataSnapshot 타입에 저장된 값 불러오기
                foreach (var item in snapshot.Children)
                {
                    if (item.Child("uid").Value.ToString() == UserID)
                    {
                        item.Child("score").Reference.SetValueAsync(0);
                        item.Child("uid").Reference.SetValueAsync("");
                    }
                }
            }
            AddScoreToLeaders(UserID, DateTime.Now.ToString("yy/MM/dd hh:mm:ss"), score, num);
        });
    }

    //public static void GetScores(int num)
    //{
    //    GetScores(
    //        () =>
    //        {
    //            Debug.Log("Faulted");
    //            //Off();
    //        },
    //        (snapshot) =>
    //        {
    //            Debug.Log("Completed");

    //            var scores = snapshot.Value as List<object>;
    //            var scoreList = new List<ScoreEntry>();

    //            foreach (var s in scores)
    //                scoreList.Add(new ScoreEntry(s as Dictionary<string, object>));

    //            for (int i = 0; i < scoreList.Count; ++i)
    //                textList[i].text = scoreList[i].ToString();

    //            //On();
    //        });
    //}

    public void GetScores(int i)
    {
        Debug.Log(ScoresReference[i].ToString());
        ScoresReference[i].GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted && task.IsCanceled)
            {
            }
            else if (task.IsCompleted)
            {
                //OnCompleted?.Invoke(task.Result);
                DataSnapshot snapshot = task.Result;
                // DataSnapshot 타입에 저장된 값 불러오기
                foreach (var item in snapshot.Children)
                {
                    var rankNum = int.Parse(item.Key) + 1;
                    var rankingText = (rankNum.ToString() + ". " + item.Child("uid").Value.ToString() + " : " + item.Child("score").Value.ToString() + "\n");
                    var scoreText = item.Child("uid").Value.ToString() + "\n" + item.Child("score").Value.ToString() + "점\n" + rankNum.ToString() + "위";
                    if (item.Child("uid").Value.ToString() == UserID)
                        SnapScrolling.myScoreText[i] = scoreText;
                    scoreList[i] += rankingText;
                }
            }
        });
    }

    private static void WriteNewScore(string userId, string timestamp, long score, int rank)
    {
        // 엔트리 하나 추가
        var key = ScoresReference[stageNum].Push().GetValueAsync().Id;

        // 추가한 엔트리의 데이터를 수정할 것을 조립
        var entry = new ScoreEntry(userId, timestamp, score);
        var entryValues = entry.ToDictionary();
        var childUpdates = new Dictionary<string, object>();
        childUpdates["/" + rank + "/"] = null;

        // 실제 디비에 데이터 업데이트 요청
        ScoresReference[stageNum].UpdateChildrenAsync(childUpdates);
    }

    private static void AddScoreToLeaders(string uid, string timestamp, long score, int num)
    {
        ScoresReference[num].RunTransaction(mutableData =>
        {
            var leaders = mutableData.Value as List<object>;

            if (leaders == null)
            {
                leaders = new List<object>();
            }
            else if (mutableData.ChildrenCount >= MaxScores)
            {
                var minScore = long.MaxValue;
                object minVal = null;
                foreach (var child in leaders)
                {
                    var childDic = child as Dictionary<string, object>;
                    if (childDic == null)
                        continue;

                    var scoreEntry = new ScoreEntry(childDic);
                    if (scoreEntry == null)
                        continue;

                    if (scoreEntry.score < minScore)
                    {
                        minScore = scoreEntry.score;
                        minVal = child;
                    }
                }
                if (minScore > score)
                {
                    return TransactionResult.Abort();
                }

                leaders.Remove(minVal);
            }

            object val = null;
            foreach (var child in leaders)
            {
                var childDic = child as Dictionary<string, object>;
                if (childDic == null)
                    continue;

                var scoreEntry = new ScoreEntry(childDic);
                if (scoreEntry == null)
                    continue;

                if (scoreEntry.uid == "")
                {
                    val = child;
                }
            }
            leaders.Remove(val);

            var newEntry = new ScoreEntry(uid, timestamp, score);
            leaders.Add(newEntry.ToDictionary());
            leaders.Sort((a, b) =>
            {
                var scoreA = new ScoreEntry(a as Dictionary<string, object>).score;
                var scoreB = new ScoreEntry(b as Dictionary<string, object>).score;

                if (scoreA == scoreB)
                    return 0;
                else if (scoreA > scoreB)
                    return -1;
                else
                    return 1;
            });

            mutableData.Value = leaders;
            return TransactionResult.Success(mutableData);
        });
    }
}