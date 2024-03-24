using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SoundManager soundManager;
    PlayerMovement player;
    private bool flag = false;
    [SerializeField] float volume = 1f;

    private void Awake() {
        player = GetComponent<PlayerMovement>();
    }
    private void Update() {

        if(flag == false)
        {
            if(player.isWalking)StartCoroutine(SoundPlayer());
        }
    }

    private IEnumerator SoundPlayer()
    {
        flag = true;
        soundManager.playFootstepsSound(player.transform.position, volume);
        yield return new WaitForSeconds(soundManager.GetClipLength());
        flag = false;
        yield return null;
    }
}
