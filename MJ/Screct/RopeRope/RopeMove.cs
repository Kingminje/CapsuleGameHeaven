using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MJ
{
    public class RopeMove : MonoBehaviour
    {
        public Vector3 startPos, endPos, PosX;
        public Transform[] poss;

        private PaseInfo[] possPase = new PaseInfo[2];

        private bool posCheck = false;
        public float time = 0f;
        public float checkTime;
        public float speed, delayTime, minTimeValue = 0.1f, MaxTimeValue = 0.5f;

        public LineRenderer lineRenderer;
        private Transform[] linePoss = new Transform[2];

        public GameManager gameManager = null;

        public int Count = 0; // max 3 min 0; 0 디폴트, 1 가운데 체크 포인트, 2 로프 플레이어 한명이 닿았을때 3 로프 플레이어가 전부 도착하여 출발 준비가 된 상태.

        private bool ranningCoroutin = false;

        //private Coroutine coroution = null;

        private void Awake()
        {
            lineRenderer = transform.GetComponent<LineRenderer>();
            linePoss[0] = transform.GetChild(0);
            possPase[0] = linePoss[0].gameObject.AddComponent<PaseInfo>();
            linePoss[1] = transform.GetChild(1);
            possPase[1] = linePoss[1].gameObject.AddComponent<PaseInfo>();

            gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            //transform.position = startPos;
            StartCoroutine("TimeScaleUP", delayTime);
            StartCoroutine(RopeCheck());
        }

        private void FixedUpdate()
        {
            UpdateLineRenderSet();
            RayTrggerCheck();

            RopeLineMove(endPos, linePoss, time);
        }

        private void UpdateLineRenderSet()
        {
            lineRenderer.SetPosition(0, linePoss[0].position);
            lineRenderer.SetPosition(1, linePoss[1].position);
        }

        private void RayTrggerCheck()
        {
            float maxDistanse = 20f;
            RaycastHit hit;

            if (Physics.Raycast(lineRenderer.GetPosition(0), (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)), out hit, maxDistanse))
            {
                if (hit.transform.name != "B")
                {
                    RayHitList(hit.transform.name);
                }
            }
        }

        private void RayHitList(string tagName)
        {
            switch (tagName)
            {
                case "Player":
                    PlayerDetection.PlayerDie();
                    return;

                case "CheckCollider":
                    if (Count == 0)
                    {
                        ++Count;
                        gameManager.ScoreUp();
                        //Debug.Log("scoreUP");
                    }
                    return;

                default:
                    break;
            }
        }

        private float RendomValueProcessor(bool posCheck)
        {
            if (posCheck == false)
            {
                var tmpF = Random.Range(-5f, 1f);
                return tmpF;
            }
            else
            {
                var tmpF = Random.Range(1.5f, 5f);
                return tmpF;
            }
        }

        private void RopeLineMove(Vector3 endPos, Transform[] tagets, float time)
        {
            float step = time * Time.deltaTime;

            for (int i = 0; i < tagets.Length; i++)
            {
                var tmpTr = tagets[i];
                var tmpPose = possPase[i];
                endPos.z = tmpTr.position.z;

                if (tmpTr.position != endPos)
                {
                    if (tmpPose.pose == false)
                    {
                        tmpTr.position = Vector3.MoveTowards(tmpTr.position, endPos, step);
                    }
                }
                else
                {
                    if (tmpPose.pose == false)//
                    {
                        ++Count;
                        tmpPose.pose = true;// 넌 도착했다.
                    }
                }
            }
            if (Count == 3 && ranningCoroutin == false)
            {
                int randomInt = Random.Range(0, 2);
                possPase[randomInt].pose = true;

                if (posCheck == false)
                {
                    posCheck = true;
                    Count = 0;
                    this.endPos.x = RendomValueProcessor(posCheck);
                    StartCoroutine(RandomTimeDelayRope());
                }
                else
                {
                    posCheck = false;
                    Count = 0;
                    this.endPos.x = RendomValueProcessor(posCheck);
                    StartCoroutine(RandomTimeDelayRope());
                }
            }
        }

        private IEnumerator RandomTimeDelayRope()
        {
            ranningCoroutin = true;

            float tmpDelay = Random.Range(0.3f, 0.6f);
            tmpDelay = 0.6f; ////
            yield return new WaitForSeconds(tmpDelay);

            possPase[0].pose = false;
            possPase[1].pose = false;
            ranningCoroutin = false;
        }

        private IEnumerator TimeScaleUP()
        {
            if (time > 1f)
            {
                time += 1;

                yield return new WaitForSeconds(10);

                StartCoroutine("TimeScaleUP");
            }
        }

        private IEnumerator RopeCheck()
        {
            possPase[0].pose = false;
            possPase[0].pose = false;
            yield return new WaitForSeconds(3f);

            StartCoroutine(RopeCheck());
        }

    }
}