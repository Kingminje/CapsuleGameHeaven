using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject boxParent;

    private BoxGameManager bgm;

    private void Start()
    {
        boxParent = GameObject.Find("BoxParent");

        bgm = GameObject.Find("GameManager").GetComponent<BoxGameManager>();

        boxParent.GetComponent<BoxParent>().AddBox(gameObject);

        gameObject.transform.SetParent(boxParent.transform);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PrevBox" && gameObject.tag == "Box")
        {
            gameObject.tag = "PrevBox";

            OnLandedTr();

            BoxRefresh();

            CreateScattering();

            CheckScoreAndEvent();
        }
        //그냥 그라운드에 다으면 게임종료
        if (other.gameObject.tag == "Ground")
        {
            if (bgm != null)
                bgm.GameOver();
        }
    }

    private void OnLandedTr()
    {
        bgm.PlayBoxSound();
        BoxMathf.CaculateCurrentBox(gameObject, bgm);

        Generator.IsLanded = true;

        bgm.landedBox.name = "prevBox";
    }

    private void CreateScattering()
    {
        /*
         *  포지션 = 잘라진 박스의 scale - 잘라진 박스의 postion;
         *  크기  = 잘라지지않은 박스의 scale  - 잘라진 박스의 scale;
         *  obj생성Pos =  포지션
         */

        Vector3 createPos = BoxMathf.CalculateCreatePos(bgm);

        GameObject scattering = Instantiate(bgm.currentBox, createPos, Quaternion.identity);

        BoxMathf.CalculateScatter(scattering, bgm);

        boxParent.GetComponent<BoxParent>().AddBox(scattering);
    }

    private void BoxRefresh()
    {
        bgm.prevBox = bgm.landedBox;

        bgm.landedBox = gameObject;
    }

    private void CheckScoreAndEvent()
    {
        BoxGameManager.onLandDele();

        if (!BoxGameManager.isGameOver)
            BoxGameManager.GetInstance().SendScore();
    }
}