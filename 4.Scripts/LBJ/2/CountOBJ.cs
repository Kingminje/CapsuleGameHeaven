using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountOBJ : MonoBehaviour
{
    private PushManager manager;
    private Combo combo;
    private MJ.SoundManager sm;

    private void Start()
    {
        manager = FindObjectOfType<PushManager>();
        combo = FindObjectOfType<Combo>();
        sm = FindObjectOfType<MJ.SoundManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            DestroyAllOBJ();
            manager.GameOver();
            lbj.SpwanManager.isSpwan = false;
        }

        if (other.gameObject.tag == "Coin")
        {
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            //Destroy(other.gameObject);
            //lbj.SpwanManager.count++;
        }
        Destroy(other.gameObject);
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