using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class GameManager : MonoBehaviour
    {
        public static bool isPlayerDead = false;

        public static bool isNpcDead = false;

        private static GameManager instance = null;

        private int jumpScore = 10;

        [HideInInspector]
        public Combo combo;

        private JumpRopeMove jrm;

        //   private GameObject player;

        private void Awake()
        {
            instance = this;
        }

        public static GameManager GetInstance()
        {
            return instance;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1f);
            GetUIManager();

            combo = GetComponent<Combo>();
            combo.ResetScore();
            combo.bestScore = PlayerPrefs.GetInt("JUMPROPEBESTSCORE").ToString();
            combo.FindScoreText();
            combo.bestScoreText.text = combo.bestScore;
            //  SettingPlayer();
        }

        //private void SetPlayerRigidBody()
        //{
        //    Rigidbody rid = player.GetComponent<Rigidbody>();
        //    rid.useGravity = true;
        //    rid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
        //        RigidbodyConstraints.FreezeRotation;
        //}

        public void GameOver()
        {
            PlayerPrefs.SetInt("JUMPROPEBESTSCORE", int.Parse(combo.bestScore));

            PlayerPrefs.Save();

            Leaderboard.stageNum = 6;
            Leaderboard.AddScore(PlayerPrefs.GetInt("JUMPROPEBESTSCORE"), 6);
        }

        public void CheckScore()
        {
            Debug.Log("CheckScore");

            combo.ScoreUp(jumpScore);
        }

        public void RestartGame()
        {
            StartCoroutine(RestartCoroutine());
        }

        private IEnumerator RestartCoroutine()
        {
            jrm.InitGame();

            yield return new WaitForSeconds(0.1f);

            isPlayerDead = false;
            MainUIManager.GetInstance().ShowRestartPanel();
            GameManager.GetInstance().GameOver();
            combo.ResetScore();
            //    combo.ScoreReset();
        }

        private void GetUIManager()
        {
            if (jrm == null)
            {
                jrm = GameObject.Find("PlayerJumpRope").GetComponent<JumpRopeMove>();
            }
        }
    }
}