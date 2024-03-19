using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private const string ISWALKING = "IsWalking";
    [SerializeField] PlayerMovement player;
    
    private Animator walkAnim;
    void Awake()
    {
        walkAnim = GetComponent<Animator>();
        //player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        walkAnim.SetBool(ISWALKING, player.isWalking);
    }
}
