using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManger : MonoBehaviour
{
    public GameObject soundManger = null;
    public Slider backVolume;
    private float backVol = 1f;
    private AudioSource audio;

    public Image bgmImage;

    private void Start()
    {
        soundManger = GameObject.Find("SoundManager");
        audio = soundManger.GetComponent<AudioSource>();

        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;
    }

    public void OnClickBGM() //끈 상태에서도 BGM조절 가능하도록
    {
        if (bgmImage.color.a < 0.9) // 1f
        {
            var tmpColor = bgmImage.color;
            bgmImage.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, 1f);
            PlayerPrefs.SetFloat("backvol", 1.0f);
            backVolume.value = 1.0f;
            backVol = backVolume.value;
            Debug.Log("bgmOff");
        }
        else // 0.3f
        {
            var tmpColor = bgmImage.color;
            bgmImage.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, 0.3f);
            backVolume.value = 0.0f;
            backVol = backVolume.value;
            PlayerPrefs.SetFloat("backvol", 0.0f);
            Debug.Log("bgmOn");
        }
    }

    private void Update()
    {
        VolumeSlider();
    }

    public void VolumeSlider()
    {
        if (backVolume.value != 0.0f)
        {
            var tmpColor = bgmImage.color;
            bgmImage.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, 1f);
            //backVolume.value = 0.0f;
        }
        else
        {
            var tmpColor = bgmImage.color;
            bgmImage.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, 0.3f);
        }

        audio.volume = backVolume.value;

        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVolume.value);
    }
}