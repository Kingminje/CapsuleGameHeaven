using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
// 이동 경계 영역
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

// 플레이어 컨트롤러
public class PlayerMovement : MonoBehaviour
{
    // 이동 속도
    public float speed = 5f;
    private bool isDelay;
    
    private Transform leftSide;
    private Transform rightSide;
    

    private EvadeGameManager manager;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        manager = GameObject.Find("GameController").GetComponent<EvadeGameManager>();
        leftSide = GameObject.Find("LeftSide").GetComponent<Transform>();
        rightSide = GameObject.Find("RightSide").GetComponent<Transform>();
        //transform.position = new Vector3(0, -6, 0);
    }

    private void Update()
    {
        // 이동 속도 지정
        playerRigidbody.velocity =
            transform.forward * speed;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // 시간 시간뒤 발포키를 눌렀다면
#if UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject()
            && (Input.GetMouseButtonDown(0) && Time.timeScale == 1))
            {
                playerRigidbody.rotation *= Quaternion.Euler(0, 180f, 0);
                playerRigidbody.velocity = transform.forward * -speed;
                
            }
#else

            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)
                && (Input.anyKey && Time.timeScale == 1))
            {
                playerRigidbody.rotation *= Quaternion.Euler(0, 180f, 0);
                playerRigidbody.velocity = transform.forward * -speed;
            }

#endif

            if (Vector3.Distance(transform.position, rightSide.position) < 0.3f && !isDelay)
            {
                isDelay = true;
                transform.position = leftSide.position;
                StartCoroutine(DelayPosition());
            }
            else if (Vector3.Distance(transform.position, leftSide.position) < 0.3f && !isDelay)
            {
                isDelay = true;
                transform.position = rightSide.position;
                StartCoroutine(DelayPosition());
            }
        }
    }

    private IEnumerator DelayPosition()
    {
        yield return new WaitForSeconds(0.3f);
        isDelay = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LeftSide")
        {
            transform.position = new Vector3(4.5f, -6f, 0);
        }
        else if (other.name == "RightSide")
        {
            transform.position = new Vector3(-4.5f, -6f, 0);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == (tagList[0]))
    //    {
    //        transform.position = new Vector3(5f, -6f, 0);
    //        isDelay = true;

    //        //if (transform.localPosition.x)
    //        //{
    //        //    //playerOffsetSaveValue += 9f;
    //        //}
    //        //isDirection = true;
    //    }
    //    else if (other.name == (tagList[1]))
    //    {
    //        transform.position = new Vector3(-5f, -6f, 0);
    //        isDelay = true;
    //        //if (transform.localPosition.x > 17f)
    //        //{
    //        //    //isDirection = true;
    //        //    //playerOffsetSaveValue -= 9f;
    //        //}
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (isDirection == true && other.name.CompareTo(tagList) != 1)
    //    {
    //        isDirection = false;
    //    }
    //}
}