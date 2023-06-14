using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootStrategy : IShootStrategy
{
    ShootInteractor _interactor;
    Transform _spawnPoint;

    //Constructor
    public RocketShootStrategy(ShootInteractor interactor)
    {
        Debug.Log("Switched to the Rocket Shoot mode!");
        _interactor = interactor;
        _spawnPoint = interactor.GetSpawnPoint();

        //Change Gun Color
        _interactor.gunRenderer.material.color = _interactor.rocketGunColor;
    }


    public void Shoot()
    {
        throw new System.NotImplementedException();
    }
}
