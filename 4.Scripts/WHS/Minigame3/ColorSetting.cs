using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace whs
{
    public class ColorSetting : MonoBehaviour
    {
        private int[] randIntArr = new int[4];

        //랜덤으로 뽑은 숫자로 colorStringData값 셋팅
        private string[] randStringArr = new string[4];

        private string[] colorCheckArr = { "Red", "Blue", "Yellow", "Green" };

        // 빨 파  노 초 록순으로 저장되어있음
        public Sprite[] colorSpriteArr = new Sprite[4];

        public List<Image> panelImageList = new List<Image>();

        public void InitGame()
        {
            SetRandomValue();

            SetImage();

            ColorGameManager.GetInstance().colorData = randStringArr;
        }

        private void Start()
        {
            InitGame();

            //for (int i = 0; i < randStringArr.Length; i++)
            //{
            //    Debug.Log(randStringArr[i]);
            //}
        }

        private void SetRandomValue()
        {
            for (int i = 0; i < randIntArr.Length; i++)
            {
                randIntArr[i] = Random.Range(0, randIntArr.Length);
                //   Debug.Log(randIntArr[i]);
            }
        }

        private void SetImage()
        {
            for (int i = 0; i < randStringArr.Length; i++)
            {
                randStringArr[i] = colorCheckArr[randIntArr[i]];
            }
            for (int i = 0; i < colorSpriteArr.Length; i++)
            {
                panelImageList[i].sprite = colorSpriteArr[randIntArr[i]];
            }
        }
    }
}