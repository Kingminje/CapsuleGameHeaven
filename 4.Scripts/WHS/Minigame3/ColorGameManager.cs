using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace whs
{
    public class ColorGameManager : MonoBehaviour
    {
        public static bool isClickDelay = false;
        private static ColorGameManager Instance = null;

        private ColorScoreManager csm;

        private CountDownCtrl countDownCtrl;

        public List<Image> mySelectColor = new List<Image>();

        public string[] colorData = { "Blue", "Red", "Yellow", "Green" };

        public int colorCheckCnt = 0;
        private int wrongCnt = 0;

        public CharacterSound characterSound;
        public AudioClip clickSound;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            csm = GetComponent<ColorScoreManager>();
            countDownCtrl = GameObject.Find("CountDownManager").GetComponent<CountDownCtrl>();
        }

        public static ColorGameManager GetInstance()
        {
            return Instance;
        }

        private void InitGame()
        {
            StartCoroutine(InitGameCoroutine());
        }

        private IEnumerator InitGameCoroutine()
        {
            isClickDelay = true;

            yield return StartCoroutine(GetComponent<ColorGameUIManager>().ShowPerfectTextCoroutine());

            isClickDelay = false;

            colorCheckCnt = 0;
            wrongCnt = 0;
            GetComponent<ColorSetting>().InitGame();

            for (int i = 0; i < mySelectColor.Count; i++)
                mySelectColor[i].sprite = null;
        }

        private IEnumerator PointerEnterResetCoroutine()
        {
            isClickDelay = true;

            yield return StartCoroutine(GetComponent<ColorGameUIManager>().ClickDelayCoroutine());

            isClickDelay = false;
        }

        public void ColorDataCheck(string color)
        {
            if (colorData[colorCheckCnt] == color)
            {
                Debug.Log("Correct Color!!!");

                characterSound.PlaySound(clickSound);

                mySelectColor[colorCheckCnt].sprite = GetComponent<ColorSetting>().panelImageList[colorCheckCnt].sprite;

                colorCheckCnt++;

                GetComponent<ColorGameUIManager>().CorrectEffectPlay(color);

                if (colorCheckCnt >= mySelectColor.Count)
                {
                    int calculatedCnt = colorCheckCnt - wrongCnt - 1;
                    GetComponent<ColorScoreManager>().CreateStar(calculatedCnt);
                    GetComponent<ColorGameUIManager>().SetText(calculatedCnt);
                    CorrectPerfect();
                    InitGame();
                }
            }
            else
            {
                wrongCnt++;
                StartCoroutine(PointerEnterResetCoroutine());
            }
        }

        private void CorrectPerfect()
        {
            ColorGameUIManager.isShowingText = true;
            csm.ScoreUp();
            countDownCtrl.AddTime();
        }

        public void GameOver()
        {
            PlayerPrefs.SetInt("COLORGAMEBESTSCORE", int.Parse(csm.combo.bestScore));

            PlayerPrefs.Save();

            MainUIManager.GetInstance().ShowRestartPanel();
            Leaderboard.stageNum = 8;
            Leaderboard.AddScore(PlayerPrefs.GetInt("COLORGAMEBESTSCORE"), 8);
        }
    }
}