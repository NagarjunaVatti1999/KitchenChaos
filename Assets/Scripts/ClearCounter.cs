using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    // Start is called before the first frame update
    
    [SerializeField] SO_KitchenObjects item;
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
            else if(player.HasKitchenObject())
            {
                if(player.GetKithenObjects() is PlateKitchenObject)
                {
                    
                    PlateKitchenObject plateKitchenObject = player.GetKithenObjects() as PlateKitchenObject;
                    if(plateKitchenObject.TryAddIngredient(GetKithenObjects().GetScriptableObject()))
                    {
                        GetKithenObjects().DestroySelf();
                    }
                }
            }
        }
    }
    
}
