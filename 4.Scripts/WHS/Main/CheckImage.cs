using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Main;

public class CheckImage : MonoBehaviour, IPointerClickHandler
{
    public GameObject checkImg;

    public int sceneNum;

    private RectTransform rt;

    private VideoPlayerManager videoPlayerManager;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        videoPlayerManager = GameObject.Find("VideoPlayerManager").GetComponent<VideoPlayerManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (checkImg.activeSelf == false)
            checkImg.SetActive(true);

        //rt.localPosition += new Vector3(0f, 10f, 0f);
        checkImg.GetComponent<RectTransform>().anchoredPosition = (rt.anchoredPosition + new Vector2(-110f, 220f));

        videoPlayerManager.GetSceneNum(sceneNum);
    }
}