using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class ChangeScene : MonoBehaviour
    {
        private static int _sceneIndex;

        /// <summary>
        /// 이동하고자 하는 ChangeSceneIndex = sceneIndex
        /// </summary>
        public static int ChangeSceneIndex
        {
            get { return _sceneIndex; }
            set { _sceneIndex = value; }
        }

        private void Awake()
        {
            ScelctChangeScene(_sceneIndex);
        }

        private void ScelctChangeScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}