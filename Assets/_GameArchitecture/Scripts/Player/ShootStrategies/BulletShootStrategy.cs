using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootStrategy : IShootStrategy
{
    ShootInteractor _interactor;
    Transform _spawnPoint;

    //Constructor 
    public BulletShootStrategy(ShootInteractor interactor)
    {
        Debug.Log("Switched to Bullet Shooting Mode!");

        _interactor = interactor;
        _spawnPoint = interactor.GetSpawnPoint();

        //Change Gun Color
        _interactor.gunRenderer.material.color = _interactor.bulletGunColor;
    }
    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

}
