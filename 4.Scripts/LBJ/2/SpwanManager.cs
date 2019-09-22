using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace lbj
{
    public class SpwanManager : MonoBehaviour
    {
        public Renderer material = null;
        private Color okColor = Color.red;
        private Color noColor = Color.blue;

        public Image okImage, noImage;

        public Text pointText;

        public Transform[] pos;
        static private Transform SpwanStartPos = null;

        public GameObject[] target;
        private Vector3 moveVector;
        public bool test_GoChangeTrigger;

        //public GameObject panel;
        static public bool isSpwan;

        static public float sTime = 2f;
        static public float moveSpeed = 10f;
        public float count = 0;

        private int randpoint = 70;

        public Color Ok
        {
            get { return okColor; }
            set { okColor = value; }
        }

        public Color No
        {
            get { return noColor; }
            set { this.noColor = value; }
        }

        private void Awake()
        {
            //panel.GetComponent<GameObject>();
            material = GameObject.FindGameObjectWithTag("Box").GetComponent<Renderer>();
            SpwanStartPos = pos[0]; // 지속적 사용
            moveVector = pos[1].transform.position; // 두트윈 설정 위치
            isSpwan = true; // 생성 시작
            StartCoroutine(Spwaner()); // 오브젝트 생성 코루틴
        }

        private void Update()
        {
            //pointText.text = count.ToString();
            CheckOkNoImage(); // 색상 변경 시 자동으로 변경
            MovePrefab();

            if (isSpwan == false)
            {
                //panel.SetActive(true);
                StopCoroutine(Spwaner());
            }
        }

        public void CheckOkNoImage()
        {
            okImage.color = Ok;
            material.material.color = Ok;
            noImage.color = No;
        }

        public IEnumerator Spwaner()
        {
            yield return new WaitForSeconds(1f);

            while (isSpwan) // 생성 상태 확인 후 생성 시작
            {
                var randomValue = Random.Range(0, 2);
                if (randomValue == 0)
                {
                    test_GoChangeTrigger = true;
                    Ok = Color.blue;
                    No = Color.red;
                    //MakePrefab(); // 생성
                    MakeSpwanPrefab();
                    yield return new WaitForSeconds(sTime); // 딜레이?
                }
                else
                {
                    test_GoChangeTrigger = false;
                    Ok = Color.red;
                    No = Color.blue;
                    //MakePrefab(); // 생성
                    MakeSpwanPrefab();
                    yield return new WaitForSeconds(sTime); // 딜레이?
                }
            }
        }

        //public void MakePrefab()
        //{
        //    int rand = Random.Range(0, 100); // 랜덤 요소
        //    if (rand > randpoint)//randpoint = 70f 디폴트값
        //    {
        //        //Instantiate(target[1], pos[0].position, pos[0].rotation);
        //    }
        //    else if (rand <= randpoint && rand > 60)
        //    {
        //        //GameObject no = Instantiate(target[1], pos[0].position, pos[0].rotation) as GameObject;
        //        //no.GetComponent<Renderer>().material.DOColor(Color.blue, 0f);
        //    }
        //    else if (rand <= 60 && rand > 50)
        //    {
        //        //Instantiate(target[0], pos[0].position, pos[0].rotation);
        //    }
        //    else if (rand <= 50 && rand > 40)
        //    {
        //        //GameObject no = Instantiate(target[0], pos[0].position, pos[0].rotation) as GameObject;
        //        //no.GetComponent<Renderer>().material.DOColor(Color.red, 0f);
        //    }
        //    else if (rand <= 40 && rand > 30)
        //    {
        //        GameObject star = GameObject.Instantiate(target[2], pos[0].position, pos[0].rotation) as GameObject;
        //        star.transform.DOScale(0.4f, 0);
        //    }
        //    else if (rand <= 30 && rand > 20)
        //    {
        //        GameObject star = GameObject.Instantiate(target[3], pos[0].position, pos[0].rotation) as GameObject;
        //        star.transform.DOScale(0.4f, 0);
        //    }
        //    else if (rand <= 20 && rand > 10)
        //    {
        //        GameObject star = GameObject.Instantiate(target[4], pos[0].position, pos[0].rotation) as GameObject;
        //        star.transform.DOScale(0.4f, 0);
        //    }
        //    else
        //    {
        //        GameObject star = GameObject.Instantiate(target[5], pos[0].position, pos[0].rotation) as GameObject;
        //        star.transform.DOScale(0.4f, 0);
        //    }
        //}

        public void MakeSpwanPrefab()
        {
            //SpwanStartPos
            // 테스트 고 체인지 트리거가 트루라면 오브젝트가 나오면서 색상이 변경 되어서는 안된다.
            // 펄스 일때만 작동
            if (test_GoChangeTrigger == true)
            {
                var randomValue = Random.Range(0, 2);
                if (randomValue == 0)
                {
                    var ok_go = Instantiate(target[0], SpwanStartPos.position, SpwanStartPos.rotation) as GameObject;
                    ok_go.GetComponent<Renderer>().material.color = Ok;
                    // 플레이어 컨트롤하는 박스의 색이 변경된 상태
                    // 색상 변경 없이 go
                }
                else
                {
                    var no_go = Instantiate(target[0], SpwanStartPos.position, SpwanStartPos.rotation) as GameObject;
                    no_go.GetComponent<Renderer>().material.color = No;
                    // 플레이어 컨트롤하는 박스의 색이 변경된 상태
                    // 색상 변경 없이 go
                }
            }
            else // false
            {
                var randomValue = Random.Range(0, 2);
                // 생성되는 타겟의 색이 변경이 된다.
                if (randomValue == 0)
                {
                    var ok_go = Instantiate(target[0], SpwanStartPos.position, SpwanStartPos.rotation) as GameObject;
                    // 플레이어 컨트롤하는 박스의 색이 변경이 안되는 상태
                    ok_go.GetComponent<Material>().DOColor(Ok, 0f);
                    // 색상 도중 변경
                }
                else
                {
                    var no_go = Instantiate(target[0], SpwanStartPos.position, SpwanStartPos.rotation) as GameObject;
                    // 플레이어 컨트롤하는 박스의 색이 변경이 안되는 상태
                    no_go.GetComponent<Material>().DOColor(No, 0f);
                    // 색상 도중 변경
                }
                // 혹은 그대로
            }
        }

        public void MovePrefab()
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                obj.transform.DOMove(moveVector, moveSpeed);
                if (obj.GetComponent<Renderer>().material.color == Color.blue)
                {
                    count += Time.deltaTime;
                    if (count > 1f)
                    {
                        obj.GetComponent<Renderer>().material.DOColor(Color.red, 0f);
                        count = 0;
                    }
                }
            }
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Coin"))
            {
                obj.transform.DOMove(moveVector, moveSpeed);
                if (obj.GetComponent<Renderer>().material.color == Color.red)
                {
                    count += Time.deltaTime;
                    if (count > 1f)
                    {
                        obj.GetComponent<Renderer>().material.DOColor(Color.blue, 0f);
                        count = 0;
                    }
                }
            }
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
            {
                star.transform.DOMove(moveVector, moveSpeed);
            }
        }
    }
}