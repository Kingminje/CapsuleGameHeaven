using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class CountScore : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Rope" && !GameManager.isPlayerDead)
            {
                GameManager.GetInstance().CheckScore();
                //GameManager.GetInstance().GameOver();
            }
        }
    }
}