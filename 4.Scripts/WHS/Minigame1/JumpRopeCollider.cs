using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class JumpRopeCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("EnterCollider");

                GameManager.isPlayerDead = true;

                GameManager.GetInstance().RestartGame();
            }
        }
    }
}