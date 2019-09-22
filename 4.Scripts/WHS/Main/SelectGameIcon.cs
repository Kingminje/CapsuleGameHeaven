using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameIcon : MonoBehaviour
{
    public GameObject[] StagePanels = null;

    public int currentStagenum = 0;

    public void IconSelectStage(int stageNum)
    {
        if (stageNum == currentStagenum)
        {
            return;
        }
        else
        {
            StageSet(currentStagenum, stageNum);
            currentStagenum = stageNum;
        }
    }

    private void StageSet(int regen, int change)
    {
        StagePanels[regen].SetActive(false);
        StagePanels[change].SetActive(true);
    }
}