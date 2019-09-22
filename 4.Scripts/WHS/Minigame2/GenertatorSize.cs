using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenertatorSize : MonoBehaviour
{
    public GameObject moverBox;
    public Vector3 resetSize = new Vector3(3, 0.5f, 1);

    private const float basicValue = 3f;

    // Use this for initialization
    private void Start()
    {
        moverBox = GameObject.Find("MoverBox");
    }

    public void InitGame()
    {
        moverBox.transform.localScale = resetSize;
    }

    public void SetBoxSize()
    {
        moverBox.transform.position = BoxGameManager.GetInstance().currentBox.transform.position;

        moverBox.transform.localScale = BoxGameManager.GetInstance().currentBox.transform.localScale;

        GeneratorMove.correctionValue = (basicValue - moverBox.transform.localScale.x) / 2f; // 제너레이터 무브의 이동 수치 증감

        Debug.Log((basicValue - moverBox.transform.localScale.x) / 2f);

        moverBox.transform.localPosition = Vector3.zero;
    }
}