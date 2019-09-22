using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlayerController : MonoBehaviour
{
    private GameObject player = null;

    private CharacterSound characterSound;

    public AudioClip jumpSound;

    private void Start()
    {
        characterSound = GetComponent<CharacterSound>();
    }

    public void PlayerJump()
    {
        if (player == null)
            player = CreatePlayer.player;
        characterSound.PlaySound(jumpSound);
        StartCoroutine(PlayerJumpCoroutine());
    }

    private IEnumerator PlayerJumpCoroutine()
    {
        yield return new WaitForSeconds(0.2f);

        player.GetComponentInParent<Rigidbody>().AddForce(Vector3.up * 200);
    }
}