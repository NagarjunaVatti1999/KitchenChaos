using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private const string OPEN_CLOSE = "OpenClose";
    [SerializeField] private ContainerCounter containerCounter;
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
    private void Start() {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object obj, System.EventArgs e)
    {
        anim.SetTrigger(OPEN_CLOSE);
    }
    
}
