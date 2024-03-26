using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBridge : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataBridge Instance{get; private set;}
    public string timervalue;
    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
