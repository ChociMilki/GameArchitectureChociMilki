using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool _isFinalLevel;


    public void StartLevel()
    {
        Debug.Log("Level has started");
    }

    public void EndLevel()
    {
        Debug.Log("Level has ended");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
