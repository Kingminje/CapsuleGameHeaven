using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    private static bool deadPlayer = false;

    public Image playerDeadImg;

    private void Init()
    {
        playerDeadImg = GameObject.Find("PlayerDeadImg").GetComponent<Image>();

        deadPlayer = false;

        playerDeadImg.gameObject.SetActive(false);
    }

    private void Start()
    {
        Init();
        StartCoroutine(PlayerDeathCoroutine());
    }

    public static void PlayerDeath()
    {
        deadPlayer = true;
    }

    private IEnumerator PlayerDeathCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil((() => deadPlayer));
        }
    }
}