using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SO_BurningRecipe : ScriptableObject
{
    // Start is called before the first frame update
    public SO_KitchenObjects input;
    public SO_KitchenObjects output;
    public int bruningTimeMax;
}
