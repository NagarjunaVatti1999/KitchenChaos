using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryStatusUI : MonoBehaviour
{
    // Start is called before the first frame update
    private const string STATUS = "status";
    [SerializeField] private Image background;
    [SerializeField] private Image statusSprite;
    [SerializeField] private TextMeshProUGUI deliveryStatus;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failedSprite;
    [SerializeField] private Animator anim;

    private void Start() {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnFailed;
        gameObject.SetActive(false);
    }

    private void DeliveryManager_OnSuccess(object sender, EventArgs e)
    {
        anim.SetTrigger(STATUS);
        gameObject.SetActive(true);
        background.color = successColor;
        deliveryStatus.text = "Delivery\nSUCCESS";
        statusSprite.sprite = successSprite;
        
    }
    private void DeliveryManager_OnFailed(object sender, EventArgs e)
    {
        anim.SetTrigger(STATUS);
        gameObject.SetActive(true);
        background.color = failedColor;
        deliveryStatus.text = "Delivery\nFAILED";
        statusSprite.sprite = failedSprite;
    }
}
