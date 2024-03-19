using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SO_KitchenObjects item;
    [SerializeField] Transform spawnPosition;
    public void Interact()
    {
        Transform spawnItem = Instantiate(item.prefab, spawnPosition);
        Debug.Log(spawnItem.GetComponent<KithenObjects>().GetScriptableObject());
    }
}
