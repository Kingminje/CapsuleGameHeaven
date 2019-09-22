using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Combo : MonoBehaviour
{
    public static int score = 0;
    public string bestScore;
    public Text scoreText;
    public TextMeshProUGUI bestScoreText;

    public int redCnt = 0;
    public int yellowCnt = 0;
    public int greenCnt = 0;

    private Star star;

    private Animator anim;

    public void FindScoreText()
    {
        if (scoreText == null || bestScoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            bestScoreText = GameObject.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
            anim = bestScoreText.gameObject.GetComponent<Animator>();
        }
    }

    private void Start()
    {
        FindScoreText();

        score = 0;
        redCnt = 0;
        yellowCnt = 0;
        greenCnt = 0;

        //comboCnt = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Text>();
        star = FindObjectOfType<Star>();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void ScoreUp(int upScore)
    {
        // int 숫자변수 = int.Parse("숫자문자열");
        score = int.Parse(scoreText.text);
        score += upScore;

        int bs = int.Parse(bestScore);
        if (bs <= score)
        {
            anim.SetTrigger("Scale");
            bestScore = score.ToString();
        }

        scoreText.text = score.ToString();
        bestScoreText.text = bestScore;
    }

    public void ScoreUpdate(int upScore)
    {
        // int 숫자변수 = int.Parse("숫자문자열");
        score = int.Parse(scoreText.text);
        score = upScore;

        int bs = int.Parse(bestScore);
        if (bs <= score)
        {
            anim.SetTrigger("Scale");
            bestScore = score.ToString();
        }

        scoreText.text = score.ToString();
        bestScoreText.text = bestScore;
    }
}