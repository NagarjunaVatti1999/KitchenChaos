using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button resume;
    [SerializeField] private Button mainMenu;
    void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnPaused += KitchenGameManager_OnGameUnPaused;

        gameObject.SetActive(false);

        resume.onClick.AddListener(()=>{
            KitchenGameManager.Instance.TogglePauseGame();
            gameObject.SetActive(false);
        });
        mainMenu.onClick.AddListener(()=>{
            SceneManager.LoadScene(0);
            gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    private void KitchenGameManager_OnGamePaused(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
    }
    private void KitchenGameManager_OnGameUnPaused(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

}
