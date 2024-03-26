using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    // Start is called before the first frame update
    public override void Interact(PlayerMovement Player)
    {
        if(Player.HasKitchenObject())
        {
            if(Player.GetKithenObjects() is PlateKitchenObject)
            {
                PlateKitchenObject plateKitchenObject = Player.GetKithenObjects() as PlateKitchenObject;
                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
                Player.GetKithenObjects().DestroySelf();
            }
        }
    }
}
