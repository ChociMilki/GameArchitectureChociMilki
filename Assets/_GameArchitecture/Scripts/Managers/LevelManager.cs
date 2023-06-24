using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  Keeps track of levels 
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isFinalLevel; 



        public void StartLevel()
    {
        Debug.Log("Level has started!"); 
    }
    public void EndLevel()
    {
        Debug.Log("Level has ended!");
    }
        

}
