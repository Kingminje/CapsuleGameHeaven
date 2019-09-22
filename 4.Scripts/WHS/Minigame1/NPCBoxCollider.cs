using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class NPCBoxCollider : MonoBehaviour
    {
        public static bool isEnterRope = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Rope")
                isEnterRope = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Rope")
                isEnterRope = false;
        }

        private IEnumerator IsEnterSetCoroutine()
        {
            yield return new WaitForSeconds(0.1f);
            isEnterRope = false;
        }
    }
}