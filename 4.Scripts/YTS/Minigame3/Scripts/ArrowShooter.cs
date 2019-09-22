using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    private Transform bowPos;
    private float throwForce = 10f;
    private float cooltime = 0;

    private MJ.SoundManager sm;

    public static bool trggerDelay = false;
    public string[] Tagetnames = new string[3] { "Star", "Border", "Enemy" };

    // Use this for initialization
    private void Start()
    {
        trggerDelay = false;
        bowPos = GameObject.Find("BowShotPos").GetComponent<Transform>();
        sm = FindObjectOfType<MJ.SoundManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        //cooltime += Time.deltaTime;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
#if UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject()
#else
        if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)
#endif
            && Input.GetMouseButtonDown(0) && trggerDelay == false && Time.timeScale == 1)
            {
                //cooltime = 0;
                trggerDelay = true;
                GameObject arrow = Instantiate(arrowPrefab, bowPos.position, bowPos.rotation);
                Rigidbody rb = arrow.GetComponent<Rigidbody>();
                var tmpScript = arrow.GetComponent<DestroyByStar>();
                tmpScript.Tagets = Tagetnames;
                rb.AddForce(bowPos.up * throwForce, ForceMode.VelocityChange);
                sm.SoundPlay((int)MJ.AudioClipName.Bow);
            }
        }
    }
}