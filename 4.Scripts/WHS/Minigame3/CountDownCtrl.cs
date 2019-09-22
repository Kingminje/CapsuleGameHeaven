using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace whs
{
    public class CountDownCtrl : MonoBehaviour
    {
        public Image countImage;
        public Text countDownText;
        private ArrowObjMove arrowMove;

        public float countNum = 60f;
        private float cnt = 60;
        private bool isEnd = false;

        private void Start()
        {
            cnt = countNum;
            arrowMove = FindObjectOfType<ArrowObjMove>();
            StartCoroutine(CountDown());
            StartCoroutine(CountDownImageCoroutine());
        }

        public void AddTime()
        {
            countNum += 2;
            countDownText.text = countNum.ToString();
            cnt = countNum;
        }

        private IEnumerator CountDownImageCoroutine()
        {
            while (!isEnd)
            {
                yield return null;

                cnt = (cnt - Time.deltaTime);

                countImage.fillAmount = cnt / 60;
            }
        }

        private IEnumerator CountDown()
        {
            while (!isEnd)
            {
                yield return new WaitUntil(() => !ColorGameUIManager.isShowingText);
                yield return new WaitForSeconds(1f);
                countNum -= 1;
                countDownText.text = countNum.ToString();
                if (countNum == 0)
                {
                    isEnd = true;
                    ColorGameManager.GetInstance().GameOver();
                }
                else if (countNum % 10 == 0)
                {
                    arrowMove.ArrowSpeedUp();
                }
            }
        }
    }
}