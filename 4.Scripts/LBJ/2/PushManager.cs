using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PushManager : MonoBehaviour
{
    public GameObject cube;
    private Vector3 moveVector;

    private bool keystate = false;
    private GameObject player;

    private Combo combo;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);

        //SettingPlayer();
        combo = FindObjectOfType<Combo>();
        combo.ResetScore();

        combo.bestScore = PlayerPrefs.GetInt("CATCHBESTSCORE").ToString();
        combo.bestScoreText.text = combo.bestScore;
    }

    private void SettingPlayer()
    {
        player = CreatePlayer.player;
        player.transform.position = new Vector3(-1f, 1.18f, 1.58f);
    }

    private void Update()
    {
        KeyState();
    }

    public void KeyState()
    {
        if (Input.anyKey &&
#if UNITY_EDITOR
            !EventSystem.current.IsPointerOverGameObject())
#else
            !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
        {
            keystate = true;
        }
        else
        {
            keystate = false;
        }

        if (keystate && lbj.SpwanManager.isSpwan)
        {
            moveVector = new Vector3(-1f, 1f, 0.5f);
            cube.transform.DOMove(moveVector, 0.5f);
        }
        else if (!keystate)
        {
            moveVector = new Vector3(-1f, 0.01f, 0.5f);
            cube.transform.DOMove(moveVector, 0.5f);
        }
    }

    public void GameOver()
    {
        MainUIManager.GetInstance().ShowRestartPanel();
        //Leaderboard.AddScore(ScoreBook.AddScores());

        PlayerPrefs.SetInt("CATCHBESTSCORE", int.Parse(combo.bestScore));
        PlayerPrefs.Save();

        Leaderboard.stageNum = 10;
        Leaderboard.AddScore(PlayerPrefs.GetInt("CATCHBESTSCORE"), 10);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}