using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class ArrowCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!ColorGameManager.isClickDelay)
            {
                Debug.Log(other.gameObject.name);

                Debug.Log("DataColor : " + other.GetComponent<ColorData>().colorName);

                ColorGameManager.GetInstance().ColorDataCheck(other.GetComponent<ColorData>().colorName);

                gameObject.SetActive(false);
            }
        }
    }
}