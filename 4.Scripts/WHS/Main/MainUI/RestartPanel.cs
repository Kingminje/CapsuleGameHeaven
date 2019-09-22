using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestartPanel : MonoBehaviour
{
    private PauseManager pm;

    public TextMeshProUGUI restartText;

    private void OnEnable()
    {
        restartText.text = Combo.score.ToString();
    }

    private void Start()
    {
        pm = GameObject.Find("PauseCanvas").GetComponent<PauseManager>();
        //      gameObject.SetActive(false);
    }

    public void OnClickRestart()
    {
        pm.Restart();
        gameObject.SetActive(false);
    }

    public void OnClickHome()
    {
        pm.Home();
        gameObject.SetActive(false);
    }
}