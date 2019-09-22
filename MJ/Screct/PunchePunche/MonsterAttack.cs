using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private GameObject player = null;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Punche")
        {
            return;
        }
        else if (other.name == "Player")
        {
            Leaderboard.stageNum = 3;
            Leaderboard.AddScore(PlayerPrefs.GetInt("PUNCHGAMESCORE"), 3);
            MainUIManager.GetInstance().ShowRestartPanel();
        }
    }
}