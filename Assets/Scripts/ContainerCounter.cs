using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    // Start is called before the first frame update
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] SO_KitchenObjects item;

    public override void Interact(PlayerMovement player)
    {
        if(!player.HasKitchenObject())
        {
            Transform spawnItem = Instantiate(item.prefab);
            spawnItem.GetComponent<KithenObjects>().SetKitchenObjectParent(player);          
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty); 
        }
            
    }
    
}
