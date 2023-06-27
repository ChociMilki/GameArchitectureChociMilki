using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// tt: references level that is ending, call that level to end, destroy the trigger
/// </summary>
public class LevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.GetInstance().GetCurrentLevel().EndLevel();
            Destroy(gameObject); 
        }
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
