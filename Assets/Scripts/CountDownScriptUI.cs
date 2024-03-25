using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class CountDownScriptUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI countDownText;


    private void Start() {
        KitchenGameManager.Instance.OnStateChanged +=KitcenManager_OnStateChanged;
        Hide();
    }

    private void KitcenManager_OnStateChanged(object sender, EventArgs e)
    {
        if(KitchenGameManager.Instance.IsStateCountdownToStart())
        {
            Show();
        }
        else{
            Hide();
        }
    }

    private void Update() {
        countDownText.text = Mathf.Ceil(KitchenGameManager.Instance.GetCountDownTimer()).ToString();
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
