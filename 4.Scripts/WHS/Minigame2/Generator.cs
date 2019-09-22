using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Generator : MonoBehaviour
{
    public Transform genPos;

    public GameObject box;

    public GameObject newBox;

    public static bool IsLanded = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            !BoxGameManager.isGameOver && IsLanded &&
#if UNITY_EDITOR
            !EventSystem.current.IsPointerOverGameObject())
#else
            !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
        {
            CreateObj();
        }
    }

    private void CreateObj()
    {
        if (BoxGameManager.GetInstance().currentBox == null)
            BoxGameManager.GetInstance().currentBox = box;

        newBox = Instantiate(BoxGameManager.GetInstance().currentBox, genPos.position, Quaternion.identity);
        newBox.gameObject.tag = "Box";

        IsLanded = !IsLanded;
    }
}