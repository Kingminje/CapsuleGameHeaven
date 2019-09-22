using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerDetection : MonoBehaviour
    {
        public Rigidbody rc;
        public GameObject mangerGameObject;
        private static GameManager _gameManger;

        private void Awake()
        {
            Setting();
        }
        private void Setting()
        {
            rc = gameObject.GetComponent<Rigidbody>();
            rc.useGravity = false;
            mangerGameObject = GameObject.Find("GameManager");
            _gameManger = mangerGameObject.GetComponent<GameManager>();
        }
        
        public static void PlayerDie()
        {
            GameObject other = GameObject.Find("Player");

            PlayerPrefs.SetInt("ROPEGAMESCORE", int.Parse(_gameManger.combo.bestScore));
            PlayerPrefs.Save();
            MainUIManager.GetInstance().ShowRestartPanel();
            Leaderboard.stageNum = 4;
            Leaderboard.AddScore(PlayerPrefs.GetInt("ROPEGAMESCORE"), 4);

            Destroy(other.gameObject);
        }
    }
}