using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
