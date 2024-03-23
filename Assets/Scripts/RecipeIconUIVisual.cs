using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeIconUIVisual : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;
    [SerializeField] private TextMeshProUGUI recipeText;
    private void Awake() {
        iconTemplate.gameObject.SetActive(false);
    }
    public void SetRecipeDetails(SORecipe recipe)
    {
        recipeText.text = recipe.recipeName;
        foreach(Transform child in iconContainer)
        {
            if(child == iconTemplate)continue;
            Destroy(child.gameObject);
        }

        foreach(SO_KitchenObjects ko in recipe.recipeIngredients)
            {
                Transform recipeIcon = Instantiate(iconTemplate, iconContainer);
                recipeIcon.gameObject.SetActive(true);
                recipeIcon.GetComponent<Image>().sprite = ko.icon;
            }
    }
}
