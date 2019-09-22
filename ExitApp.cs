using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitApp : MonoBehaviour
{
    private int count = 0;

    public GameObject quitPanel;

    private void Awake()
    {
        quitPanel = GameObject.Find("QuitPanel");
        if (quitPanel.activeSelf)
        {
            quitPanel.SetActive(false);
        }        
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.Space))) //test(Input.GetKeyDown(KeyCode.Space))//(Input.GetKeyDown(KeyCode.Escape))
        {
            if (count != 2)
            {
                count += 1;
                Show();
                StartCoroutine(EndProcessor());
            }
        }
        else if (count == 2)
        {
            Exit();
            UnityEngine.Application.Quit();
        }
    }

    private void Show()
    {
        quitPanel.SetActive(true);
    }

    private IEnumerator EndProcessor()
    {
        yield return new WaitForSeconds(3f);
        count = 0;
        quitPanel.SetActive(false);
    }

    private void Exit()
    {
        quitPanel.SetActive(false);
    }
}