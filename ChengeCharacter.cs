using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public partial class CreateMonster : MonoBehaviour
    {
        public GameObject[] MonsterPrefabs;

        /// <summary>
        /// 몬스터 게임오브젝트를 받아서 랜덤한 스킨을 입혀줌
        /// </summary>
        /// <param name="Monster"></param>
        private GameObject ChangesMonsterSet()
        {
            var randomValue = Random.Range(0, 5);

            var MonsterSkin = Instantiate(MonsterPrefabs[randomValue], transform, false);

            MonsterSkin.transform.localPosition = Vector3.zero;

            return MonsterSkin;
        }
    }
}