using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoxMathf
{
    public static Vector3 CalculateCreatePos(BoxGameManager bgm)
    {
        Transform tmp = bgm.landedBox.transform;

        float newPosX = Mathf.Abs(tmp.localScale.x) + Mathf.Abs(tmp.position.x);

        Vector3 pos = new Vector3(CheckSign(tmp.position.x, bgm) * newPosX, tmp.position.y, -5);

        return pos;
    }

    //// 잘라진박스의 색갈 트리거등 잡설정셋팅
    public static void CalculateScatter(GameObject scattering, BoxGameManager bgm)
    {
        Transform tmp = bgm.landedBox.transform;

        float newScaleX = bgm.prevBox.transform.localScale.x - tmp.localScale.x;

        scattering.transform.localScale = new Vector3(newScaleX, tmp.localScale.y, tmp.localScale.z);

        scattering.tag = "Player";

        scattering.AddComponent<ScatteringMovement>().sign = CheckSign(tmp.position.x, bgm);

        SetScattering(scattering);
    }

    private static void SetScattering(GameObject scattering)
    {
        scattering.GetComponent<Box>().enabled = false;

        scattering.GetComponent<Collider>().isTrigger = false;

        scattering.gameObject.name = "Scattering";

        //   scattering.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    public static int CheckSign(float landTrX, BoxGameManager bgm)
    {
        int sign = 1;
        //크면 오른쪽 작으면  왼쪽에서 생성됨
        if (landTrX > bgm.prevBox.transform.position.x)
            sign = 1;
        else
            sign = -1;
        return sign;
    }

    //현재 박스를 이전 땅에 닿은 박스와 계산해서 자르는 것
    public static void CaculateCurrentBox(GameObject obj, BoxGameManager bgm)
    {
        Transform currentBoxTr = obj.transform;

        Transform landedBox = bgm.landedBox.transform;

        float trX = (landedBox.position.x - currentBoxTr.position.x);

        currentBoxTr.position = new Vector3(currentBoxTr.position.x + (trX / 2), currentBoxTr.position.y, currentBoxTr.position.z);

        currentBoxTr.localScale = new Vector3(currentBoxTr.localScale.x - Mathf.Abs(trX), currentBoxTr.localScale.y, currentBoxTr.localScale.z);

        bgm.currentBox = obj;

        obj.name = "LandedBox";
    }
}