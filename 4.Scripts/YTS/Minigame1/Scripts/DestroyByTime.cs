using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
        // 생존 시간뒤에 파괴해라
        Destroy(gameObject, lifetime);
	}
	
}
