using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class NPCJumpRopeCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("EnterNPCCollider");

                GameManager.isNpcDead = true;
            }
        }
    }
}