using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    // Start is called before the first frame update
    public void SetKitchenObject(KithenObjects ko);
    
    public KithenObjects GetKithenObjects();
    
    public void ClearKitchenObject();
    
    public bool HasKitchenObject();
    public Transform GetCounterShiftingTransform(); //will be called from KitchenObject which will send the new position
    
}
