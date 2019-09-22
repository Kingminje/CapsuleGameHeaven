using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{
    public float rotationSpeed = 180;
    public float speed = 3;
    public float z_offset = 0;
    private int v = 1;

    public int itemNum = 0;

    public List<GameObject> tailObjects = new List<GameObject>();
    private SnakeGameManager manager;
    private MJ.SoundManager sm;
    private Combo combo;

    //public GameObject[] tailPrefab;

    // Use this for initialization
    private void Start()
    {
        tailObjects.Add(gameObject);
        manager = GameObject.Find("GameController").GetComponent<SnakeGameManager>();
        sm = FindObjectOfType<MJ.SoundManager>();
        combo = FindObjectOfType<Combo>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * v * rotationSpeed * Time.deltaTime);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
#if UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject()
#else
        if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)

#endif
         && Input.GetMouseButtonDown(0) && Time.timeScale == 1)
            {
                v *= -1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == ("Player1_item(Clone)"))
        {
            itemNum = 2;
            manager.AddTail();
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            Destroy(other.gameObject);
        }
        else if (other.name == ("Player3_item(Clone)"))
        {
            itemNum = 3;
            manager.AddTail();
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            Destroy(other.gameObject);
        }
        else if (other.name == ("Player4_item(Clone)"))
        {
            itemNum = 4;
            manager.AddTail();
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            Destroy(other.gameObject);
        }
        else if (other.name == ("Player5_item(Clone)"))
        {
            itemNum = 5;
            manager.AddTail();
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            Destroy(other.gameObject);
        }
        else if (other.name == ("Player6_item(Clone)"))
        {
            itemNum = 6;
            manager.AddTail();
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            Destroy(other.gameObject);
        }
        else if (other.name == ("Player7_item(Clone)"))
        {
            itemNum = 7;
            manager.AddTail();
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Minus")
        {
            if (tailObjects.Count == 1)
            {
                combo.ScoreUp(10);
                Destroy(other.gameObject);
                return;
            }
            Destroy(tailObjects[tailObjects.Count - 1]);
            tailObjects.RemoveAt(tailObjects.Count - 1);

            //manager.AddTail();
            combo.ScoreUp(10);
            sm.SoundPlay((int)MJ.AudioClipName.Item);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Border"))
        {
            manager.GameOver();
        }

        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<TailMovement>().index > 2)
                manager.GameOver();
        }
    }
}