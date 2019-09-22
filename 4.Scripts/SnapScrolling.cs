﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    [Range(1, 50)]
    [Header("Controllers")]
    public int panCount;

    [Range(0, 500)]
    public int panOffset;

    [Range(0f, 20f)]
    public float snapSpeed;

    [Range(0f, 5f)]
    public float scaleOffset;

    [Range(1f, 20f)]
    public float scaleSpeed;

    [Header("Other Objects")]
    public GameObject panPrefab;

    public ScrollRect scrollRect;

    private GameObject[] instPans;
    private Vector2[] pansPos;
    private Vector2[] pansScale;
    private string[] stageText = { "Back and Forth", "Lets stick", "Shooty - Shooty", "Punch - Punch", "Jump - Jump", "High - High", "Jump over", "Lets stack", "Shooty target", "Run - Run", "Catch - Catch" };

    private RectTransform contentRect;
    private Vector2 contectVector;

    private int selectedPanID;
    private bool isScrolling;

    private Leaderboard leader;

    public static string[] myScoreText;

    private void Start()
    {
        leader = FindObjectOfType<Leaderboard>();
        contentRect = GetComponent<RectTransform>();
        instPans = new GameObject[panCount];
        pansPos = new Vector2[panCount];
        pansScale = new Vector2[panCount];
        //myScoreText = new string[panCount];

        for (int i = 0; i < panCount; i++)
        {
            Leaderboard.stageNum = i;

            instPans[i] = Instantiate(panPrefab, transform, false);
            instPans[i].transform.Find("StageName").GetComponent<Text>().text = stageText[i];

            if (myScoreText[i] != null)
                instPans[i].transform.Find("MyScoreText").GetComponent<Text>().text = myScoreText[i];
            else if (PlayerPrefs.GetInt(ScoreBook.scorenames[i]) == 0)
                instPans[i].transform.Find("MyScoreText").GetComponent<Text>().text = Leaderboard.UserID + "\n" + " -- 점\n--";
            else
                instPans[i].transform.Find("MyScoreText").GetComponent<Text>().text = Leaderboard.UserID + "\n" + PlayerPrefs.GetInt(ScoreBook.scorenames[i]).ToString() + "점\n10위권 밖";

            instPans[i].transform.Find("AllScoreText").GetComponent<Text>().text = leader.scoreList[i];

            if (i == 0) continue;
            instPans[i].transform.localPosition = new Vector2(instPans[i - 1].transform.localPosition.x +
                panPrefab.GetComponent<RectTransform>().sizeDelta.x + panOffset, instPans[i].transform.localPosition.y);
            pansPos[i] = -instPans[i].transform.localPosition;
        }
        //for (int i = 0; i < Leaderboard.scoreList.Length; i++)
        //    Debug.Log(Leaderboard.scoreList[i]);
    }

    private void FixedUpdate()
    {
        if (contentRect.anchoredPosition.x >= pansPos[0].x && !isScrolling || contentRect.anchoredPosition.x <= pansPos[pansPos.Length - 1].x && !isScrolling)
        {
            scrollRect.inertia = false;
        }
        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanID = i;
            }
            //float scale = Mathf.Clamp(1 / (distance / panOffset) * scaleOffset, 0.5f, 1f);
            //pansScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale, scaleSpeed * Time.fixedDeltaTime);
            //pansScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale, scaleSpeed * Time.fixedDeltaTime);
            //instPans[i].transform.localScale = pansScale[i];
        }
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;
        if (isScrolling) return;

        contectVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contectVector;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
    }
}