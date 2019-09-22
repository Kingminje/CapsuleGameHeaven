using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public float time;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(ScaleChange());
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
    }

    private IEnumerator ScaleChange()
    {
        while (true)
        {
            if (time >= 1.5f)
            {
                gameObject.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
                //yield return new WaitForSeconds(1.0f);
                //gameObject.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            yield return null;
        }
    }
}