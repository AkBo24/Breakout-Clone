using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //GameObjects
    public GameObject ballPrefab, playerPrefab;
    [SerializeField] GameObject panelMenu, panelPlay, panelLevelCompleted, panelGameOver; //ui panels
    [SerializeField] GameObject[] gameLevels;

    //UI Text
    [SerializeField] private Text scoreText, levelText, ballsText;

    public static GameManager Instance {get; private set;}

    private enum State { MENU, INIT, PLAY, LEVEL_COMPLETED, LOAD_LEVEL, GAMEOVER }
    [SerializeField] private State gameState;

    public int score;
    public int Score  {
        get { return score; }
        set { 
            score = value;
            scoreText.text = "SCORE: " + score;
        }
    }

    private int level;
    public int Level {
        get { return level; }
        set { 
            level = value; 
            levelText.text = "LEVEL: " + level;
        }
    }
    
    private int balls;
    public int Balls {
        get { return balls; }
        set { 
            balls = value; 
            ballsText.text = "BALLS: " + balls;
        }
    }

    void SwitchState(State nextState) {
        EndState();
        BeginState(nextState);
    }
    
    void BeginState(State newState) {
        switch (newState) {
            case State.MENU:
                panelMenu.SetActive(true);
                break;
            case State.INIT:
                panelPlay.SetActive(true);
                Score = Level = 0;
                Balls = 3;
                SwitchState(State.LOAD_LEVEL);
                break;
            case State.PLAY:
                break;
            case State.LEVEL_COMPLETED:
                panelLevelCompleted.SetActive(true);
                break;
            case State.LOAD_LEVEL:
                break;
            case State.GAMEOVER:
                panelGameOver.SetActive(true);
                break;
        }
    }

    void EndState() {
        switch (gameState) {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVEL_COMPLETED:
                panelLevelCompleted.SetActive(false);
                break;
            case State.LOAD_LEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }
    }


    void Start() {
        gameState = State.MENU;
        Instance = this;
        SwitchState(gameState);
    }

    public void playClicked () {
        SwitchState(State.INIT);
    }

    // Update is called once per frame
    void Update() { 
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
