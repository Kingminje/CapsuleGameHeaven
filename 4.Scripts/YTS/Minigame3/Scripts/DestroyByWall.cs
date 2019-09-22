using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 충돌 파괴 처리
public class DestroyByWall : MonoBehaviour
{
    //// 운석 폭발 이펙트
    //public GameObject explosion;
    //// 플레이어 폭발 이펙트
    //public GameObject playerExplosion;
    private Combo combo;

    public ParticleSystem blood;
    public Transform child;
    private ArrowGameManager manager;
    private MJ.SoundManager sm;

    private void Start()
    {
        combo = FindObjectOfType<Combo>();
        manager = GameObject.Find("GameController").GetComponent<ArrowGameManager>();
        sm = FindObjectOfType<MJ.SoundManager>();
        //child = GameObject.Find("Appearance").GetComponent<Transform>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Star")
        {
            return;
        }

        if (other.tag == "Player" || other.tag == "Border")
        {
            //Destroy(other.transform.gameObject);
            manager.GameOver();
            Destroy(gameObject);
        }

        if (other.tag == "Bullet")
        {
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Hit);
            blood.Play();
            StartCoroutine(DelayDead());
            //Destroy(other.transform.gameObject);
        }
    }

    private IEnumerator DelayDead()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        child.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}