using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image image;
    void Start()
    {
        image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseProgress(int gettime, Color setColor, float progress)
    {
        image.color = setColor;
        image.fillAmount = 0;
        StartCoroutine(IncreaseProgressCoroutine(gettime, progress));
    }
    private IEnumerator IncreaseProgressCoroutine(int gettime, float progress)
    {
        while(progress<=gettime)
        {
            progress += (float)1/gettime;
            image.fillAmount = progress;
            
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
    
}
