using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class MainGameManager : MonoBehaviour
    {
        private static MainGameManager Instance = null;
        
        public Image RankingPanel;
        public Image OptionPanel;
        public Image CharacterPanel;
        public Image GameSelectPanel;
        public Image SettingPanel;
        public static GameObject selectedPlayer;

        public SelectCharacter sc;

        public static string infoKey = "Player";

        private void Awake()
        {
            Instance = this;
        }

        public static MainGameManager GetInstance()
        {
            return Instance;
        }

        private void Start()
        {
            InitPanel();
            LoadPrevPlayerInfo(PlayerPrefs.GetInt(infoKey));
        }

        private void LoadPrevPlayerInfo(int prevPlayerIndex)
        {
            Debug.Log("LoadPrevPlayerInfo >> PlayerIndex : " + prevPlayerIndex);

            selectedPlayer = sc.playerList[prevPlayerIndex];

            SelectCharacter.charaterIndex = prevPlayerIndex;
        }

        public static void SaveData()
        {
            PlayerPrefs.SetInt(infoKey, SelectCharacter.charaterIndex);

            Debug.Log(SelectCharacter.charaterIndex);
        }

        public void OnClickSetting()
        {
            if (GameSelectPanel.gameObject.activeSelf || CharacterPanel.gameObject.activeSelf || OptionPanel.gameObject.activeSelf || SettingPanel.gameObject.activeSelf) return;
            SettingPanel.gameObject.SetActive(true);
        }

        public void OnClickRanking()
        {
            if (GameSelectPanel.gameObject.activeSelf || CharacterPanel.gameObject.activeSelf || OptionPanel.gameObject.activeSelf || SettingPanel.gameObject.activeSelf) return;
            RankingPanel.gameObject.SetActive(true);
        }

        public void OnClickOption()
        {
            if (GameSelectPanel.gameObject.activeSelf || CharacterPanel.gameObject.activeSelf || RankingPanel.gameObject.activeSelf || SettingPanel.gameObject.activeSelf) return;
            OptionPanel.gameObject.SetActive(true);
            //ADManager.AD_Show();
        }

        public void OnClickCharacter()
        {
            if (GameSelectPanel.gameObject.activeSelf) return;
            CharacterPanel.gameObject.SetActive(true);
        }

        public void OnClickGame()
        {
            if (CharacterPanel.gameObject.activeSelf) return;
            GameSelectPanel.gameObject.SetActive(true);
        }

        public void OnClickBack()
        {
            InitPanel();
        }

        private void InitPanel()
        {
            Debug.Log("MainGameManager : InitPanels");
            RankingPanel.gameObject.SetActive(false);
            OptionPanel.gameObject.SetActive(false);
            SettingPanel.gameObject.SetActive(false);
        }

    }
}