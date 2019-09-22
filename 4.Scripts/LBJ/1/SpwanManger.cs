using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpwanManger : MonoBehaviour
{
    public GameObject _spwanWallPrefab;

    public Transform[] pos1;
    public Transform[] pos2;
    public Transform[] pos3;
    public Transform[] pos4;
    public Transform[] pos5;

    private Combo combo;

    private int roundCount = 0;
    private int level = 1;

    private int _randomValue = 0;

    public int randomValue
    {
        get
        {
            _randomValue = Random.Range(0, 2);
            return _randomValue;
        }
    }

    //public Transform[] starpos1;
    //public Transform[] starpos2;
    //public Transform[] starpos3;
    //public Text rText;
    //public GameObject[] stars;
    //public Transform spwanBlcokPointTaget;

    public void Start()
    {
        combo = FindObjectOfType<Combo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " : trigger Enter");

        GarbageDestroyObj();

        //roundCount++;
        //rText.text = roundCount.ToString();

        combo.ScoreUp(10);

        if (roundCount % 5 == 0)
        {
            level++;

            if (level > 3)
            {
                level = 1;
                RollRaod.n = RollRaod.n + 0.2f;
            }
        }

        SpwanBox();
        //SpwanStar();
    }

    public void GarbageDestroyObj()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Box"))
        {
            Destroy(obj, 0.1f);
        }
        //foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
        //{
        //    Destroy(star, 0.1f);
        //}
    }

    public void SpwanBox()
    {
        switch (level)
        {
            case 1:
                Instantiate(_spwanWallPrefab, pos1[randomValue]);
                Instantiate(_spwanWallPrefab, pos2[randomValue]);
                Instantiate(_spwanWallPrefab, pos3[randomValue]);
                break;

            case 2:
                Instantiate(_spwanWallPrefab, pos1[randomValue]);
                Instantiate(_spwanWallPrefab, pos2[randomValue]);
                Instantiate(_spwanWallPrefab, pos3[randomValue]);
                Instantiate(_spwanWallPrefab, pos4[randomValue]);
                break;

            case 3:
                Instantiate(_spwanWallPrefab, pos1[randomValue]);
                Instantiate(_spwanWallPrefab, pos2[randomValue]);
                Instantiate(_spwanWallPrefab, pos3[randomValue]);
                Instantiate(_spwanWallPrefab, pos4[randomValue]);
                Instantiate(_spwanWallPrefab, pos5[randomValue]);
                break;
        }
    }
}

//public void SpwanStar()
//{
//    GameObject star =
//                stars[Random.Range(0, stars.Length)];
//    int randomValue = this.randomValue;

//    switch (level)
//    {
//        case 1:
//            Instantiate(star, starpos1[randomValue]);
//            break;

//        case 2:
//            Instantiate(star, starpos1[randomValue]);
//            Instantiate(star, starpos2[randomValue]);

//            break;

//        case 3:
//            Instantiate(star, starpos1[randomValue]);
//            Instantiate(star, starpos2[randomValue]);
//            Instantiate(star, starpos3[randomValue]);

//            break;
//    }
//}

//if (spwanBlcokPointTaget != null)
//{
//    spwanBlockPoints = new Transform[spwanBlcokPointTaget.childCount][];
//    spwanBlockPoints = SettingSpwanBlcokPoints();
//}

//public Transform[][] SettingSpwanBlcokPoints()
//{
//    var tmpTr = spwanBlcokPointTaget.transform;

//    for (int i = 0; i < spwanBlcokPointTaget.childCount; i++) // 이거 자식의 자식 카운터도 가져오는지 확인
//    {
//        if (tmpTr.GetChild(i).transform != null)
//        {
//            Debug.Log(tmpTr.GetChild(i).transform.name);
//            spwanBlockPoints[i][i] = transform;
//            spwanBlockPoints[i][i + 1] = tmpTr.GetChild(i).transform;
//        }
//    }

//    return null;
//}