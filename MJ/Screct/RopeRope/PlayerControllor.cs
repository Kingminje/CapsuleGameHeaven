using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MJ
{
    public class PlayerControllor : MonoBehaviour
    {
        public Rigidbody rc;
        public Vector3 JumpPoint;
        public float jumpSpeed = 6f;
        public Image gauge;
        private bool isDown;
        public GameManager gameManager;
        private SoundManager soundManager;

        public float m_time = 0.0f;

        private void Start()
        {
            gauge.fillAmount = 0f;
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            rc = gameObject.GetComponent<Rigidbody>();
            soundManager = FindObjectOfType<SoundManager>();
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject())
#else
            if (Input.touchCount > 0 &&!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))

#endif
            {
                //test();
                InputJump();
            }
        }

        private void InputJump()
        {
            //var jumpPointY = rc.position;
            if (Input.anyKey && CheckGround())
            {
                //isDown = true;
                // rigbady의 혹시 모를 힘을 죽인다.
                rc.velocity = Vector3.zero;
                rc.angularVelocity = Vector3.zero;
                rc.Sleep();
                
                JumpPoint = rc.velocity + Vector3.up * 7f;
                rc.velocity = JumpPoint;

                //gauge.fillAmount = 0f;
                soundManager.SoundPlay((int)AudioClipName.Jump);
                //StartCoroutine(GuageProgressDown());
            }
            //else if (Input.GetMouseButtonUp(0) && CheckGround())
            //{
            //    //isDown = false;
            //    //if (gauge.fillAmount > 0.5f)
            //    //    jumpSpeed = 7f;
            //    //else
            //    //    jumpSpeed = 6f;
            //}
        }

        //private IEnumerator GuageProgressDown()
        //{
        //    while (isDown)
        //    {
        //        float value = 0.02f;
        //        gauge.fillAmount += value;
        //        yield return new WaitForSeconds(0.01f);
        //    }
        //}

        public bool CheckGround()
        {
            if (rc.position.y <= 1.3f)
            {
                return true;
            }
            return false;
        }
    }
}