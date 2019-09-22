using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public partial class CreateMonster : MonoBehaviour
    {
        public GameObject[] genPoints;
        public GameObject monsterPrefab;
        public int maxgenPoins = 2;

        public float genDelayTime = 3f;

        private float time;

        //private void GenPointsSetting()
        //{
        //    genPositions = new Vector3[maxgenPoins];

        //    for (int i = 0; i < maxgenPoins; i++)
        //    {
        //        genPositions[i] = genPoints[i].transform.position;
        //    }
        //}

        private void Start()
        {
            StartCoroutine(MonsterCreateCoroutine());
        }

        private void Update()
        {
            time += Time.deltaTime;

            if (time > 10f)
            {
                if (genDelayTime > 1f)
                {
                    Debug.LogFormat("딜레이 -1, {0}", (int)genDelayTime);
                    genDelayTime -= 1f;
                    time = 0f;
                }
                else if (genDelayTime > 0.5f)
                {
                    Debug.LogFormat("딜레이 -1, {0}", (int)genDelayTime);
                    genDelayTime -= 0.1f;
                    time = 0f;
                }
            }
        }

        private IEnumerator MonsterCreateCoroutine()
        {
            var tempPoint = genPoints[SelectGenPosition()].transform.position;

            var monster = Instantiate(monsterPrefab, tempPoint, Quaternion.identity);

            if (genDelayTime < 1f)
            {
                var tmpSpeedValue = monster.GetComponent<DirectMovement>();
                tmpSpeedValue.speed = Random.Range(1f, 5.5f);
                Debug.Log(tmpSpeedValue);
            }

            var tempGameobject = ChangesMonsterSet();

            tempGameobject.transform.SetParent(monster.transform);

            tempGameobject.transform.localPosition = Vector3.zero;

            if (tempPoint.x < 0)
                tempGameobject.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
            else
                tempGameobject.transform.localEulerAngles = new Vector3(0f, -90, 0f);

            yield return new WaitForSeconds(genDelayTime);

            StartCoroutine(MonsterCreateCoroutine());
        }

        private int SelectGenPosition()
        {
            int randoemcheck = Random.Range(0, 2);

            Debug.Log(randoemcheck);

            return randoemcheck;
        }
    }
}