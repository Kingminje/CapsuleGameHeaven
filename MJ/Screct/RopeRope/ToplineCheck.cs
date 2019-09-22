using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MJ
{
    public class ToplineCheck : MonoBehaviour
    {
        public GameObject player;

        private Transform _topTr;

        private float regenValue, top;

        private MeshRenderer mr;

        private GameManager gameManager;

        private bool isplayerNotNull;

        public Transform topTr
        {
            get { return this._topTr; }
            set { _topTr = value; }
        }

        private void Start()
        {
            GameStartTopLine();
        }

        private void GameStartTopLine() // 게임 시작시 작동하는 메소드
        {
            isplayerNotNull = player != null;
            mr.enabled = false;
            
        }
        
        private void Awake()
        {
            topTr = transform;
            mr = transform.GetComponent<MeshRenderer>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (isplayerNotNull)
                {
                    if (!(transform.position.y < player.transform.position.y) || Jump.jumping != true) return;
                
                    var tmpPosition = player.transform.position;
                    topTr.position = tmpPosition;
                    regenValue = transform.position.y - tmpPosition.y;
                }
            }
            catch (Exception e)
            {
                isplayerNotNull = false;
                Console.WriteLine(e);
                throw;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                mr.enabled = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.CompareTag("Player") && Jump.jumping == true)
            {
                mr.enabled = true;
                gameManager.ScoreUpdate(((int)(transform.position.y * 10)));
                //GameIconManger.DownShow();
            }
        }
    }
}