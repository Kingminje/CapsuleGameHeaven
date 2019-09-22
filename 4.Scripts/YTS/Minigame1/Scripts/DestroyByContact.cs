using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 충돌 파괴 처리
public class DestroyByContact : MonoBehaviour
{
    //// 운석 폭발 이펙트
    //public GameObject explosion;
    //// 플레이어 폭발 이펙트
    //public GameObject playerExplosion;
    private Combo combo;

    private EvadeGameManager manager;

    private void Start()
    {
        combo = FindObjectOfType<Combo>();
        manager = GameObject.Find("GameController").GetComponent<EvadeGameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Star")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Destroy(other.transform.gameObject);
            manager.GameOver();
        }

        if (other.tag == "Ground")
            combo.ScoreUp(10);

        // 충돌 대상과 현재 오브젝트를 파괴함
        Destroy(gameObject);
    }
}