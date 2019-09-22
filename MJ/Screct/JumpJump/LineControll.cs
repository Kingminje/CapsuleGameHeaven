using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public class LineControll : MonoBehaviour
    {
        public Transform[] tr;
        public const int max = 3;
        private LineRenderer lr;
        private Vector3 ropeElasticity;
        public Rigidbody rc;

        public SpringJoint springJoint;

        private void Awake()
        {
            lr = GetComponent<LineRenderer>();
            lr.positionCount = max;
            LineTrSet();
            rc = transform.GetChild(1).GetComponent<Rigidbody>();
            springJoint = transform.GetChild(1).GetComponent<SpringJoint>();
        }

        private void Start()
        {
            springJoint.spring = 100;
        }

        private void Update()
        {
            lr.SetPosition(1, tr[1].transform.position);
        }

        private void LineTrSet()
        {
            tr = new Transform[max];
            for (int i = 0; i < max; i++)
            {
                tr[i] = transform.GetChild(i);
            }
            for (int i = 0; i < max; i++)
            {
                lr.SetPosition(i, tr[i].transform.position);
            }
        }

        public void LineSpringForce(Transform topline)
        {
            var tmpVector3 = topline.position;
            var tmp = tmpVector3.y;
            tmp = -(tmp);

            Debug.Log(tmp);
            rc.velocity = new Vector3(0f, tmp, 0f);
        }
    }
}