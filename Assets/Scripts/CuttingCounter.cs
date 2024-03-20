using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    // Start is called before the first frame update
     public override void Interact(PlayerMovement player)
    {
        if(!HasKitchenObject())
        {
            if(player.HasKitchenObject())
            {
                player.GetKithenObjects().SetKitchenObjectParent(this);
            }
        }
        else
        {
            if(!player.HasKitchenObject())
            {
                GetKithenObjects().SetKitchenObjectParent(player);
            }
        }
    }
}
