using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxParent : MonoBehaviour
{
    private List<GameObject> boxList = new List<GameObject>();

    private void OnEnable()
    {
        BoxGameManager.onRestartGame += GameOver;
    }

    private void OnDisable()
    {
        BoxGameManager.onRestartGame -= GameOver;
    }

    public void AddBox(GameObject box)
    {
        boxList.Add(box);
    }

    private void GameOver()
    {
        foreach (GameObject box in boxList)
        {
            Destroy(box);
        }
    }
}