using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KithenObjects : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SO_KitchenObjects sO_KitchenObject;
    private IKitchenObjectParent kitchenObjectParent;

    public SO_KitchenObjects GetScriptableObject()
    {
        return sO_KitchenObject;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent current_KO_Parent) // this is basically set by the counter which this item is spawned
    {
        if(kitchenObjectParent!=null)
        {
            kitchenObjectParent.ClearKitchenObject();
        }

        kitchenObjectParent = current_KO_Parent;

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter already has an object");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = current_KO_Parent.GetCounterShiftingTransform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetKitchenObjectParent() //this basically tells on which counter the object is
    {
        return kitchenObjectParent;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }
}
