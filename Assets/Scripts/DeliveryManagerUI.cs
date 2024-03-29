using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;
    [SerializeField] private DeliveryManager deliveryManager;
    private void Awake() {
       recipeTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        deliveryManager.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        deliveryManager.OnRecipeDelivered += DeliveryManager_OnRecipeDelivered;

    }

    public void DeliveryManager_OnRecipeSpawned(object sender, EventArgs e)
    {
        UpdateVisual();
        
    }
    public void DeliveryManager_OnRecipeDelivered(object sender, EventArgs e)
    {
        UpdateVisual();
    }
    void UpdateVisual()
    {
        
        foreach(Transform child in container)
        {
            if(child == recipeTemplate)continue;
            Destroy(child.gameObject);
        }
        foreach(SORecipe recipe in deliveryManager.GetWaitingRecipes())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<RecipeIconUIVisual>().SetRecipeDetails(recipe);
            
            //go through each ingredient in recipe and spawn icon for it
            
        }
    }
}
