using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //GameObjects
    public GameObject ballPrefab, playerPrefab;

    //UI Text
    private Text scoreText, levelText, ballsText;

    //UI Panels
    private GameObject panelMenue, panelPlay, panelLevelCompleted, panelGameOver;

    private enum State { MENU, INIT, PLAY, LEVEL_COMPLETED, LOAD_LEVEL, GAMEOVER }
    [SerializeField] private State gameState;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() { 
        switch (newState) {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVEL_COMPLETED:
                break;
            case State.LOAD_LEVEL:
                break;
            case State.GAMEOVER:
                break;
        }
    }

    void SwitchState(State nextState) {
        EndState();
        BeginState(nextState);
    }

    void BeginState(State newState) {
        switch (newState) {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVEL_COMPLETED:
                break;
            case State.LOAD_LEVEL:
                break;
            case State.GAMEOVER:
                break;
        }
    }

    void EndState() {
        switch (gameState) {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVEL_COMPLETED:
                break;
            case State.LOAD_LEVEL:
                break;
            case State.GAMEOVER:
                break;
        }
    }


}
