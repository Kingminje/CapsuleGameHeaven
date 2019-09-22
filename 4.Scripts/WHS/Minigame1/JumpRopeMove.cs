using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class JumpRopeMove : MonoBehaviour
    {
        protected Transform tr;
        public int ropeSpeed = 1;

        public int MaxRopeSpeed = 6;
        public int MinRopeSpeed = 1;
        public int ChangSpeedValue = 1;

        private int ropeDelay = 10;

        protected Quaternion qt;

        protected void Awake()
        {
            qt = GetComponent<Transform>().rotation;
            tr = GetComponent<Transform>();
            ropeSpeed = MinRopeSpeed;
        }

        public void InitGame()
        {
            ropeSpeed = MinRopeSpeed;
            tr.rotation = qt;
            StartCoroutine(CalculaterDelayCoroutine());
            StartCoroutine(ChangeSpeed());
        }

        private void Start()
        {
            InitGame();
        }

        public virtual void Update()
        {
            if (PauseManager._isPause) return;

            if (!GameManager.isPlayerDead)
                tr.Rotate(Vector3.right * ropeSpeed);
        }

        protected virtual IEnumerator ChangeSpeed()
        {
            while (!GameManager.isPlayerDead)
            {
                yield return new WaitForSeconds(ropeDelay);

                ropeSpeed = ropeSpeed + ChangSpeedValue;
            }
        }

        public IEnumerator MoveCoroutine(Vector3 startPos, Vector3 endPos, float time)
        {
            Vector3 currentPos = Vector3.zero;
            currentPos = startPos;
            for (float i = 0.0f; i < time; i += Time.deltaTime)
            {
                currentPos = Vector3.Lerp(startPos, endPos, i / time);
                yield return null;
                transform.position = currentPos;
            }
            transform.position = endPos;
        }

        private IEnumerator CalculaterDelayCoroutine()
        {
            while (!GameManager.isPlayerDead)
            {
                int rNum = Random.Range(0, 6);

                yield return new WaitUntil(() => PlayerBoxCollider.isPlayerEnterRope);

                ropeSpeed = ChangeRopeSpeed(rNum);
            }
        }

        protected int ChangeRopeSpeed(int r)
        {
            int changedSpeed = r + 2;

            return changedSpeed;
        }
    }
}