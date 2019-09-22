using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lbj;

public class GameOver : MonoBehaviour
{
    private Combo combo;

    private void Start()
    {
        combo = FindObjectOfType<Combo>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RollRaod.n = 0f;
            Manager.gameOver = true;
            Manager.isCtrl = true;

            // 추가
            MainUIManager.GetInstance().ShowRestartPanel();
            //Leaderboard.AddScore(ScoreBook.AddScores());

            PlayerPrefs.SetInt("RUNBESTSCORE", int.Parse(combo.bestScore));
            PlayerPrefs.Save();

            Leaderboard.stageNum = 9;
            Leaderboard.AddScore(PlayerPrefs.GetInt("RUNBESTSCORE"), 9);
        }
    }
}