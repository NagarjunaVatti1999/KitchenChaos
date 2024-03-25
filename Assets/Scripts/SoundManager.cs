using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SOAudioClips clips;
    [SerializeField] DeliveryManager deliveryManager;

    private bool playOnce = false;
    private void Start() {
        deliveryManager.OnRecipeSuccess += OnRecipeSuccess_PlaySound;
        deliveryManager.OnRecipeFailed += OnRecipeFailed_PlaySound;
        CuttingCounter.OnyAnyCut += CuttingCounter_OnAnyCut;
        TrashCounter.OnItemTrashed += TrashCounter_OnItemTrashed;
        PlayerMovement.OnItemPicked += PlayerMovement_OnItemPicked;
        BaseCounter.OnItemDropped += BaseCounter_OnItemDropped;
        KitchenGameManager.Instance.OnStateChanged += kitchenGameManager_OnStateChanged;
    }

    private void kitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if(playOnce == false)
        {
            PlaySound(clips.warning, Camera.main.transform.position, 1f);
            playOnce = true;
        }
    }
    private void BaseCounter_OnItemDropped(object sender, EventArgs e)
    {
        BaseCounter basecounter = sender as BaseCounter;
        PlaySound(clips.object_pickup, basecounter.transform.position, 1f);
    }
    private void PlayerMovement_OnItemPicked(object sender, EventArgs e)
    {
        PlayerMovement player = sender as PlayerMovement;
        PlaySound(clips.object_pickup, player.transform.position, 1f);
    }
    private void TrashCounter_OnItemTrashed(object sender, EventArgs e)
    {
        TrashCounter trasher = sender as TrashCounter;
        PlaySound(clips.trash, trasher.transform.position, 1f);
    }
    private void CuttingCounter_OnAnyCut(object sender, EventArgs e)
    {
        CuttingCounter counter = sender as CuttingCounter;
        PlaySound(clips.chop, counter.transform.position, 1f);
    }
    private void OnRecipeSuccess_PlaySound(object sender, EventArgs e)
    {
        PlaySound(clips.DdeliverySuccess, Camera.main.transform.position, 1f);
    }
    private void OnRecipeFailed_PlaySound(object sender, EventArgs e)
    {
        PlaySound(clips.deliveryFailed, Camera.main.transform.position, 1f);
    }

    public void PlaySound(AudioClip[] audioclip, Vector3 position, float volume)
    {
        PlaySound(audioclip[UnityEngine.Random.Range(0, audioclip.Length)], position, volume);
    }
    public void PlaySound(AudioClip clip, Vector3 position, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }

    public void playFootstepsSound(Vector3 position, float getvolume)
    {
        PlaySound(clips.footsteps, position, getvolume);
    }
    public float GetClipLength()
    {
        AudioClip footstepClip =  clips.footsteps[UnityEngine.Random.Range(0, clips.footsteps.Length)];
        return footstepClip.length;
    }
}
