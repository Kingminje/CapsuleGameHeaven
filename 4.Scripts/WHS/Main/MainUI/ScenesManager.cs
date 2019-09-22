using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static bool IsMinigameUIed = false;
    private void Awake()
    {
        if (!IsMinigameUIed)
        {
            SceneManager.LoadScene("MinigameUI", LoadSceneMode.Additive);
            Debug.Log("Scenemanager >> Awake");
            IsMinigameUIed = true;
        }
    }

}