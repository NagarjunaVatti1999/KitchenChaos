using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject counter;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            counter.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        counter.SetActive(false);
    }
}
