using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    // Start is called before the first frame update
    private KithenObjects spawnedObject;
    [SerializeField] SO_KitchenObjects item;
    [SerializeField] Transform spawnPosition;
    [SerializeField] ClearCounter newcounter;
    [SerializeField] private bool Testing;
    private void Update() {
        if(Testing && Input.GetKeyDown(KeyCode.T))
        {
            if(spawnedObject!=null)
            {
                spawnedObject.SetKitchenObjectParent(newcounter);
            }
        }
    }
    public void Interact(PlayerMovement player)
    {
        if(spawnedObject == null)
        {
            Transform spawnItem = Instantiate(item.prefab, spawnPosition);
            spawnItem.GetComponent<KithenObjects>().SetKitchenObjectParent(this);
            
        }
        else spawnedObject.SetKitchenObjectParent(player);
    }
    public Transform GetCounterShiftingTransform() //will be called from KitchenObject which will send the new position
    {
        return spawnPosition;
    }

/*following functions are accessed by Kitchen Object wher it will let old counter know that its no longer present on it and 
inform new counter that it is now the kitchen objects new parent*/
    
    public void SetKitchenObject(KithenObjects ko)
    {
        spawnedObject = ko;
    }
    public KithenObjects GetKithenObjects()
    {
        return spawnedObject;
    }
    public void ClearKitchenObject()
    {
        spawnedObject = null;
    }
    public bool HasKitchenObject()
    {
        return spawnedObject !=null;
    }
}
