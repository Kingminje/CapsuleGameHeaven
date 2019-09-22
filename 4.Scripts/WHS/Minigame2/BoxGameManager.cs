using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGameManager : MonoBehaviour
{
    public GameObject landedBox; //지금 박스위에 안착된 박스
    public GameObject currentBox; //지금
    public GameObject prevBox; // 박스위에 안착된 박스의 전박스

    private readonly int score = 10;
    public static bool isGameOver = false;
    public static bool isPlayerDead = false;
    public static bool isDangerous = false;

    public GameObject firstBox;
    // Use this for initialization

    private GenertatorSize gs = null;

    private static BoxGameManager instance = null;
    private GameObject player;
    private Combo combo;

    public delegate void OnLandDelegate();

    public delegate void OnRestartDelegate();

    public static OnLandDelegate onLandDele;
    public static OnRestartDelegate onRestartGame;

    private const float limitHigh = 0.8f;
    private const float cameraDelay = 0.5f;
    private const float limitScale = 0.36f;

    public AudioClip boxSound;
    public CharacterSound characterSound;

    private Color originColor;

    private void OnEnable()
    {
        onLandDele += CheckGameOver;
        onLandDele += CheckLandedBox;
    }

    private void OnDisable()
    {
        onLandDele -= CheckGameOver;
        onLandDele -= CheckLandedBox;
    }

    private void Awake()
    {
        instance = this;
    }

    public static BoxGameManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        originColor = Camera.main.backgroundColor;
        landedBox = firstBox;

        gs = GameObject.Find("Generator").GetComponent<GenertatorSize>();

        player = GameObject.FindWithTag("Player");

        ComboSetting();
        RestartGame();
    }

    private void ComboSetting()
    {
        combo = GetComponent<Combo>();

        combo.FindScoreText();

        combo.bestScore = PlayerPrefs.GetInt("BOXGAMEBESTSCORE").ToString();

        Debug.Log(combo.bestScoreText);

        combo.bestScoreText.text = combo.bestScore;
    }

    public void SendScore()
    {
        combo.ScoreUp(score);
    }

    public void RestartGame()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        gs.InitGame();

        landedBox = firstBox;

        combo.ResetScore();

        yield return new WaitForSeconds(0.1f);

        isPlayerDead = false;

        isGameOver = false;

        onRestartGame();
    }

    public void PlayBoxSound()
    {
        characterSound.PlaySound(boxSound);
    }

    public void CheckGameOver()
    {
        if (currentBox.transform.localScale.x < limitScale)
            GameOver();
        if (currentBox.transform.localScale.x <= limitHigh && isDangerous == false)
            SendPlayerDangerous();
    }

    public void GameOver()
    {
        isGameOver = true;

        isPlayerDead = true;

        isDangerous = false;

        Generator.IsLanded = true;

        player.GetComponent<PlayerAnimation>().PlayerDead();

        PlayerPrefs.SetInt("BOXGAMEBESTSCORE", int.Parse(combo.bestScore));

        PlayerPrefs.Save();

        MainUIManager.GetInstance().ShowRestartPanel();
        Leaderboard.stageNum = 7;
        Leaderboard.AddScore(PlayerPrefs.GetInt("BOXGAMEBESTSCORE"), 7);
        
        Debug.Log("Game Over");
    }

    public void CheckLandedBox()
    {
        gs.SetBoxSize();
    }

    public void SendPlayerDangerous()
    {
        isDangerous = true;
        StartCoroutine(DangerousCoroutine());
        player.GetComponent<PlayerAnimation>().PlayerDangerous();
    }

    private IEnumerator DangerousCoroutine()
    {
        while (!isGameOver)
        {
            Camera.main.backgroundColor = Color.red;
            yield return new WaitForSeconds(cameraDelay);
            Camera.main.backgroundColor = originColor;
            yield return new WaitForSeconds(cameraDelay);
        }
    }
}