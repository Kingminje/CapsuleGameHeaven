using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MJ
{
    public enum AudioClipName
    {
        Punch,
        Jump,
        Item,
        Bow,
        Hit
    }

    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;

        public AudioClip[] audioClips;
        public Resources resources;

        // public AudioClipName audioClipName = AudioClipName.Hit;

        private void Awake()
        {
            //string path = "Sounds";

            //  audioClips = Resources.LoadAll<AudioClip>(path);
            //  Resources.Load<AudioClip>(path);

            Debug.Log("사운드 작동");
        }

        public void SoundPlay(int ClipNum)
        {
            SoundPlayProcessor(ClipNum);
        }

        private void SoundPlayProcessor(int ClipNum)
        {
            Debug.LogFormat("사운드 클립 {0}", ClipNum);
            var tmpClip = audioClips[ClipNum];
            audioSource.PlayOneShot(tmpClip);
        }
    }
}