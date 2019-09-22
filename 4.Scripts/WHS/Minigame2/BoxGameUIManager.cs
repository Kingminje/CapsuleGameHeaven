using UnityEngine;
using UnityEngine.UI;

public class BoxGameUIManager : MonoBehaviour
{
    public Text scoreText;

    public Image playerDead;

    private void Start()
    {
        InitGame();
    }

    public void InitGame()
    {
        playerDead.gameObject.SetActive(false);
        scoreText.text = 0.ToString();
    }

    public void GetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void GetPlayerDead()
    {
        playerDead.gameObject.SetActive(true);
    }

    public void OnClickRestart()
    {
        BoxGameManager.GetInstance().RestartGame();
    }
}