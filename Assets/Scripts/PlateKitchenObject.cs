using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KithenObjects
{
    // Start is called before the first frame update
    [SerializeField] List<SO_KitchenObjects> validKithenObjectsSO;

    private List<SO_KitchenObjects> kithenObjectsList;
    private void Awake() {
        kithenObjectsList = new List<SO_KitchenObjects>();
    }

    public bool TryAddIngredient(SO_KitchenObjects kithenObject)
    {
        if(!validKithenObjectsSO.Contains(kithenObject))
        {
            return false;
        }
        if(kithenObjectsList.Contains(kithenObject))
        {
            return false;
        }
        kithenObjectsList.Add(kithenObject);
        return true;
    }
}
