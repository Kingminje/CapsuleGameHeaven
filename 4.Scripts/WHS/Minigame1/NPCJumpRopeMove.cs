using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class NPCJumpRopeMove : JumpRopeMove
    {
        public NPCAI npcAI;

        protected int ropeDelay = 15;

        private void InitGameNpc()
        {
            ropeSpeed = MinRopeSpeed;

            tr.rotation = qt;

            StartCoroutine(CalculaterDelayCoroutine());
            //  StartCoroutine(ChangeSpeed());
        }

        private void Start()
        {
            InitGameNpc();
        }

        public override void Update()
        {
            base.Update();

            //   if (!NPCAI.isLanded)
        }

        private int ChangeRopeDelaySpeed(int r)
        {
            int changedDelay = 0;
            switch (r)
            {
                case 0:
                    changedDelay = 5;
                    break;

                case 1:
                    changedDelay = 10;
                    break;

                case 2:
                    changedDelay = 15;
                    break;

                case 3:
                    changedDelay = 20;
                    break;
            }
            return changedDelay;
        }

        public IEnumerator CalculaterDelayCoroutine()
        {
            int r = Random.Range(1, 4);

            int rNum = Random.Range(0, 5);

            ropeDelay = ChangeRopeDelaySpeed(r);

            yield return new WaitUntil(() => NPCBoxCollider.isEnterRope);

            ropeSpeed = ChangeRopeSpeed(rNum);

            npcAI.CheckSpeed(ropeSpeed);
        }
    }
}