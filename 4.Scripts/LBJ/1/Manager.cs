using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace lbj
{
    public class Manager : MonoBehaviour
    {
        static public bool gameOver = false;
        static public bool isCtrl = false;

        private GameObject capsulelayer;
        public GameObject panel;

        private Vector3 moveVector;

        public Vector3[] movePos;

        private Combo combo;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1f);

            //SettingPlayer();
            capsulelayer = GameObject.FindWithTag("Player");
            capsulelayer.GetComponent<Transform>();

            movePos = new Vector3[2];
            movePos[0] = capsulelayer.transform.position;
            movePos[1] = capsulelayer.transform.position - new Vector3(2f, 0f, 0f);

            panel.GetComponent<GameObject>();

            // 추가
            combo = FindObjectOfType<Combo>();
            combo.ResetScore();

            combo.bestScore = PlayerPrefs.GetInt("RUNBESTSCORE").ToString();
            combo.bestScoreText.text = combo.bestScore;
        }

        //private void SettingPlayer()
        //{
        //    capsulelayer = CreatePlayer.player;
        //    capsulelayer.transform.position = new Vector3(1f, 3f, -4f);
        //    capsulelayer.transform.rotation = Quaternion.Euler(-45, 0, 0);
        //    capsulelayer.AddComponent<Rigidbody>().useGravity = false;
        //}

        private void Update()
        {
            PlayerMove();

            if (gameOver == true)
            {
                //panel.SetActive(true);
                // 메인 UI사용으로 더이상 사용 안합니다. 19 09 11
            }
        }

        public void PlayerMove()
        {
            if (Input.anyKeyDown && isCtrl == false &&
#if UNITY_EDITOR
                !EventSystem.current.IsPointerOverGameObject())
#else
                 !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
            {
                if (capsulelayer.transform.position == movePos[0])
                {
                    Debug.Log("하나");
                    moveVector = movePos[1];
                    capsulelayer.transform.DOMove(moveVector, 0.5f);
                    
                }
                else if (capsulelayer.transform.position == movePos[1])
                {
                    Debug.Log("둘");
                    moveVector = movePos[0];
                    capsulelayer.transform.DOMove(moveVector, 0.5f);
                }
            }
        }

        public void RestartScene()
        {
            ResetGame();

            SceneManager.LoadScene("DodgeRun");
        }

        public void BackToTitle()
        {
            ResetGame();

            SceneManager.LoadScene("MinigameMain");
        }

        public void ResetGame()
        {
            panel.SetActive(false);
            RollRaod.n = 1f;
            gameOver = false;
            isCtrl = false;
        }
    }
}