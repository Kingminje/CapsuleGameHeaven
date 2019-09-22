using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    private float time;
    private readonly float animationTime = 3f;
    private readonly float delayTime = 0.5f;
    private Quaternion originQt;

    public Canvas dangerImg;

    private void OnEnable()
    {
        BoxGameManager.onRestartGame += PlayerSet;
    }

    private void OnDisable()
    {
        BoxGameManager.onRestartGame -= PlayerSet;
    }

    private IEnumerator Start()
    {
        //dangerImg = GameObject.Find("DangerousPanel").GetComponent<Canvas>();
        
        yield return new WaitForEndOfFrame();

        originQt = transform.rotation;

        //dangerImg.gameObject.SetActive(false);
    }

    private void PlayerSet()
    {
        StopAllCoroutines();
        transform.rotation = originQt;
        dangerImg.gameObject.SetActive(false);
    }

    public void PlayerDangerous()
    {
        Debug.Log("PlayerAnimation >> PlayerDangerous Enter");
        StartCoroutine(PlayerDangerousCoroutine());
    }

    public void PlayerDead()
    {
        StartCoroutine(PlayerDeadCoroutine());
    }

    private IEnumerator PlayerDangerousCoroutine()
    {
        Debug.Log("PlayerAnimation >>DangerCoroutine");
        while (BoxGameManager.isDangerous)
        {
            dangerImg.gameObject.SetActive(true);
            yield return new WaitForSeconds(delayTime);
            dangerImg.gameObject.SetActive(false);
            yield return new WaitForSeconds(delayTime);
        }
    }

    private IEnumerator PlayerDeadCoroutine()
    {
        while (time < animationTime)
        {
            transform.Rotate(Vector3.back, 50 * Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }
        time = 0;
    }
}