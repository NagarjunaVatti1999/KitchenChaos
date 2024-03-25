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
    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,
    }

    private float waitingToStartTimer = 1f;
    private float CountDownToStartTimer = 3f;
    private float gamePlayingTimerMax = 20f;
    private float gamePlayingTimer = 20f;
    private State state;
    private void Awake() {
        Instance = this;
        state = State.CountDownToStart;
    }
    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if(waitingToStartTimer < 0f)
                {
                    state = State.CountDownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
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
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimerMax< 0f)
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

}
