using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlateVisual : MonoBehaviour
{
    // Start is called before the first frame update
    [Serializable]
    public struct SO_KitchenObjects_GameObject{
        public  SO_KitchenObjects ingredientSO;
        public GameObject prefabingredient;
    }
    [SerializeField] private PlateKitchenObject myplate;
    [SerializeField] private List<SO_KitchenObjects_GameObject> kitchenObjects_GameObjectsList;
    void Start()
    {
        myplate.OnAddIngredient += myplate_OnAddIngredient;

        foreach(SO_KitchenObjects_GameObject KO in kitchenObjects_GameObjectsList)
        {
            KO.prefabingredient.SetActive(false);
        }
    }

    public void myplate_OnAddIngredient(object obj, PlateKitchenObject.OnAddIngredientEventArgs e)
    {
       foreach(SO_KitchenObjects_GameObject KO in kitchenObjects_GameObjectsList)
       {
            if(e.addedIngreient == KO.ingredientSO)
            {
                KO.prefabingredient.SetActive(true);
            }
       }
    }
    public SO_KitchenObjects GetIngredient(object obj, PlateKitchenObject.OnAddIngredientEventArgs e)
    {
       foreach(SO_KitchenObjects_GameObject KO in kitchenObjects_GameObjectsList)
       {
            if(e.addedIngreient == KO.ingredientSO)
            {
                return KO.ingredientSO;
            }
       }
       return null;
    }

    // Update is called once per frame
}
