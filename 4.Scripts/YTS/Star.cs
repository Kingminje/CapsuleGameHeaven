using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public int score;
    private Combo combo;
    public Text comboText;
    private MJ.SoundManager sm;

    private void Awake()
    {
    }

    private void Start()
    {
        combo = FindObjectOfType<Combo>();
        sm = FindObjectOfType<MJ.SoundManager>();
        comboText = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Star")
        {
            return;
        }

        if (other.tag == "Player" || other.tag == "Bullet" || other.tag == "Box")
        {
            comboText.GetComponentInParent<Canvas>().enabled = true;
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            //Destroy(gameObject);
            if (gameObject.name == "RedStar(Clone)")
            {
                combo.redCnt++;
                combo.yellowCnt = 0;
                combo.greenCnt = 0;
                comboText.text = combo.redCnt.ToString() + "Combo!";
                StartCoroutine(ShowCombo());
                combo.ScoreUp(score * combo.redCnt);
            }
            else if (gameObject.name == "YellowStar(Clone)")
            {
                combo.yellowCnt++;
                combo.redCnt = 0;
                combo.greenCnt = 0;
                comboText.text = combo.yellowCnt.ToString() + "Combo!";
                StartCoroutine(ShowCombo());
                combo.ScoreUp(score * combo.yellowCnt);
            }
            else if (gameObject.name == "GreenStar(Clone)")
            {
                combo.greenCnt++;
                combo.yellowCnt = 0;
                combo.redCnt = 0;
                comboText.text = combo.greenCnt.ToString() + "Combo!";
                StartCoroutine(ShowCombo());
                combo.ScoreUp(score * combo.greenCnt);
            }
            else if (gameObject.name == "RainbowStar(Clone)")
            {
                if (combo.redCnt > 0 && combo.yellowCnt == 0 && combo.greenCnt == 0)
                {
                    combo.redCnt++;
                    comboText.text = combo.redCnt.ToString() + "Combo!";
                    StartCoroutine(ShowCombo());
                    combo.ScoreUp(score * combo.redCnt);
                }
                else if (combo.yellowCnt > 0 && combo.redCnt == 0 && combo.greenCnt == 0)
                {
                    combo.yellowCnt++;
                    comboText.text = combo.yellowCnt.ToString() + "Combo!";
                    StartCoroutine(ShowCombo());
                    combo.ScoreUp(score * combo.yellowCnt);
                }
                else if (combo.greenCnt > 0 && combo.yellowCnt == 0 && combo.redCnt == 0)
                {
                    combo.greenCnt++;
                    comboText.text = combo.greenCnt.ToString() + "Combo!";
                    StartCoroutine(ShowCombo());
                    combo.ScoreUp(score * combo.greenCnt);
                }
                else
                {
                    StartCoroutine(ShowCombo());
                    combo.ScoreUp(score);
                }
            }
        }
        //Destroy(gameObject);
    }

    private IEnumerator ShowCombo()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        comboText.GetComponentInParent<Canvas>().enabled = false;
        Debug.Log("sss");
        Destroy(gameObject);
        //comboCnt.GetComponentInParent<Canvas>().enabled = false;
    }
}