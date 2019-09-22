using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public MainSoundManager mainSoundManager;
    public GameObject ScoreCanvas;
    public GameObject RestartCanvas;
    private static MainUIManager _mainUiManger = null;
    public PauseManager pm;

    public delegate void uiRestartDele();

    public static uiRestartDele onUiRestart;

    private void Awake()
    {
        // 화면 비율 고정 및 화면 꺼지는것 방지
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //Screen.SetResolution(Screen.width, Screen.height, true);
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
        // 제대로 작동 되는 지 확인 여부
        Debug.Log("스크린 사이즈 와이드 : " + Screen.width);
        Debug.Log("스크린 사이즈 하이트 : " + Screen.height);

        if (_mainUiManger == null)
            _mainUiManger = this;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MinigameMain")
        {
            pm.OnPointerDown("PauseButton");
        }
#else
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MinigameMain")
        {
            pm.OnPointerDown("PauseButton");
        }
#endif
    }

    private void OnEnable()
    {
        onUiRestart += GameRestart;
    }

    public static MainUIManager GetInstance()
    {
        return _mainUiManger;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        pm = GameObject.Find("PauseCanvas").GetComponent<PauseManager>();
        ScoreCanvas.SetActive(false);
        RestartCanvas.SetActive(false);
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        mainSoundManager.PlayRandBGM();

        if (scene.name == "MinigameMain")
        {
            mainSoundManager.PlayerMainBGM();
            ScoreCanvas.SetActive(false);
        }
        else
        {
            mainSoundManager.PlayRandBGM();
            ScoreCanvas.SetActive(true);
        }
    }

    public void ShowRestartPanel()
    {
        pm.Pause();
        RestartCanvas.SetActive(true);
    }

    public void OnClickRestartButton()
    {
        RestartCanvas.SetActive(false);
    }

    private void GameRestart()
    {
        ScoreCanvas.GetComponentInChildren<Text>().text = 0.ToString();
        //    GameObject.Find("ScoreText").GetComponent<Text>().text = 0.ToString();
    }
}