using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler OnInteract;
    private PlayerInput playerInput;
    void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        playerInput.Player.Interact.performed += Interact_Performed;  
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(OnInteract!=null)
        {
            OnInteract(this, EventArgs.Empty);
        }
    }
}
