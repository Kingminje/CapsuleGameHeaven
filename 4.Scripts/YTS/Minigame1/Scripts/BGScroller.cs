using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed; // 스크롤 속도

    public float tileSizeZ; // 총 스크롤 크기

    private Vector3 startPosition; // 시작 위치

	// Use this for initialization
	void Start () {
        startPosition = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {

        // Mathf.Repeat(값, 최대값)
        // -> 일정 범위 내의 값을 순환 시킴

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed,
                                tileSizeZ);

        // 배경 스크롤 이동 처리
        transform.position = startPosition + 
            Vector3.forward * newPosition;

	}
}
