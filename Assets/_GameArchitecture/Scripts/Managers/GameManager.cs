using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] _levels;

    public static GameManager _instance;

    private GameState _currentstate;
    private LevelManager _currentLevel;
    private int _currentLevelIndex = 0;
    private bool _isInputActive = true;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
    }

    public static GameManager GetInstance()
    {
        return _instance;
    }
    public bool IsInputActive()
    {
        return _isInputActive;
    }
    
    //Change Current Game State

    public void ChangeState(GameState state, LevelManager level)
    {
        _currentstate = state;
        _currentLevel = level;

        switch (_currentstate)
        {
            case GameState.Briefing:
                //Do SOmething
                Debug.Log("Game state is briefing");
                break;
            case GameState.LevelStart:
                //Do Something
                Debug.Log("Game state is start");
                break;
            case GameState.LevelIn:
                //Do Something
                Debug.Log("Game state is level in");
                break;
            case GameState.LevelEnd:
                //Do Something
                Debug.Log("Game state is level end");
                break;
            case GameState.GameOver:
                //Do Something
                Debug.Log("Game state is game over");
                break;
            case GameState.GameEnd:
                //Do Something
                Debug.Log("Game state is game end");
                break;
        }
    }

    public enum GameState
    {
        Briefing,
        LevelStart,
        LevelIn,
        LevelEnd,
        GameOver,
        GameEnd
    }
}
