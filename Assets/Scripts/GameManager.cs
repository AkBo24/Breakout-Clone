using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject ballPrefab, playerPrefab; //prefabs
    [SerializeField] GameObject panelMenu, panelPlay, panelLevelCompleted, panelGameOver; //ui panels
    [SerializeField] private GameObject[] gameLevels;
    [SerializeField] private GameObject currBall, currLevel;
    [SerializeField] private Text scoreText, levelText, ballsText;

    public static GameManager Instance {get; private set;}

    private enum State { MENU, INIT, PLAY, LEVEL_COMPLETED, LOAD_LEVEL, GAME_OVER }
    [SerializeField] private State gameState;

    bool isSwitchingState;

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

    void SwitchState(State nextState, float delay = 0) {
        StartCoroutine(SwitchDelay(nextState, delay));
    }

    IEnumerator SwitchDelay (State nextState, float delay) {
        isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        gameState  = nextState;
        BeginState(nextState);
        isSwitchingState = false;
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
                Destroy(currBall);
                Destroy(currLevel);
                Level++;
                panelLevelCompleted.SetActive(true);
                SwitchState(State.LOAD_LEVEL, 2f);
                break;
            case State.LOAD_LEVEL:
                Instantiate(playerPrefab);

                if(Level < gameLevels.Length) {
                    currLevel = Instantiate(gameLevels[level]);
                    SwitchState(State.PLAY);
                }
                else
                    SwitchState(State.GAME_OVER);

                break;
            case State.GAME_OVER:
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
            case State.GAME_OVER:
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
                if (currBall == null) {
                    if(Balls > 0)
                        currBall = Instantiate(ballPrefab);
                    else
                        SwitchState(State.GAME_OVER);
                }

                if(currLevel != null && currLevel.transform.childCount == 0 && !isSwitchingState)
                    SwitchState(State.LEVEL_COMPLETED);

                break;
            case State.LEVEL_COMPLETED:
                break;
            case State.LOAD_LEVEL:
                break;
            case State.GAME_OVER:
                if(Input.anyKeyDown)
                    SwitchState(State.MENU);
                break;
        }
    }


}
