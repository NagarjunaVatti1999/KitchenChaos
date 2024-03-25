using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static KitchenGameManager Instance {get ; private set;}

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnPaused;
    public event EventHandler OnShowTutorial;
    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,
    }

    [SerializeField] private float waitingToStartTimer = 1f;
    [SerializeField] private float CountDownToStartTimer = 3f;
    [SerializeField] private float gamePlayingTimerMax = 20f;
    [SerializeField] private float gamePlayingTimer = 20f;
    private bool togglePause = false;
    private State state;
    private void Awake() {
        Instance = this;
        state = State.WaitingToStart;
    }
    // Update is called once per frame
    private void Start() {
        GameInput.Instance.OnPaused += GameInput_OnPaused;
        GameInput.Instance.OnInteract += GameInput_OnInteract;
    }

    private void GameInput_OnInteract(object sender, EventArgs e)
    {
        if(state == State.WaitingToStart)
        {
            state = State.CountDownToStart;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    private void GameInput_OnPaused(object sender, EventArgs e)
    {
        TogglePauseGame();
    }
    void Update()
    {
        switch(state)
        {
            case State.WaitingToStart:
                break;

            case State.CountDownToStart:
                CountDownToStartTimer -= Time.deltaTime;
                if(CountDownToStartTimer < 0f)
                {
                    gamePlayingTimer = gamePlayingTimerMax;
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GamePlaying:
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimer< 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool IsStateCountdownToStart()
    {
        return state == State.CountDownToStart;
    }
    public float GetCountDownTimer()
    {
        return CountDownToStartTimer;
    }
    public bool IsGameOverState()
    {
        return state == State.GameOver;
    }
    public float GameTimer()
    {
        return 1-(gamePlayingTimer/gamePlayingTimerMax);
    }

    public void TogglePauseGame()
    {
        togglePause = !togglePause;
        if(togglePause)
        {
            OnGamePaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 0;
        }
        else{
            OnGameUnPaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 1;
        }
    }

}
