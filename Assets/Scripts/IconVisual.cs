using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconVisual : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlateKitchenObject plateKitchenObject;
    [SerializeField] Transform iconTemplate;
    void Awake()
    {
        foreach(Transform child in transform)
        {
            if(child == iconTemplate)continue;
            Destroy(child.gameObject);
        }
    }
    void Start()
    {
        plateKitchenObject.OnAddIngredient += OnAddIngredient_ShowIcon;
    }

    // Update is called once per frame
    public void OnAddIngredient_ShowIcon(object obj, PlateKitchenObject.OnAddIngredientEventArgs e)
    {
        UpdateVisual();   
    }
    void UpdateVisual()
    {
        foreach(Transform child in transform)
        {
            if(child == iconTemplate)continue;
            Destroy(child.gameObject);
        }
        foreach(SO_KitchenObjects ingredient in plateKitchenObject.GetAddedIngredientList())
        {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            Image iconImage = iconTransform.Find("Icon").GetComponent<Image>();
            iconImage.sprite = ingredient.icon;
        }
    }
};
