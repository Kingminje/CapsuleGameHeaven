using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using whs;

//가만히 있는 상태
//점프를 뛰는 상태
/*
 * IDLE-> JUMP START()
 * JUMP Delay 시간으로 yield return
 *
 * Game over 시 초기화
 */

namespace whs
{
    public class NPCAI : MonoBehaviour
    {
        public float delay = 0.75f;

        private Rigidbody rigid;

        private NPCJumpRopeMove npcJumpRopeMove;

        public static bool isLanded = true;

        private int prevSpeed = 0;

        private IEnumerator Start()
        {
            rigid = GetComponent<Rigidbody>();

            npcJumpRopeMove = GameObject.Find("NpcJumpRope").GetComponent<NPCJumpRopeMove>();

            yield return new WaitForSeconds(1.2f);

            Jump();

            CheckSpeed(npcJumpRopeMove.ropeSpeed);

            StartCoroutine(JumpCoroutine());
        }

        public IEnumerator JumpCoroutine()
        {
            while (!GameManager.isPlayerDead)
            {
                yield return StartCoroutine(npcJumpRopeMove.CalculaterDelayCoroutine());

                yield return new WaitUntil(() => isLanded);

                yield return new WaitForSeconds(delay);

                Jump();
            }
        }

        private void Jump()
        {
            isLanded = !isLanded;
            rigid.AddForce(Vector3.up * 190);
        }

        //줄넘기 스피드마다 뛰는 딜레이를 줌
        public void CheckSpeed(int speed)
        {
            switch (speed)
            {
                case 2:
                    SetDelayTime(2.0f);
                    break;

                case 3:
                    SetDelayTime(1.18f);
                    break;

                case 4:
                    SetDelayTime(0.78f);
                    break;

                case 5:
                    SetDelayTime(0.53f);
                    break;

                case 6:
                    SetDelayTime(0.32f);
                    break;

                case 7:
                    SetDelayTime(0.18f);
                    break;

                case 8:
                    SetDelayTime(0.1f);
                    break;
            }

            if (speed == prevSpeed && prevSpeed == 2)
            {
                Debug.Log(" 2  = = 2 speed");
                delay += 0.15f;
            }
            else if (speed == 2 && prevSpeed == 3)
            {
                Debug.Log("1.9 And 1.2F");
                delay += 0.15F;
            }
            else if (speed == 2 && prevSpeed == 4)
            {
                Debug.Log("2.0 and 0.78");
                delay += 0.12f;
            }
            else if (speed == 2 && prevSpeed == 5)
            {
                Debug.Log("2.0 and 0.5");

                delay += 0.05f;
            }
            else if (speed == 2 && prevSpeed == 6)
            {
                Debug.Log("2.0 and 0.3");
                delay += 0.12f;
            }
            else if (speed == 3 && prevSpeed == 2)
            {
                Debug.Log("1.16");
                delay += 0.1f;
            }
            else if (speed == prevSpeed && prevSpeed == 3)
            {
                Debug.Log("1.18f and 1.18f");
                delay += 0.05f;
            }
            else if (speed == 4 && prevSpeed == 3)
            {
                Debug.Log("0.78 and 1.18f");
                delay += 0.08f;
            }
            prevSpeed = speed;
        }

        private void SetDelayTime(float delay)
        {
            //   float r = Random.Range(-0.01f, 0.01f);
            this.delay = delay;
            // Debug.Log("Change Delay : " + this.delay);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
                isLanded = true;
        }
    }
}