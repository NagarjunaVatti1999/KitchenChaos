using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static KitchenGameManager Instance {get ; private set;}

    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,
    }

    private float waitingToStartTimer = 1f;
    private float CountDownToStartTimer = 3f;
    private float gamePlayingTimer = 10f;
    private State state;
    private void Awake() {
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
                }
                break;

            case State.CountDownToStart:
                CountDownToStartTimer -= Time.deltaTime;
                if(CountDownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                }
                break;

            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimer< 0f)
                {
                    state = State.GameOver;
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

}
