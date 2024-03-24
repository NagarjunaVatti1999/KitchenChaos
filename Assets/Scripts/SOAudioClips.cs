using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SOAudioClips : ScriptableObject
{
    // Start is called before the first frame update
    public AudioClip[] DdeliverySuccess;
    public AudioClip[] deliveryFailed;
    public AudioClip[] footsteps;
    public AudioClip[] chop;
    public AudioClip[] object_pickup;
    public AudioClip[] object_drop;
    public AudioClip[] trash;
    public AudioClip[] warning;
    public AudioClip[] sizzle;
}
