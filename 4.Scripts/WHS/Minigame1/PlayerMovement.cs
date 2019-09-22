using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace whs
{
    public class PlayerMovement : MonoBehaviour
    {
        public float jumpDealay = 0.7f;
        public static float currentTime = 0;
        private float lastClickTime = 0;

        public static float clickTime = 0f;
        private Rigidbody rd;
        private float force = 300f;
        private float cliTime = 0;

        protected float prevClick = 0f;
        protected float landTime = 0;

        public AudioClip jumpClick;
        public CharacterSound sound;

        //public Image gauge;
        private bool isDown;

        private void Awake()
        {
            rd = GetComponent<Rigidbody>();
            //gauge.fillAmount = 0f;
        }

        private void Update()
        {
            currentTime = Time.time;
            clickTime += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && !GameManager.isPlayerDead &&
#if UNITY_EDITOR
                !EventSystem.current.IsPointerOverGameObject())
#else
                !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
            {
                //델리게이트 여쭤보기
                if (currentTime > lastClickTime + jumpDealay)
                {
                    sound.PlaySound(jumpClick);
                    cliTime = currentTime;
                    //     Debug.Log("Speed   : " + "   Click  calcu : " + (currentTime - landTime));
                    prevClick = cliTime;
                    lastClickTime = currentTime;
                    
                    // rigbady의 혹시 모를 힘을 죽인다.
                    rd.velocity = Vector3.zero;
                    rd.angularVelocity = Vector3.zero;
                    rd.Sleep();
                    rd.AddForce(Vector3.up * force);
                    clickTime = 0f;
                }
                //isDown = true;
                //StartCoroutine(GuageProgressDown());
            }
            else if (Input.GetMouseButtonUp(0) && !GameManager.isPlayerDead &&
#if UNITY_EDITOR
                !EventSystem.current.IsPointerOverGameObject())
#else
                !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
            {
                //델리게이트 여쭤보기
                //if (currentTime > lastClickTime + jumpDealay)
                //{
                //    sound.PlaySound(jumpClick);
                //    cliTime = currentTime;
                //    //     Debug.Log("Speed   : " + "   Click  calcu : " + (currentTime - landTime));
                //    prevClick = cliTime;
                //    lastClickTime = currentTime;
                //    //var jump = force * gauge.fillAmount;

                //    if (jump < 200f)
                //        rd.AddForce(Vector3.up * force * 0.5f);
                //    else if (jump > 300f)
                //        rd.AddForce(Vector3.up * force * 0.8f);
                //    else
                //        rd.AddForce(Vector3.up * jump);
                //    clickTime = 0f;
                //}
                //isDown = false;
                //gauge.fillAmount = 0f;
            }
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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                //    Debug.Log("PlayerLanded : " + currentTime);
                landTime = currentTime;
                //    Debug.Log("Speed   :  " + JumpRopeMove.ropeSpeed + "   Minus Time   : " + (cliTime - landTime));
            }
        }
    }
}