using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MJ
{
    public class PlayerMove : MonoBehaviour
    {
        public float speed = 2;
        public bool direction = true;
        public Vector3 MovePoint;

        public float clickDelay = 0.2f;
        private float time;

        private void Start()
        {
            Invoke("PlayerDlyRotate", 0.1f);
        }

        private void PlayerDlyRotate()
        {
            CreatePlayer.player.transform.localRotation = Quaternion.Euler(0, 90f, 0);
        }

        private void Update()
        {
            time += Time.deltaTime;
            transform.Translate(MovePoint * speed * Time.deltaTime);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
#if UNITY_EDITOR
                if (!EventSystem.current.IsPointerOverGameObject()
#else

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)
#endif
                && Input.GetMouseButtonDown(0) && time > clickDelay)
                {
                    DirectionMouse();
                    time = 0;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Out01")
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                direction = false;
            }
            else if (other.name == "Out02")
            {
                transform.rotation = Quaternion.Euler(0, 360, 0);
                direction = true;
            }
        }

        private void DirectionMouse()
        {
            if (direction == true)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                direction = false;
            }
            else if (direction == false)
            {
                transform.rotation = Quaternion.Euler(0, 360, 0);
                direction = true;
            }
        }
    }
}