using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class ArrowObjMove : MonoBehaviour
    {
        private Transform tr;

        private Vector3 direction = new Vector3(0, 0, 1f);

        public float speed = 200f;

        // Use this for initialization
        private void Start()
        {
            tr = GetComponent<Transform>();
            ColorGameManager.isClickDelay = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!ColorGameManager.isClickDelay)
                tr.Rotate(direction * speed * Time.deltaTime);
        }

        public void ArrowSpeedUp()
        {
            speed += 50;
        }
    }
}