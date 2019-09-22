using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public class Jump : MonoBehaviour
    {
        private Rigidbody rc;
        public int count;
        public Vector3 upPoint = Vector3.up;
        public static bool jumping = false;

        // Use this for initialization
        private void Start()
        {
            jumping = false;
            rc = gameObject.GetComponent<Rigidbody>();
        }

        public void JumpStart()
        {
            rc.velocity = new Vector3(0f, 0f, 0f);
            ++count; // 카운트에 따라서 올라가는 높이가 달라짐

            rc.AddForce(upPoint, ForceMode.Impulse);
            upPoint = new Vector3(0f, count, 0f);
        }
    }
}