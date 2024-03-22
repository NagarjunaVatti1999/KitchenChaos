using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    // Start is called before the first frame update
    [SerializeField] SO_KitchenObjects plate;
    private void Start() {
        if(!this.HasKitchenObject())
        {
            Transform newplate = Instantiate(plate.prefab, GetCounterShiftingTransform());
            newplate.GetComponent<KithenObjects>().SetKitchenObjectParent(this);
        }
    }
    public override void Interact(PlayerMovement Player)
    {
            GetKithenObjects().SetKitchenObjectParent(Player);
           // Player.SetKitchenObject(plate.prefab);

            Transform newplate = Instantiate(plate.prefab, GetCounterShiftingTransform());
            newplate.GetComponent<KithenObjects>().SetKitchenObjectParent(this);
    }
}
