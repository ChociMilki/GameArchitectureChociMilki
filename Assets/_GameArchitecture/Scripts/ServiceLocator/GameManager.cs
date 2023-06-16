using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        var audioManager = new AudioManager();

        ServiceLocator.RegisterService<IAudioManager>(audioManager);
    }
}
