using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    private KithenObjects spawnedObject;
    [SerializeField] Transform spawnPosition;
    // Start is called before the first frame update
    public virtual void Interact(PlayerMovement Player)
    {
        Debug.LogError("Base Class function called");
    }
    public virtual void InteractAlternate(PlayerMovement Player)
    {
        Debug.LogError("Base Class function called");
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
