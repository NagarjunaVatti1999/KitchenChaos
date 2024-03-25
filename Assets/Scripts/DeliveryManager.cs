using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeDelivered;

    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;


    [SerializeField] private SORecipeList mylist;
    [SerializeField] int waitineRecipeMax = 4;
    private List<SORecipe> waitingRecipeList;

    private int recipesDelivered = 0;
    private bool entered = false;
    void Awake()
    {
        waitingRecipeList = new List<SORecipe>();
    }

    // Update is called once per frame
    void Update()
    {
        if(KitchenGameManager.Instance.IsGamePlaying() && entered == false) //enter again only once the previous co-routine is completed
        {
            StartCoroutine(RecipeListUpdater());
        }
    }
    IEnumerator RecipeListUpdater()
    {
        entered = true;
        while(waitingRecipeList.Count<=waitineRecipeMax)
        {
            SORecipe waitingRecipeSO = mylist.RecipeList[UnityEngine.Random.Range(0, mylist.RecipeList.Count)];
            Debug.Log(waitingRecipeSO.name);
            waitingRecipeList.Add(waitingRecipeSO);
 
            OnRecipeSpawned?.Invoke(this, EventArgs.Empty);  //telling UI that a new recipe is spawned

            yield return new WaitForSeconds(4);
        }
        entered = false;
        yield return null;
    }

    public List<SORecipe> GetWaitingRecipes()
    {
        return waitingRecipeList;
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        if(waitingRecipeList.Count <=0)return;
        SORecipe waitingRecipeSO = waitingRecipeList[0];

        if(waitingRecipeSO.recipeIngredients.Count == plateKitchenObject.GetAddedIngredientList().Count)
        {
            //recipe ingredients count of waiting item and plate item matched
            bool itemMatched = true;
            foreach(SO_KitchenObjects ko in plateKitchenObject.GetAddedIngredientList())
            {
                if(waitingRecipeSO.recipeIngredients.Contains(ko))
                {
                    continue;
                }
                else
                {
                    itemMatched = false;
                    break;
                }
            }
            if(itemMatched)
            {
                //Debug.Log("Correct Recipe Delivered");
                
                OnRecipeDelivered?.Invoke(this, EventArgs.Empty); //Telling UI that a given recipe is delivered
                OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                recipesDelivered++;
                waitingRecipeList.Remove(waitingRecipeList[0]);
            }
            else{
                OnRecipeFailed?.Invoke(this, EventArgs.Empty);
            } 
        }
        else{
            OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        }

    }

    public int GetRecipesDelivered()
    {
        return recipesDelivered;
    }
};
