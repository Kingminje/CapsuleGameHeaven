using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public class DirectMovement : MonoBehaviour
    {
        public Vector3 direction;
        public float speed;

        private void FixedUpdate()
        {
            if (transform.position.x == 12)
            {
                direction = Vector3.left;
            }
            else if (transform.position.x == -12)
            {
                direction = Vector3.right;
            }
            Move();
        }

        public void Move()
        {
            // 지정한 방향으로 이동
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}