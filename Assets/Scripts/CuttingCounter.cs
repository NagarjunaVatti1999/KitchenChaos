using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CuttingCounter : BaseCounter
{
    // Start is called before the first frame update
    private const string CUT = "Cut";
    public static event EventHandler OnyAnyCut;
    [SerializeField] SO_CuttingRecipe[] cutKitchenObject;
    [SerializeField] Animator cutanim;

    private int cuttingcount;
     public override void Interact(PlayerMovement player)
    {
        if(!HasKitchenObject())
        {
            if(player.HasKitchenObject())// i.e if player is carrying any ingredient 
            {
                if(isCuttable(player.GetKithenObjects().GetScriptableObject())) //i.e if player is carrying that can be sliced
                {
                    player.GetKithenObjects().SetKitchenObjectParent(this);
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

    public override void InteractAlternate(PlayerMovement Player)
    {
        if(HasKitchenObject() && isCuttable(GetKithenObjects().GetScriptableObject()))
        {
            //Play Cutting animation
            if(cutanim!=null)cutanim.SetTrigger(CUT);

            OnyAnyCut?.Invoke(this, EventArgs.Empty); //play cutting sound from sound manager;
            SO_KitchenObjects outputobj = GetOutputForInput(GetKithenObjects().GetScriptableObject());
            GetKithenObjects().DestroySelf();
            
            Transform spawnItem = Instantiate(outputobj.prefab);
            spawnItem.GetComponent<KithenObjects>().SetKitchenObjectParent(this);  
        }
    }
    private SO_KitchenObjects GetOutputForInput(SO_KitchenObjects inputKitchenObjectSO)
    {
        foreach(SO_CuttingRecipe CR in cutKitchenObject)
        {
            if(CR.input == inputKitchenObjectSO)
            {
                return CR.output;
            }
        }
        return null;
    }
    private bool isCuttable(SO_KitchenObjects inputKitchenObjectSO)
    {
        foreach(SO_CuttingRecipe CR in cutKitchenObject)
        {
            if(CR.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }
}
