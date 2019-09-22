using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    /// <summary>
    /// 선택한 게임씬으로 이동하는 기능들입니다
    /// </summary>
    public class SelectGame : MonoBehaviour
    {
        private static SelectGame Instance = null;

        public RectTransform content;

        private Vector2 pos = new Vector2(-441.5f, 378f);
        private int sceneIndex = 0;

        public GameObject checkImg;

        public delegate void OnClickCloseDele();

        public static OnClickCloseDele onCloseDele;

        private void Awake()
        {
            Instance = this;
        }

        public static SelectGame GetInstance()
        {
            return Instance;
        }

        public void OnClickLoadScene(int sceneIndex)
        {
            this.sceneIndex = sceneIndex;
        }

        public void OnClickSelect()
        {
            //  MainGameManager.SaveData();
            checkImg.SetActive(false);
            gameObject.SetActive(false);
            //SceneManager.LoadScene(sceneIndex);
            ChangeScene.ChangeSceneIndex = sceneIndex;
            SceneManager.LoadScene(13); // 이거 왜들어감?
        }

        public void OnClickClose()
        {
            checkImg.SetActive(false);

            //content.anchoredPosition = pos;

            gameObject.SetActive(false);

            onCloseDele();
        }
    }
}