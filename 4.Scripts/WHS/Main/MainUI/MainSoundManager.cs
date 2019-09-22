using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] Bgms;

    private void Start()
    {
        PlayerMainBGM();
    }

    public void PlayerMainBGM()
    {
        StopBGM();
        audioSource.Play();
    }

    public void PlayRandBGM()
    {
        StopBGM();
        StartCoroutine(PlayerRandBGMCoroutine());
    }

    public void StopBGM()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }

    private IEnumerator PlayerRandBGMCoroutine()
    {
        while (true)
        {
            int r = Random.Range(0, 3);

            audioSource.PlayOneShot(Bgms[r]);

            yield return new WaitUntil(() => audioSource.isPlaying == false);
        }
    }
}