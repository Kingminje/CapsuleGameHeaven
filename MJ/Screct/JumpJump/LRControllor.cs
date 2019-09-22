using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MJ
{
    [RequireComponent(typeof(LineRenderer))]
    public class LRControllor : MonoBehaviour
    {
        public LineRenderer lr;

        public GameObject jumpRopeA;
        public GameObject jumpRopeB;
        public Vector3 startPos;
        public Vector3 endPos;
        public float linewidth = 5f;

        public Ray ray;
        public RaycastHit hit;

        private void Awake()
        {
            lr = gameObject.GetComponent<LineRenderer>();

            startPos = transform.position;
            endPos = jumpRopeB.transform.position;

            Vector3[] inlinePositions = new Vector3[2] { Vector3.zero, Vector3.zero };
            lr.SetPositions(inlinePositions);
            lr.SetWidth(linewidth, linewidth);
        }

        private void Update()
        {
            LineDrow();
        }

        private void LineDrow()
        {
            lr.SetPosition(0, jumpRopeA.transform.position);
        }

        private Vector3 RayPlayerCheckTolrSet(Vector3 startPosition, Vector3 endPosition)
        {
            var endpos = (startPosition - endPosition);
            ray = new Ray(startPosition, endpos);
            if (Physics.Raycast(ray, out hit))
            {
                endPosition = hit.point;
                PlayerCheckToKill(hit);
            }
            lr.SetPosition(1, endpos);

            return endpos;
        }

        public bool PlayerCheckToKill(RaycastHit hit)
        {
            if (hit.transform.gameObject.name == "Player")
            {
                Destroy(hit.transform.gameObject);
                return true;
            }
            return false;
        }
    }
}