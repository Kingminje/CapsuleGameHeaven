using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBook : MonoBehaviour
{
    public static string[] scorenames = { "EVADEBESTSCORE", "SNAKEBESTSCORE", "ARROWBESTSCORE", "PUNCHGAMESCORE", "ROPEGAMESCORE",
        "JUMPGAMESCORE", "JUMPROPEBESTSCORE", "BOXGAMEBESTSCORE", "COLORGAMEBESTSCORE", "RUNBESTSCORE", "CATCHBESTSCORE" };

    public static long AddScores()
    {
        //string[] scorenames = new string[] { "ROPEGAMESCORE", "PUNCHGAMESCORE", "JUMPGAMESCORE", "CATCHBESTSCORE", "RUNBESTSCORE", "JUMPROPEBESTSCORE", "BOXGAMEBESTSCORE", "COLORGAMEBESTSCORE", "EVADEBESTSCORE", "SNAKEBESTSCORE", "ARROWBESTSCORE" };
        long totalScore = 0L;

        foreach (var c in scorenames)
        {
            if (PlayerPrefs.GetInt(c) != 0)
            {
                var tmpSocre = PlayerPrefs.GetInt(c);
                Debug.LogFormat("{0},{1}", c, PlayerPrefs.GetInt(c));
                totalScore += tmpSocre;
            }
        }

        return totalScore;
    }
}