using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
/// <summary>
///  Keeps track of levels , utilizing events to trigger state changes 
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isFinalLevel;

    public UnityEvent onLevelStart;
    public UnityEvent onLevelEnd; 

        public void StartLevel()
    {
        // Invokable event 
        onLevelStart?.Invoke(); 
        Debug.Log("Level has started!"); 
    }
    /// <summary>
    /// tt:  Implements game end and level end 
    /// </summary>
    public void EndLevel()
    {
        // invokable event 
        onLevelEnd?.Invoke();
       //sets  isFL to true, as well as changing current game state to game end
        if(isFinalLevel == true)
        {
            GameManager.GetInstance().ChangeState(GameManager.GameState.GameEnd, this); 
            Debug.Log("The game has ended"); 
        }
        // otherwise if the above boolean is false, changes the game state to level end
        else
        {
            GameManager.GetInstance().ChangeState(GameManager.GameState.LevelEnd, this);
            Debug.Log("Level has ended!");
        }
    
    }
        

}
