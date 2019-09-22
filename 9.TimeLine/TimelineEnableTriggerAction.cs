using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

namespace MJ
{
    public class TimelineEnableTriggerAction : MonoBehaviour
    {
        private int time;

        private void Update()
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    Debug.Log(Time.time);
            //}
        }

        public void GetSceneNum(int sceneIndex)
        {
            sceneIndex = sceneIndex - 1;

            //if (!videoQuad.activeSelf)
            //    videoQuad.SetActive(true);

            //videoPlayer.clip = videoClipList[sceneIndex];

            //videoPlayer.targetTexture = renderTextureList[sceneIndex];

            //videoQuad.GetComponent<MeshRenderer>().material = materialsList[sceneIndex];
        }
    }
}