using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MJ
{
    public class GameManager : MonoBehaviour
    {
        public Combo combo = null;
        public int score = 10;
        public static int totalScore;
        private static string pass; // 플레이 프립스에 사용하는 키값을 저장

        private void Start()
        {
            pass = null;
            ComboSetting();
            ResetGame();
        }

        private void ComboSetting()
        {
            combo = GetComponent<Combo>();

            combo.FindScoreText();

            if (SceneManager.GetActiveScene().name == "RopeRope")
            {
                pass = "ROPEGAMESCORE";
                if (PlayerPrefs.HasKey("ROPEGAMESCORE"))
                {
                    combo.bestScore = PlayerPrefs.GetInt("ROPEGAMESCORE").ToString();
                }
                else
                {
                    combo.bestScore = PlayerPrefs.GetInt("ROPEGAMESCORE").ToString();
                }
            }
            else if (SceneManager.GetActiveScene().name == "PunchePunche")
            {
                pass = "PUNCHGAMESCORE";
                if (PlayerPrefs.HasKey("PUNCHGAMESCORE"))
                {
                    combo.bestScore = PlayerPrefs.GetInt("PUNCHGAMESCORE").ToString();
                }
                else
                {
                    combo.bestScore = PlayerPrefs.GetInt("PUNCHGAMESCORE").ToString();
                }
            }
            else if (SceneManager.GetActiveScene().name == "JumpJump")
            {
                pass = "JUMPGAMESCORE";
                if (PlayerPrefs.HasKey("JUMPGAMESCORE"))
                {
                    combo.bestScore = PlayerPrefs.GetInt("JUMPGAMESCORE").ToString();
                }
                else
                {
                    combo.bestScore = PlayerPrefs.GetInt("JUMPGAMESCORE").ToString();
                }
            }

            Debug.Log(combo.bestScoreText);

            combo.bestScoreText.text = combo.bestScore;
        }

        public void ScoreUp()
        {
            //Debug.Log("score Up");
            combo.ScoreUp(score);
            if (int.Parse(combo.bestScore) == Combo.score)
            {
                PlayerPrefs.SetInt(pass, int.Parse(combo.bestScore));

                PlayerPrefs.Save();
            }
        }

        public void ScoreUpdate(int score)
        {
            //Debug.Log("score Up");
            combo.ScoreUpdate(score);
            if (int.Parse(combo.bestScore) == Combo.score)
            {
                PlayerPrefs.SetInt(pass, int.Parse(combo.bestScore));

                PlayerPrefs.Save();
            }
        }

        public void ResetGame()
        {
            combo.ResetScore();
        }

        //private void SettingPlayer()
        //{
        //    player = CreatePlayer.player;
        //    player.transform.position = Vector3.zero;
        //    if (Application.loadedLevelName == "rope")
        //    {
        //        player.AddComponent<PlayerControllor>();
        //        player.transform.position = new Vector3(0f, 3f, 0f);
        //        Debug.Log("된다");
        //    }
        //    else if (Application.loadedLevelName == "punche")
        //    {
        //        Debug.Log("된다2");
        //        player.AddComponent<PlayerMove>();
        //        player.transform.position = new Vector3(0f, 1.3f, 0f);
        //        player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        //        punchPrefab.transform.parent = player.transform;
        //        //player.transform.Find("puche").transform.position = new Vector3(0f, 1.3f, 2.5f);
        //    }
        //    else
        //    {
        //    }
        //    player.AddComponent<Rigidbody>();
        //    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
        //    player.GetComponent<Collider>().isTrigger = false;
        //}

        //public void RestartButtenClick()
        //{
        //    if (Application.loadedLevelName == "rope")
        //    {
        //        SceneManager.LoadScene("rope");
        //    }
        //    else
        //    {
        //        SceneManager.LoadScene("punche");
        //    }
        //}

        public void ReturnButtenClick()
        {
            SceneManager.LoadScene("MinigameMain");
        }
    }
}

//    // 플레이어 컨트롤
//    public GameManager playerControllor;

//    public GameObject[] players;

//    public string selectedPlayers;

//    public Vector3 PlayerPos;

//    private void Awake()
//    {
//        PlayerPos = new Vector3(0f, 1.2f, 0f);
//        Debug.Log(selectedPlayers);
//    }

//    void Start()
//    {
//        selectedPlayers = PlayerPrefs.GetString("Player");

//        if (CheckPlayer())
//        {
//            switch (selectedPlayers)
//            {
//                case "Player01":
//                    Instantiate(players[0], PlayerPos, Quaternion.identity);
//                    break;

//                case "Player02":
//                    Instantiate(players[1], PlayerPos, Quaternion.identity);
//                    break;

//                case "Player03":
//                    Instantiate(players[2], PlayerPos, Quaternion.identity);
//                    break;

//                default:
//                    break;
//            }
//        }
//    }

//    private void Update()
//    {
//    }

//    public bool CheckPlayer()
//    {
//        if (selectedPlayers != null)
//        {
//            return true;
//        }
//        return false;
//    }
//}