using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button play;
    [SerializeField] private Button quit;
    [SerializeField] private TMP_InputField inputField;
    private void Awake() {
        play.onClick.AddListener(()=>{
            DataBridge.Instance.timervalue = inputField.text;
            SceneManager.LoadScene(1);
            
        });
        quit.onClick.AddListener(()=>{
            Application.Quit();
        });

        Time.timeScale = 1f;
    }
}
