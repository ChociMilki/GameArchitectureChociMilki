using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditor.Timeline.Actions;
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
    /// tt:Holds state keys 
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
    /// tt: Implements singleton design pattern for the Game Manager. 
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this) {  Destroy(gameObject); return;  }
        else { instance = this; }
    }
    /// <summary>
    ///tt: Allows public get and private set  usage of the GameManager 
    /// </summary>
    /// <returns></returns>
    public static   GameManager GetInstance() { return instance; }
/// <summary>
/// tt:Boolean to check for  input activity
/// </summary>
/// <returns></returns>
    public bool IsInputActive() { return isInputActive; }   

  
    /// <summary>
    /// tt:Grabs knowledge of the current level and changes the current game state through SwitchCase methodology. 
    /// </summary>
    public void ChangeState(GameState state, LevelManager level)
    {
        currentState = state;
        currentLevel = level;

        switch (currentState)
        {
           case GameState.Briefing:
                //Initialize the  briefing state 
                StartBriefing(); 
                Debug.Log("Game state is briefing"); break;

                //Move the game state to LS once briefing complete. 
                case GameState.LevelStart:
                //Initialize the  current level 
                InitiateLevel(); 
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
    /// <summary>
    ///tt: Disables inputActivity, moves current level to start within the GameState enum. 
    /// </summary>
    private void StartBriefing()
    {
        //set boolean iIA to false. 
        isInputActive = false;
        // sets the currentLevel to Level Start section of the game state. 
        ChangeState(GameState.LevelStart, currentLevel);
        Debug.Log("Briefing Started...");

    }
 /// <summary>
 /// tt: Initializes and allows inputActivity as well as throwing an event within LM 
 ///  and additionally changing the game state status to the corresponding enum key. 
 /// </summary>
    private void InitiateLevel()
    {
        // set boolean 
        isInputActive = true;
        // LM Event call 
        currentLevel.StartLevel(); 
        //   changes game state
        ChangeState(GameState.LevelIn, currentLevel);
        Debug.Log("Level Started!");
    }
}
