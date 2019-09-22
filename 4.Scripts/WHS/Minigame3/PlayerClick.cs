using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using whs;

public class PlayerClick : MonoBehaviour
{
    public float clickDelay = 0.7f;
    public static float currentTime = 0;

    private float lastClickTime = 0;

    public static float clickTime = 0f;

    public GameObject arrowPointer;

    private void Start()
    {
        arrowPointer = GameObject.Find("ArrowPointer");

        arrowPointer.gameObject.SetActive(false);
    }

    private void Update()
    {
        currentTime = Time.time;
        if (Input.GetMouseButtonDown(0) && !ColorGameManager.isClickDelay &&
#if UNITY_EDITOR
            !EventSystem.current.IsPointerOverGameObject())
#else
            !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
        {
            //델리게이트 여쭤보기
            if (currentTime > lastClickTime + clickDelay)
            {
                ColliderSetTrue();
                lastClickTime = currentTime;
                clickTime = 0f;
            }
        }
    }

    private void ColliderSetTrue()
    {
        arrowPointer.gameObject.SetActive(true);

        //  arrowPointer.gameObject.SetActive(false);
    }
}