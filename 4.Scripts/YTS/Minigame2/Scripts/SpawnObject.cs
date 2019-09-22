using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Vector3 curPos;

    public float xSize = 3.5f;
    public float ySize = 0;
    public float zSize = 7.5f;

    public GameObject curItem;
    public float cnt;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void AddNewItem()
    {
        RandomPos();
        GameObject enemy =
                    itemPrefab[Random.Range(0, itemPrefab.Length)];
        curItem = GameObject.Instantiate(enemy, curPos, enemy.transform.rotation) as GameObject;
    }

    public void RandomPos()
    {
        curPos = new Vector3(Random.Range(xSize * -1, xSize), player.transform.position.y - ySize, Random.Range(zSize * -1, zSize));
    }

    private void Update()
    {
        if (!curItem)
        {
            cnt += Time.deltaTime * 1;
            if (cnt > 1.5f)
                AddNewItem();
        }
        else
        {
            cnt = 0;
            return;
        }
    }
}