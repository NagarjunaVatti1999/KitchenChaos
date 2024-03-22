using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject stoveVisual;
    [SerializeField] GameObject particles;

    public void ShowVisuals()
    {
        stoveVisual.SetActive(true);
        particles.SetActive(true);
    }
    public void HideVisuals()
    {
        stoveVisual.SetActive(false);
        particles.SetActive(false);
    }
}
