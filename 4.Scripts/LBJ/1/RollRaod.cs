using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollRaod : MonoBehaviour
{
    public GameObject road;

    public static float n = 1f;

    private void Start()
    {
        Init();
        road.GetComponent<Transform>();
    }

    private void Init() // 초기화
    {
        n = 1f;
        lbj.Manager.gameOver = false;
        lbj.Manager.isCtrl = false;
    }

    private void Update()
    {
        if (PauseManager._isPause) return;

        road.transform.Rotate(Vector3.left * n); // 실제로 트랙이 회전하는 값
    }
}