using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float sideSpeed;

    // Use this for initialization
    private void Start()
    {
        //sideSpeed = Random.Range(1, sideSpeed);

        // 이동 속도 지정
        GetComponent<Rigidbody>().velocity =
            transform.forward * Random.Range(1, sideSpeed);
    }
}