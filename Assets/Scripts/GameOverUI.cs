using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI GameOverText;
        [SerializeField] private DeliveryManager deliveryManager;

    private void Start() {
        KitchenGameManager.Instance.OnStateChanged +=KitcenManager_OnStateChanged;
        Hide();
    }

    private void KitcenManager_OnStateChanged(object sender, EventArgs e)
    {
        if(KitchenGameManager.Instance.IsGameOverState())
        {
            Show();
        }
        else{
            Hide();
        }
    }

    private void Update() {
        GameOverText.text = deliveryManager.GetRecipesDelivered().ToString();
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
