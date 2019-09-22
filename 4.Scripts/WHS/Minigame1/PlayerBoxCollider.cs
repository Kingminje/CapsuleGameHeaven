using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxCollider : MonoBehaviour
{
    public static bool isPlayerEnterRope = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rope")
        {
            isPlayerEnterRope = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Rope")
        {
            isPlayerEnterRope = false;
        }
    }
}