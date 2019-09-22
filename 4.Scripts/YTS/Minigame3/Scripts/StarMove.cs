using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    public float sideSpeed = 2;

    // Use this for initialization
    private void Start()
    {
        GetComponent<Rigidbody>().velocity =
            transform.right * Random.Range(1, sideSpeed);
    }
}