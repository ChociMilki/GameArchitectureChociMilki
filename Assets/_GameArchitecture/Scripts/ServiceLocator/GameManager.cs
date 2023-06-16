using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        //craft instance
        var audioManager = new AudioManager();
        //use service locator to register particular service from IAudioManager via AudioManager
        ServiceLocator.ReferenceEquals<IAudioManager>(audioManager);  

    }
}
