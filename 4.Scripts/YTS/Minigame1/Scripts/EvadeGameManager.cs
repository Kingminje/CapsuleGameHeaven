using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EvadeGameManager : MonoBehaviour
{
    private static EvadeGameManager instance = null;
    private GameObject player;

    public GameObject[] enemies; // 적군들 프리팹 참조
    public Vector3 spawnValues; // 생성 위치

    public int genCount; // 생성 카운트
    public float spawnWait; // 생성 대기 시간
    public float startWait; // 시작 대기 시간
    public float waveWait; // 웨이브 전환시 대기 시간

    private Combo combo;

    private void Awake()
    {
        instance = this;
    }

    public static EvadeGameManager GetInstance()
    {
        return instance;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        //SettingPlayer();
        StartCoroutine("SpawnWaves");

        combo = FindObjectOfType<Combo>();
        combo.ResetScore();

        combo.bestScore = PlayerPrefs.GetInt("EVADEBESTSCORE").ToString();
        combo.bestScoreText.text = combo.bestScore;
    }

    private IEnumerator SpawnWaves()
    {
        // 시작 대기
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < genCount; i++)
            {
                // 적군 (운석, 적기) 생성

                // 랜덤하게 적군 타입을 선택
                GameObject enemy =
                    enemies[Random.Range(0, enemies.Length)];

                // 생성 위치 선택
                Vector3 spawnPosition =
                    new Vector3(Random.Range(-spawnValues.x,
                    spawnValues.x), spawnValues.y, spawnValues.z);

                Quaternion spawnRotation = Quaternion.identity;

                // 적군 생성
                GameObject star = Instantiate(enemy, spawnPosition, enemy.transform.rotation);

                if (star.tag == "Star")
                {
                    star.AddComponent<Mover>();
                    star.GetComponent<Mover>().downSpeed = -5f;
                    star.GetComponent<Mover>().sideSpeed = Random.Range(0, 3f);
                    star.GetComponent<Mover>().delayTime = 10f;
                }

                // 생성 지연
                yield return new WaitForSeconds(spawnWait);
            }

            // 웨이브 전환 시간을 대기함
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void GameOver()
    {
        MainUIManager.GetInstance().ShowRestartPanel();

        //PlayerPrefs.SetString("EVADESCORE", combo.scoreText.text);
        PlayerPrefs.SetInt("EVADEBESTSCORE", int.Parse(combo.bestScore));
        PlayerPrefs.Save();

        //Leaderboard.AddScore(ScoreBook.AddScores());
        Leaderboard.stageNum = 0;
        Leaderboard.AddScore(PlayerPrefs.GetInt("EVADEBESTSCORE"), 0);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}