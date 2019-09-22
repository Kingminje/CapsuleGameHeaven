using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class ArrowMove : MonoBehaviour
    {
        private RectTransform rt;

        public Vector3 direction = new Vector3(0, 0, 1);

        public ArrowObjMove arrowObjMove = null;

        public float speed = 3f;

        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        private void Start()
        {
            arrowObjMove = GameObject.Find("ArrowObj").GetComponent<ArrowObjMove>();
        }

        private void Update()
        {
            rt.rotation = arrowObjMove.transform.rotation;
        }
    }
}