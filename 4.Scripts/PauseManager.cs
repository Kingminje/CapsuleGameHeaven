using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

#if UNITY_EDITOR

using UnityEditor;

#endif

public class PauseManager : MonoBehaviour
{
    public static bool _isPause = false;

    public GameObject restart;



    //public GameObject _pasueBackGround;
    private int SCREENSIZE_X, SCREENSIZE_Y = 0;
    private Canvas canvas;
    private lbj.SpwanManager sm;

    

    private void Start()
    {
        //restart = GameObject.Find("Restart");
        canvas = GetComponent<Canvas>();
        if (sm != null)
            sm = FindObjectOfType<lbj.SpwanManager>();
    }

    public void OnPointerDown(string ped)
    {
        restart = GameObject.Find("Restart");
        Debug.Log("액티브 셀프 시작 전");
        if (restart == null)
        {
            if (ped.ToString() == "PauseButton")
            {
                Debug.Log("매뉴 버튼 클릭");
                canvas.enabled = !canvas.enabled;
                Pause();
            }
            //
        }
        else
        {
            Debug.Log("리스타트 널이라서 문제 셀프 시작 후");
            return;
        }

        //if (restart.activeSelf) return;
        //Debug.Log("액티브 셀프 시작 후");
        //Debug.Log(Event.current);
        //Debug.Log("커런트 확인 후");
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        _isPause = !_isPause;
        //  _joystick.enabled = _joystick.enabled == false ? true : false;
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        canvas.enabled = false;
        _isPause = false;
    }

    public void Restart()
    {
        MainUIManager.onUiRestart();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.enabled = false;
        _isPause = false;
    }
}