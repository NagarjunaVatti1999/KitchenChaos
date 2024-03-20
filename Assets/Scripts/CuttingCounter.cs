using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    // Start is called before the first frame update
    [SerializeField] SO_KitchenObjects cutKitchenObject;
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

    public override void InteractAlternate(PlayerMovement Player)
    {
        if(HasKitchenObject())
        {
            GetKithenObjects().DestroySelf();
            
            Transform spawnItem = Instantiate(cutKitchenObject.prefab);
            spawnItem.GetComponent<KithenObjects>().SetKitchenObjectParent(this);  
        }
    }
}
