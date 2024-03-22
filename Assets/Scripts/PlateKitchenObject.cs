using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KithenObjects
{
    // Start is called before the first frame update
    public event EventHandler<OnAddIngredientEventArgs> OnAddIngredient;
    public class OnAddIngredientEventArgs: EventArgs{
        public SO_KitchenObjects addedIngreient;
    }
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
        OnAddIngredient?.Invoke(this, new OnAddIngredientEventArgs{
            addedIngreient = kithenObject
            });
        return true;
    }
    public List<SO_KitchenObjects> GetAddedIngredientList()
    {
        return kithenObjectsList;
    }
}
