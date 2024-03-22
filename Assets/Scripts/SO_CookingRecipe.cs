using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SO_CookingRecipe : ScriptableObject
{
    public SO_KitchenObjects input;
    public SO_KitchenObjects output;
    public int fryingTimeMax;
}
