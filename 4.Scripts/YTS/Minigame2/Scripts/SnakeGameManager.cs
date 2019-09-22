using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeGameManager : MonoBehaviour
{
    private static SnakeGameManager instance = null;
    private GameObject player;
    public GameObject[] tailPrefab;
    private SnakeMovement sm;

    private Combo combo;

    private void Awake()
    {
        instance = this;
    }

    public static SnakeGameManager GetInstance()
    {
        return instance;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        //SettingPlayer();
        sm = FindObjectOfType<SnakeMovement>();
        combo = FindObjectOfType<Combo>();
        combo.ResetScore();

        combo.bestScore = PlayerPrefs.GetInt("SNAKEBESTSCORE").ToString();
        combo.bestScoreText.text = combo.bestScore;
    }

    public void AddTail()
    {
        Vector3 newTailPos = sm.tailObjects[sm.tailObjects.Count - 1].transform.position;
        newTailPos.z -= sm.z_offset;

        switch (sm.itemNum)
        {
            case 2:
                sm.tailObjects.Add(GameObject.Instantiate(tailPrefab[0], newTailPos, Quaternion.identity) as GameObject);
                break;

            case 3:
                sm.tailObjects.Add(GameObject.Instantiate(tailPrefab[1], newTailPos, Quaternion.identity) as GameObject);
                break;

            case 4:
                sm.tailObjects.Add(GameObject.Instantiate(tailPrefab[2], newTailPos, Quaternion.identity) as GameObject);
                break;

            case 5:
                sm.tailObjects.Add(GameObject.Instantiate(tailPrefab[3], newTailPos, Quaternion.identity) as GameObject);
                break;

            case 6:
                sm.tailObjects.Add(GameObject.Instantiate(tailPrefab[4], newTailPos, Quaternion.identity) as GameObject);
                break;

            case 7:
                sm.tailObjects.Add(GameObject.Instantiate(tailPrefab[5], newTailPos, Quaternion.identity) as GameObject);
                break;
        }
    }

    public void GameOver()
    {
        MainUIManager.GetInstance().ShowRestartPanel();

        //PlayerPrefs.SetString("SNAKESCORE", combo.scoreText.text);
        PlayerPrefs.SetInt("SNAKEBESTSCORE", int.Parse(combo.bestScore));
        PlayerPrefs.Save();

        Leaderboard.stageNum = 1;
        Leaderboard.AddScore(PlayerPrefs.GetInt("SNAKEBESTSCORE"), 1);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}