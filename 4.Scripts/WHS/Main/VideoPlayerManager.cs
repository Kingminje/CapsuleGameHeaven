using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Main
{
    public class VideoPlayerManager : MonoBehaviour
    {
        public VideoPlayer videoPlayer;
        public GameObject videoQuad;

        public List<VideoClip> videoClipList = new List<VideoClip>();

        public List<Material> materialsList = new List<Material>();

        public List<RenderTexture> renderTextureList = new List<RenderTexture>();

        private void OnEnable()
        {
            SelectGame.onCloseDele += CloseEvent;
        }

        private void OnDisable()
        {
            SelectGame.onCloseDele -= CloseEvent;
        }

        public void GetSceneNum(int sceneIndex)
        {
            sceneIndex = sceneIndex - 1;

            if (sceneIndex > 13)
            {
                videoQuad.SetActive(false);
                return;
            }

            if (!videoQuad.activeSelf)
                videoQuad.SetActive(true);

            videoPlayer.clip = videoClipList[sceneIndex];

            videoPlayer.targetTexture = renderTextureList[sceneIndex];

            videoQuad.GetComponent<MeshRenderer>().material = materialsList[sceneIndex];
        }

        private void CloseEvent()
        {
            if (videoQuad.activeSelf)
                videoQuad.SetActive(false);
        }
    }
}