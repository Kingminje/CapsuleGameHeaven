using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public float time;
    public ParticleSystem effect;
    private EvadeGameManager manager;

    // Use this for initialization
    private void Start()
    {
        manager = GameObject.Find("GameController").GetComponent<EvadeGameManager>();

        StartCoroutine(PositionChange());
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
    }

    private IEnumerator PositionChange()
    {
        while (true)
        {
            if (time >= 2.0f)
            {
                // 이펙트 추가
                effect.Play();
                gameObject.GetComponent<Transform>().localPosition = new Vector3(Random.Range(-manager.spawnValues.x,
                    manager.spawnValues.x), transform.position.y, transform.position.z);
                time = 0f;
            }

            yield return null;
        }
    }
}