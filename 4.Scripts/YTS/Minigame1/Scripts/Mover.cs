using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float downSpeed; // 이동 속도
    public float sideSpeed;
    private float time;
    public float delayTime;

    private void Start()
    {
        sideSpeed = Random.Range(1, sideSpeed);

        // 이동 속도 지정
        GetComponent<Rigidbody>().velocity =
            transform.up * downSpeed + transform.right * Random.Range(-sideSpeed, sideSpeed);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= delayTime)
        {
            StartCoroutine(DelayPosition());
        }
    }

    private IEnumerator DelayPosition()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        time = 0f;
        yield return new WaitForSeconds(2.0f);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        GetComponent<Rigidbody>().velocity =
            transform.up * downSpeed + transform.right * Random.Range(-sideSpeed, sideSpeed);
    }
}