using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameState currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex = 0;
    private bool isInputActive = true; 
    [SerializeField] private LevelManager[] levels; 

    /// <summary>
    /// keeps track of current state
    /// </summary>
    public enum GameState
    {
        Briefing, 
        LevelStart, 
        LevelIn, 
        LevelEnd, 
        GameOver,
        GameEnd
    }
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this) {  Destroy(gameObject); return;  }
        else { instance = this; }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static   GameManager GetInstance() { return instance; }
/// <summary>
/// get/set isinputactive 
/// </summary>
/// <returns></returns>
    public bool IsInputActive() { return isInputActive; }   

  
    /// <summary>
    ///  change current game state , know the current level and the state we are changing using switchcase 
    /// </summary>
    public void ChangeState(GameState state, LevelManager level)
    {
        currentState = state;
        currentLevel = level;

        switch (currentState)
        {
           case GameState.Briefing:
                //Do XYZ 
                Debug.Log("Game state is briefing"); break;
                case GameState.LevelStart:
                //Do XYZ
                Debug.Log("Game state is level start");
                break;
            case GameState.LevelIn:
                //Do XYZ 
                Debug.Log("Game state is level in ");
                break;
            case GameState.LevelEnd:
                //Do XYZ 
                Debug.Log("Game state is level end");
                break;
            case GameState.GameOver:
                // Do XYZ 
                Debug.Log("Game state is game over");
                break;
            case GameState.GameEnd:
                // Do XYZ 
                Debug.Log("Game state is game end");
                break; 
        }
    }

}
