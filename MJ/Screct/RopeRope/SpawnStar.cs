using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Vector3 curPos;

    public float xSize = 3.5f;
    public float ySize = 0;
    public float zSize = 7.5f;

    public GameObject curItem;
    public float cnt;

    public float time;

    private void Start()
    {
    }

    private void AddNewItem()
    {
        RandomPos();
        GameObject enemy =
                    itemPrefab[Random.Range(0, itemPrefab.Length)];
        curItem = GameObject.Instantiate(enemy, curPos, enemy.transform.rotation) as GameObject;
        enemy.GetComponent<DestroyByTime>().lifetime = time;
    }

    public void RandomPos()
    {
        curPos = new Vector3(Random.Range(xSize * -1, xSize), ySize, Random.Range(zSize * -1, zSize));
    }

    private void Update()
    {
        if (!curItem)
        {
            cnt += Time.deltaTime * 1;
            if (cnt > 2f)
                AddNewItem();
        }
        else
        {
            cnt = 0;
            return;
        }
    }
}