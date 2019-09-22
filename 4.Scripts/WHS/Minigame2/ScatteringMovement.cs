using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatteringMovement : MonoBehaviour
{
    public int sign = 0;

    private Transform tr;

    private Vector3 direction;

    private readonly float speed = 3f;

    // Use this for initialization
    private void Start()
    {
        tr = GetComponent<Transform>();

        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    private void Update()
    {
        tr.Translate(new Vector3(sign, 0, 0) * speed * Time.deltaTime);

        tr.Rotate(direction * speed);
    }
}