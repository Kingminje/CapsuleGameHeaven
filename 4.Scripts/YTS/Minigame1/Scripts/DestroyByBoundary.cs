using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 충돌 영역 파괴 처리
public class DestroyByBoundary : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.transform.root.gameObject);
    }
}
