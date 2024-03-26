using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameTime : MonoBehaviour
{
    // Start is called before the first frame update
    public string getTimer;
    void Start()
    {
        getTimer = DataBridge.Instance.timervalue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
