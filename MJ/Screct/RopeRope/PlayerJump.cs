using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MJ
{
    public class PlayerJump : MonoBehaviour
    {
        public Jump jump = null;

        private bool playerDie = false;
        
        private GameManager gameManager;

        private float time;
        private float clickDelay = 1f;

        public Text heightScore;
        public ToplineCheck tlc;

        public Rigidbody rc;

        public SoundManager soundManager;

        public LineControll lineControll;

        public bool onPlayerdetect = false;
        private Rigidbody playerRigidbody;
        
        private void Awake()
        {
            jump = transform.GetComponent<Jump>();
            gameManager = FindObjectOfType<GameManager>();
            //GameIconManger = FindObjectOfType<GameIconManger>();
            soundManager = FindObjectOfType<SoundManager>();
            lineControll = FindObjectOfType<LineControll>();
            rc = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            playerDie = false;
            playerRigidbody = transform.GetComponent<Rigidbody>();
            Invoke("PlayerDlyRotate", 0.1f);
        }

        private void ResetScore()
        {
            heightScore.text = "0";
        }

        private void PlayerDlyRotate()
        {
            CreatePlayer.player.transform.localRotation = Quaternion.Euler(0, 180f, 0);
        }

        
        
        private void FixedUpdate()
        {
            time += Time.deltaTime;
#if UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject()
#else
            if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)
#endif
                && Input.anyKey && TimeDelayCheck() && onPlayerdetect)
            {
                
                CheckPlayerJumping();
            }
            
            if (rc.position.y <= 1f || Jump.jumping == false)
            {
                heightScore.text = "0";
            }
            else
            {
                heightScore.text = ((int)(transform.position.y * 10)).ToString();
            }

            DieCheck();
        }

        public void CheckPlayerJumping()
        {
                lineControll.springJoint.spring = 15f;
                Jump.jumping = false;
                jump.JumpStart();
                soundManager.SoundPlay((int)AudioClipName.Jump);
                //gameManager.ScoreUpdate(((int)(tlc.transform.position.y * 10)));
                //GameIconManger.UpShow();

                lineControll.LineSpringForce(tlc.topTr);
        }

        private bool TimeDelayCheck()
        {
            if (time > clickDelay)
            {
                time = 0f;
                return true;
            }
            time = 0f;
            return false;
        }
        
        private void DieCheck()
        {
            if (transform.position.y <= -4f && playerDie == false)
            {
                playerDie = true;
                //gameManager.ResetGame();
                MainUIManager.GetInstance().ShowRestartPanel();
                Leaderboard.stageNum = 5;
                Leaderboard.AddScore(PlayerPrefs.GetInt("JUMPGAMESCORE"), 5);

                playerRigidbody.useGravity = false;
            }
        }

        private void OnTriggerEnter(Collider other) // 타이밍에 맞게 클릭하는거 체크
        {
            onPlayerdetect = other.CompareTag("Rope");
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Rope"))
            {
                Jump.jumping = true;
                onPlayerdetect = false;
            }
        }
    }
}