using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    // Start is called before the first frame update
    public static event EventHandler OnItemTrashed;
    public override void Interact(PlayerMovement Player)
    {
        if(Player.HasKitchenObject())
        {
            OnItemTrashed?.Invoke(this, EventArgs.Empty);
            Player.GetKithenObjects().DestroySelf();
        }
    }
}
