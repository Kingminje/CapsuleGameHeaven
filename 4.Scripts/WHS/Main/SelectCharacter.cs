using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class SelectCharacter : MonoBehaviour
    {
        //  public GameObject[] players;

        public List<GameObject> playerList = new List<GameObject>();

        /// <summary>
        /// 선택된 캐릭터 버튼의 자식으로 하나씩 있는 이미지들의 배열
        /// </summary>
        public List<Image> SelectedImage = new List<Image>();

        public static GameObject selectedCharacter;

        public static Quaternion tmpTr;
        /// <summary>
        /// 이전 선택 된 캐릭터 이미지
        /// </summary>
        private Image currentSelect = null;

        private Vector3 setPosInUI = new Vector3(0, -3f, 2);

        public static int charaterIndex = 0;
        private int tmpIndex;
        private int buttonCnt = 0;

        public Vector3 clickPos;

        /// <summary>
        /// UGUI에서 캐릭터 이미지 버튼UI 터치 시 작동
        /// </summary>
        /// <param name="index">클릭된 캐릭터의 인트값</param>
        public void OnClickCharater(int index)
        {
            if (buttonCnt != 0)
                return;

            buttonCnt++;

            ShowSelectImg(index);

            ShowPlayerInUI(playerList[index], index);

            tmpIndex = index;
        }
        /// <summary>
        /// 클릭된 캐릭터 버튼의 자식의 이미지 게임오브젝트를 켠다.
        /// </summary>
        /// <param name="index">클릭된 캐릭터 자식 위치</param>
        private void ShowSelectImg(int index)
        {
            // 이전에 캐릭터 버튼을 눌러서 캐릭터 자식으로 있는 이미지의 체크가 켜져있을 때
            if (currentSelect != null)
            {
                currentSelect.gameObject.SetActive(false); // 이전 체크 이미지의 게임 오브젝트를 꺼라
            }
            SelectedImage[index].gameObject.SetActive(true);// 캐릭터 체크 이미지를 켜라.
            currentSelect = SelectedImage[index];
        }

        public void OnClickSelect()
        {
            if (buttonCnt != 0)
                return;

            charaterIndex = tmpIndex;

            MainGameManager.SaveData();

            MainGameManager.selectedPlayer = playerList[charaterIndex];

            Destroy(selectedCharacter);

            gameObject.SetActive(false);
        }

        public void OnClickBack()
        {
            if (buttonCnt != 0)
                return;

            gameObject.SetActive(false);

            Destroy(selectedCharacter);
        }
        /// <summary>
        /// 캐릭터 버튼 클릭 시 작동하는 UI메소드
        /// </summary>
        /// <param name="newCharacter"></param>
        /// <param name="index"></param>
        private void ShowPlayerInUI(GameObject newCharacter, int index)
        {
            // 선택된 캐릭터가 없다면..
            if (selectedCharacter == null)
            {                
                selectedCharacter = Instantiate(newCharacter); //바로 인풋된 캐릭터를 생성하고
                SetCharacterComponent(selectedCharacter); // 위치에 넣는다.
                buttonCnt = 0; // 다시 버튼 눌리도록 변경
            }
            else
            {
                tmpTr = selectedCharacter.GetComponent<CharaterLotate>().characterLoatate;
                Destroy(selectedCharacter);

                selectedCharacter = Instantiate(newCharacter);
                //Destroy(newCharacter);
                SetCharacterComponent(selectedCharacter);
                buttonCnt = 0;
                //CharacterChange(newCharacter, index); 19/09/20수정 사유: 캐릭터 이동 시 이상함 수정자: 민제
            }
        }

        private void SetCharacterComponent(GameObject selectedCharacter)
        {
            selectedCharacter.transform.position = setPosInUI;

            selectedCharacter.AddComponent<CharaterLotate>();

            selectedCharacter.GetComponent<CharaterLotate>().characterLoatate = tmpTr;
        }

        private IEnumerator PlayerSetCoroutine(GameObject newCharacter)
        {
            yield return new WaitUntil(() => newCharacter.GetComponent<SelectAnimation>().isEndMove);

            tmpTr = selectedCharacter.GetComponent<CharaterLotate>().characterLoatate;

            Destroy(selectedCharacter);

            selectedCharacter = Instantiate(newCharacter);

            Destroy(newCharacter);

            SetCharacterComponent(selectedCharacter);

            buttonCnt = 0;
        }

        private void CharacterChange(GameObject obj, int index)
        {
            GameObject newCharacter = Instantiate(obj); //변경을 위한 캐릭터

            newCharacter.AddComponent<SelectAnimation>().PlayNewCharacterAnim(index);

            StartCoroutine("PlayerSetCoroutine", newCharacter);
        }
    }
}