using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCountOBJ : MonoBehaviour
{
    // 트리거 판정해서 먹으면 죽는지 안죽는지 판정
    private PushManager manager;

    private lbj.SpwanManager spwanManger;

    private Combo combo;
    private MJ.SoundManager sm;

    private void Start()
    {
        manager = FindObjectOfType<PushManager>();
        combo = FindObjectOfType<Combo>();
        sm = FindObjectOfType<MJ.SoundManager>();
        spwanManger = FindObjectOfType<lbj.SpwanManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star") == true)
        {
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            Destroy(other.gameObject);
        }
        else
        {
            var tmpCheckColor = other.transform.GetComponent<Renderer>().material.color;
            Debug.LogFormat("tmpColor = " + tmpCheckColor.ToString() + "okColor = " + spwanManger.Ok.ToString());
            if (spwanManger.Ok == tmpCheckColor)
            {
                combo.ScoreUp(10);
                sm.SoundPlay((int)MJ.AudioClipName.Item);
                //lbj.SpwanManager.count++;
                Destroy(other.gameObject);
            }
            else
            {
                lbj.SpwanManager.isSpwan = false;

                manager.GameOver();
                DestroyAllOBJ();
                Destroy(other.gameObject);
            }
        }

        //if (other.gameObject.tag == "Enemy") // 에너미 태그가 ok
        //{
        //    combo.ScoreUp(10);
        //    sm.SoundPlay((int)MJ.AudioClipName.Item);
        //    //lbj.SpwanManager.count++;
        //    Destroy(other.gameObject);
        //}

        //if (other.gameObject.tag == "Coin") //코인 테그가 No
        //{
        //    //Destroy(other.gameObject);
        //    lbj.SpwanManager.isSpwan = false;

        //    manager.GameOver();
        //    DestroyAllOBJ();
        //    Destroy(other.gameObject);
        //}
    }

    public void DestroyAllOBJ()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Coin"))
        {
            Destroy(obj);
        }
    }
}