using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    // Update is called once per frame
    private void LateUpdate()
    {
        // 현재 UI의 회전값을 카메라의 시선과 일치시킴
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}