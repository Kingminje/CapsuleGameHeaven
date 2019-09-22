using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

    // Use this for initialization
    private void Start()
    {
        //// 오브젝트의 랜덤한 방향을 지정하여 회전 속도를 부여함
        //GetComponent<Rigidbody>().angularVelocity
        //    = new Vector3(0f, 180f, 0f) * tumble;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 180f, 0f) * tumble * Time.deltaTime);
    }
}