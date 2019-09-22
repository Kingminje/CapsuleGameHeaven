using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using whs;

/// <summary>
/// 선택한 플레이어를 생성해줍니다
/// </summary>
public class CreatePlayer : MonoBehaviour
{
    // 각게임의 GameManager 에다가 player변수를 만들어 놓고
    // CreatePlayer.player을 참조시키면  선택한 캐릭터가 나옵니다
    //거기에다가 SettingPlayer같은 메서드를 만들어서 필요한 스크립트를 Add컴포넌트로 추가해서 start에불르면 됩니다.

    /// <예시>
    ///  private void SettingPlayer()
    //{
    //    player = CreatePlayer.player;
    //    player.transform.position = Vector3.zero;
    //    player.AddComponent<PlayerMovement>();
    //    player.AddComponent<Rigidbody>();
    //
    /// </summary>
    [SerializeField]
    public static GameObject player = null;

    public string PlayerName = "Player";

    private void Awake()
    {
        player = Instantiate(MainGameManager.selectedPlayer); // 메인게임매니저에서 선택된 플레이어를 넣음.
                                                              //       player.tag = "Player"; // 플레이어 테그 설정
                                                              
        Debug.Log(MainGameManager.selectedPlayer.gameObject.name); // 디버그로 무슨 캐릭터 어떤것이 들어갔는지 출력
        player.transform.SetParent(GameObject.FindWithTag("Player").transform, false);
        player.transform.localPosition = Vector3.zero;
        Debug.Log("CreatePlayer");
    }

    private void Start()
    {
        

        //for (int i = 0; i < 2; i++)
        //{
        //    var tmpPlayer = Instantiate(player, player.transform.parent, false);
        //    tmpPlayer.GetComponent<CapsuleCollider>().enabled = true;
        //    tmpPlayer.transform.tag = PlayerName;
        //    if (i == 0)
        //    {
        //        tmpPlayer.transform.localPosition = new Vector3(0f, 0f, -9f);
        //    }
        //    else
        //    {
        //        tmpPlayer.transform.localPosition = new Vector3(0f, 0f, 9f);
        //    }
        //}
    }
}