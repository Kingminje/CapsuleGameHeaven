using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace whs
{
    public class ColorGameUIManager : MonoBehaviour
    {
        public Text perfectText;

        public Image circleRound;

        private Color circleOriginColor;

        public GameObject correctEffect;

        public GameObject[] EffectArr;

        public static float score;

        public static bool isShowingText = false;

        private enum COLOR_NAME
        {
            RED = 0,
            BLUE = 1,
            YELLOW = 2,
            GREEN = 3
        }

        private void Start()
        {
            circleOriginColor = circleRound.color;
        }

        public void CorrectEffectPlay(string colorName)
        {
            switch (colorName)
            {
                case "Red":
                    StartCoroutine("CorrectEffectCoroutine", EffectArr[(int)COLOR_NAME.RED]);
                    break;

                case "Blue":
                    StartCoroutine("CorrectEffectCoroutine", EffectArr[(int)COLOR_NAME.BLUE]);
                    break;

                case "Yellow":
                    StartCoroutine("CorrectEffectCoroutine", EffectArr[(int)COLOR_NAME.YELLOW]);
                    break;

                case "Green":
                    StartCoroutine("CorrectEffectCoroutine", EffectArr[(int)COLOR_NAME.GREEN]);
                    break;
            }
        }

        public void SetText(int calculatedCnt)
        {
            if (calculatedCnt == 3)
            {
                score = 1;
                perfectText.text = "Pefect!!";
            }
            else if (calculatedCnt == 2)
            {
                score = 0.8f;
                perfectText.text = "GOOD!!";
            }
            else
            {
                score = 0.5f;
                perfectText.text = "BAD!!";
            }
        }

        public IEnumerator ClickDelayCoroutine()
        {
            circleRound.color = Color.red;

            yield return new WaitForSeconds(1f);

            circleRound.color = circleOriginColor;
        }

        private IEnumerator CorrectEffectCoroutine(GameObject effect)
        {
            effect.SetActive(true);

            yield return new WaitForSeconds(0.1f);

            effect.SetActive(false);
        }

        public IEnumerator ShowPerfectTextCoroutine()
        {
            perfectText.gameObject.SetActive(true);

            while (perfectText.fontSize <= 230)
            {
                yield return null;

                perfectText.fontSize += 5;
            }
            perfectText.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.2f);

            perfectText.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.2f);

            perfectText.fontSize = 10;

            perfectText.gameObject.SetActive(false);

            isShowingText = false;
        }
    }
}