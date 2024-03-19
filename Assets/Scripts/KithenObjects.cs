using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KithenObjects : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SO_KitchenObjects sO_KitchenObject;

    public SO_KitchenObjects GetScriptableObject()
    {
        return sO_KitchenObject;
    }
}
