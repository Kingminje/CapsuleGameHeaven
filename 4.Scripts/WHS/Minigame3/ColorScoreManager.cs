using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class ColorScoreManager : MonoBehaviour
    {
        public GameObject[] starObjs;

        private Transform starPos;

        private GameObject createdStar = null;

        private readonly int score = 10;

        public Combo combo;

        public void Start()
        {
            starPos = GameObject.Find("StarPos").transform;
            ComboSetting();
        }

        public void ScoreUp()
        {
            combo.ScoreUp((int)(score * ColorGameUIManager.score));
        }

        private void ComboSetting()
        {
            combo = GetComponent<Combo>();

            combo.FindScoreText();

            combo.bestScore = PlayerPrefs.GetInt("COLORGAMEBESTSCORE").ToString();

            Debug.Log(combo.bestScoreText);

            combo.bestScoreText.text = combo.bestScore;

            combo.ResetScore();
        }

        public void CreateStar(int starIndex)
        {
            if (starIndex < 2)
                return;

            //  createdStar = Instantiate(starObjs[starIndex], starPos.position, Quaternion.identity);

            GetComponent<ArrowPlayerController>().PlayerJump();
        }
    }
}