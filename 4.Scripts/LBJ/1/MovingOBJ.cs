using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using DG.Tweening;

public class MovingOBJ : MonoBehaviour
{
    public int moveSpeed;
    public Transform pos1, pos2;
    private Vector3 moveVector;

    public GameObject box;

    private void Awake()
    {
        moveVector = pos1.transform.position;
        //      box.transform.DOMove(moveVector, moveSpeed);
    }

    private void Update()
    {
        if (box.transform.position == pos1.position)
        {
            moveVector = pos2.transform.position;
            //  box.transform.DOMove(moveVector, moveSpeed);
        }
        if (box.transform.position == pos2.position)
        {
            moveVector = pos1.transform.position;
            // box.transform.DOMove(moveVector, moveSpeed);
        }
    }
}