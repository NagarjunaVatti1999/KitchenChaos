using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SORecipe : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] public string recipeName;

    [SerializeField] public List<SO_KitchenObjects> recipeIngredients;
}
