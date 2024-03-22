using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SORecipeList : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] public string listname;
    [SerializeField] public List<SORecipe> RecipeList;
    
}
