using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTimeUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image timer;

    private void Update() {
        timer.fillAmount = KitchenGameManager.Instance.GameTimer();
    }
}
