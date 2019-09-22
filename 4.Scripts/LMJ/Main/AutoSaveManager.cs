using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class AutoSaveManager : MonoBehaviour
    {
        private string[] autodataArrays = new string[11]; // 11개의 데이터 스트링 배열 생성

        private void Start()
        {
          Init();
        }

        public string AutoSaveUpdate()
        {
            // 현재 씬 데이터 가져와서 오토세이브데이터 어레이에서 순회하면서 찾고 그 데이터 키값을 반환
            return null;
        }

        public string AutoSaveDataSetting()
        {
            // 현재 씬 데이터 가져와서 오토세이브데이터 어레이에서 순회하면서 찾고 그 데이터 키값을 넣어줌
            return null;
        }
        
        private void Init()
        {
            //11개의 게임 데이터는 이곳만 수정하면 스코어 변경.
            
        }
    }
}

