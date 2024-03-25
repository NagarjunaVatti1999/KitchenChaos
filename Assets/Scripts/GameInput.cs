using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameInput Instance{get; private set;}
    public event EventHandler OnInteract;
    public event EventHandler OnInteractAlternate;
    public event EventHandler OnPaused;
    private PlayerInput playerInput;
    void Awake()
    {
        Instance = this;

        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        playerInput.Player.Interact.performed += Interact_Performed;  
        playerInput.Player.InteractAlternate.performed += InteractAlternate_Performed;  
        playerInput.Player.Pause.performed += Pause_Performed;
    }

    private void OnDestroy() {

        playerInput.Player.Interact.performed -= Interact_Performed;  
        playerInput.Player.InteractAlternate.performed -= InteractAlternate_Performed;  
        playerInput.Player.Pause.performed -= Pause_Performed;

        playerInput.Dispose();
    }
 

    private void Pause_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPaused?.Invoke(this, EventArgs.Empty);
    }
    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(OnInteract!=null)
        {
            OnInteract(this, EventArgs.Empty);
        }
    }
    private void InteractAlternate_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(OnInteract!=null)
        {
            OnInteractAlternate(this, EventArgs.Empty);
        }
    }
}
