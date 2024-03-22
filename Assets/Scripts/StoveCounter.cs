using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoveCounter : BaseCounter
{
    // Start is called before the first frame update
    [SerializeField] StoveCounterVisual stovevisual;
    float progressAmount = 0;
    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burnt
    }
    private State state;
    [SerializeField] ProgressBar barUpdate;
    [SerializeField] SO_CookingRecipe[] cookingObjects;
    [SerializeField] SO_BurningRecipe[] burningObjects;
     public override void Interact(PlayerMovement player)
    {
        if(!HasKitchenObject())
        {
            if(player.HasKitchenObject())// i.e if player is carrying any ingredient 
            {
                if(isCookable(player.GetKithenObjects().GetScriptableObject())) //i.e if player is carrying that can be sliced
                {
                    player.GetKithenObjects().SetKitchenObjectParent(this);
                    SO_CookingRecipe item = ObjectToCook(this.GetKithenObjects().GetScriptableObject());
                    state = State.Idle;
                    StartCoroutine(CookingProcess(item.fryingTimeMax, item));
                    
                }
            }
        }
        else
        {
            if(!player.HasKitchenObject())
            {
                GetKithenObjects().SetKitchenObjectParent(player);
            }
            else if(player.HasKitchenObject())
            {
                if(player.GetKithenObjects() is PlateKitchenObject)
                {
                    
                    PlateKitchenObject plateKitchenObject = player.GetKithenObjects() as PlateKitchenObject;
                    if(plateKitchenObject.TryAddIngredient(GetKithenObjects().GetScriptableObject()))
                    {
                        GetKithenObjects().DestroySelf();
                    }
                }
            } 
        }
    }

    IEnumerator CookingProcess(int fryingTimeMax, SO_CookingRecipe item)
    {
        state = State.Frying;
        stovevisual.ShowVisuals();

        barUpdate.IncreaseProgress(fryingTimeMax, new Color32(255,190,0,255), progressAmount);

        yield return new WaitForSeconds(fryingTimeMax);
        if(GetKithenObjects()!=null) //if the meat is not removed from the pan suddenly in between
        {
            GetKithenObjects().DestroySelf();
            Transform spawnItem = Instantiate(item.output.prefab);
            spawnItem.GetComponent<KithenObjects>().SetKitchenObjectParent(this);  
            state = State.Fried;

            //if the patty is not removed start burning coroutine
            SO_BurningRecipe nextitem = ObjectToBurn(this.GetKithenObjects().GetScriptableObject());
            StartCoroutine(BurningProcess(nextitem.bruningTimeMax, nextitem));
            progressAmount = 0;
        }
    }
    IEnumerator BurningProcess(int BurningTimeMax, SO_BurningRecipe item)
    {
        barUpdate.IncreaseProgress(BurningTimeMax, Color.red, progressAmount);

        yield return new WaitForSeconds(BurningTimeMax); //you can remove meat in this gap before it burns
        if(GetKithenObjects()!=null) //if the meat is not removed from the pan suddenly in between
        {
            GetKithenObjects().DestroySelf();
            Transform spawnItem = Instantiate(item.output.prefab);
            spawnItem.GetComponent<KithenObjects>().SetKitchenObjectParent(this);  
            state = State.Burnt;
        }
        stovevisual.HideVisuals();

    }
    private SO_KitchenObjects GetOutputForInput(SO_KitchenObjects inputKitchenObjectSO)
    {
        foreach(SO_CookingRecipe CR in cookingObjects)
        {
            if(CR.input == inputKitchenObjectSO)
            {
                return CR.output;
            }
        }
        return null;
    }
    private bool isCookable(SO_KitchenObjects inputKitchenObjectSO)
    {
        foreach(SO_CookingRecipe CR in cookingObjects)
        {
            if(CR.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }
    private SO_CookingRecipe ObjectToCook(SO_KitchenObjects inputKitchenObjectSO)
    {
        foreach(SO_CookingRecipe CR in cookingObjects)
        {
            if(CR.input == inputKitchenObjectSO)
            {
                return CR;
            }
        }
        return null;
    }
    private SO_BurningRecipe ObjectToBurn(SO_KitchenObjects inputKitchenObjectSO)
    {
        foreach(SO_BurningRecipe CR in burningObjects)
        {
            if(CR.input == inputKitchenObjectSO)
            {
                return CR;
            }
        }
        return null;
    }
}
