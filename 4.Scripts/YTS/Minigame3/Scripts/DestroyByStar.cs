using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByStar : MonoBehaviour
{
    public string[] Tagets = new string[3];

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tagets[1]))
        {
            ArrowShooter.trggerDelay = false;
            Destroy(gameObject, 0.1f);
        }
        //OtherTagCheck(other);
    }

    //public void OtherTagCheck(Collider taget)
    //{
    //    for (int i = 0; i < Tagets.Length; i++)
    //    {
    //        if (taget.CompareTag(Tagets[i]))
    //        {
    //        }
    //    }
    //}
}