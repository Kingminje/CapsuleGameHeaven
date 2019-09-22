using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TailMovement : MonoBehaviour
{
    public float speed;
    public Vector3 tailTarget;
    private SnakeMovement movement;
    public GameObject tailTargetObj;

    public int index;

    // Use this for initialization
    private void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeMovement>();
        speed = movement.speed - 1f;
        tailTargetObj = movement.tailObjects[movement.tailObjects.Count - 2];
        index = movement.tailObjects.IndexOf(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        tailTarget = tailTargetObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * speed);
    }
}