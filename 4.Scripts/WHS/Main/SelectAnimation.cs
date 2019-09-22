using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnimation : MonoBehaviour
{
    public Vector3 newPlayerPos;
    private Vector3 destination = new Vector3(0f, -3f);
    private Vector3 direction;

    public bool isEndMove = false;

    private const float setXPos = 0.3f;

    public void PlayNewCharacterAnim(int index)
    {
        switch (index)
        {
            case 1:
                newPlayerPos = new Vector3(-2.5f, 6f);
                break;

            case 2:
                newPlayerPos = new Vector3(0f, 6f);
                break;

            case 3:
                newPlayerPos = new Vector3(2.5f, 6f);
                break;

            case 4:
                newPlayerPos = new Vector3(-2.5f, 2f);
                break;

            case 5:
                newPlayerPos = new Vector3(0f, 2f);
                break;

            case 6:
                newPlayerPos = new Vector3(2.5f, 2f);
                break;
        }

        gameObject.transform.position = newPlayerPos;
        gameObject.transform.rotation = new Quaternion(0, 180f, 0f, 0f);

        StartCoroutine(NewCharacterAnimationCoroutine());
        StartCoroutine(Down());
    }

    private IEnumerator NewCharacterAnimationCoroutine()
    {
        direction = (destination - transform.position) * 0.05f;
        while (!isEndMove)
        {
            if (transform.position.y < -2.5f)
            {
                isEndMove = true;
            }
            transform.position = transform.position + direction;
            yield return null;
        }
        Debug.Log("NewCharacterAnimationCoroutine >> End");
    }

    private IEnumerator Down()
    {
        yield return new WaitUntil(() => isEndMove);
        Debug.Log("downCorountine");
    }
}