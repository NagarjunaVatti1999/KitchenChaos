using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SO_CuttingRecipe : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] public SO_KitchenObjects input;
    [SerializeField] public SO_KitchenObjects output;
    [SerializeField] public int maxcutcount;
}
