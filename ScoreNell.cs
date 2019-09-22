using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNell : MonoBehaviour
{
    private void Start()
    {
        PlayerData_Delete();
    }

    private void PlayerData_Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}