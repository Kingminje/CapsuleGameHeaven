using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMove : MonoBehaviour
{
    // 이동 가능 영역
    public Boundary boundary;

    // 회전 각도
    public float tilt;

    // 피하기 속도
    public float dodge;

    // 보간 수치
    public float smoothing;

    // 시작 지연 시간
    public Vector2 startWait;

    // 피하기 동작 유지 시간
    public Vector2 sideMoveTime;

    // 직성 이동 유지 시간
    public Vector2 directMoveTime;

    // 수직 이동 속도
    private float vertiSpeed;

    // 수평 이동 속도
    private float horiSpeed;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    private void Start()
    {
        vertiSpeed = rigidBody.velocity.y;

        StartCoroutine("SideMoveCoroutine");
    }

    private IEnumerator SideMoveCoroutine()
    {
        // 랜덤 시작 지연 처리 (최소, 최대)
        yield return new WaitForSeconds(Random.Range
            (startWait.x, startWait.y));

        while (true)
        {
            // 피하기 랜덤 속도를 설정함
            horiSpeed = Random.Range(1, dodge)
                        * -Mathf.Sign(transform.position.x);

            // 피하기 이동을 랜덤 시간만큼 유지함
            yield return new WaitForSeconds(
                Random.Range(sideMoveTime.x, sideMoveTime.y)
            );

            horiSpeed = 0;

            // 직성 이동 랜덤 시간을 부여함
            yield return new WaitForSeconds(
                Random.Range(directMoveTime.x, directMoveTime.y));
        }
    }

    private void FixedUpdate()
    {
        // 수평 이동 속도 설정
        float newHoriSpeed = Mathf.MoveTowards(
            rigidBody.velocity.x, horiSpeed,
            smoothing * Time.deltaTime
        );

        // 수평 + 수직 이동을 수행함
        rigidBody.velocity = new Vector3(newHoriSpeed, vertiSpeed, 0);

        rigidBody.position =
                    new Vector3(
                        // Mathf.Clamp(측정값, 최소값, 최대값)
                        // -> 측정값이 경계를 넘을 경우 최소/최대값으로 고정함
                        Mathf.Clamp(rigidBody.position.x,
                        boundary.xMin, boundary.xMax),
                        Mathf.Clamp(rigidBody.position.y,
                        boundary.zMin, boundary.zMax),
                        0f
                    );

        //rigidBody.rotation = Quaternion.Euler(0f, rigidBody.velocity.x * tilt, 0f);
    }
}