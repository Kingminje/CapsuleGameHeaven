using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMove : MonoBehaviour
{
    private const float MAX_XPOS = 3f;

    private const int MAX_CAMERA_CNT = 7;

    public float moveSpeed = 5f;
    public float maxSpeed = 14f;
    static public float correctionValue = 0f;
    private readonly float addSpeed = 0.5f;

    private Vector2 direction = Vector2.right;
    private Vector3 resetPos = new Vector3(0, 3.5f, 0);
    private Vector3 upDir = new Vector3(0, 0.5f, 0);

    private void OnEnable()
    {
        BoxGameManager.onLandDele += MoveUp;
        BoxGameManager.onRestartGame += GameRestart;
    }

    private void OnDisable()
    {
        BoxGameManager.onLandDele -= MoveUp;
        BoxGameManager.onRestartGame -= GameRestart;
    }

    private void Start()
    {
        GameRestart();
    }

    private void MoveUp()
    {
        if (Combo.score >= MAX_CAMERA_CNT)
            transform.position += upDir;
    }

    public void GameRestart()
    {
        StopAllCoroutines();

        transform.position = resetPos;

        moveSpeed = 5f;

        StartCoroutine(MoveGenerator());

        StartCoroutine(ChageSpeed());
    }

    private IEnumerator MoveGenerator()
    {
        while (!BoxGameManager.isGameOver)
        {
            if (transform.position.x >= (MAX_XPOS + correctionValue))
            {
                direction = Vector2.left;
            }
            else if (transform.position.x <= -(MAX_XPOS + correctionValue))
            {
                direction = Vector2.right;
            }
            transform.Translate(moveSpeed * direction * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator ChageSpeed()
    {
        while (moveSpeed <= maxSpeed)
        {
            yield return new WaitForSeconds(5f);
            moveSpeed += addSpeed;
        }
    }
}