using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  
/// </summary>
public class RocketShootStrategy : IShootStrategy
{
    ShootInteractor _interactor;
    Transform _spawnPoint; 
    // constructor 
    public RocketShootStrategy (ShootInteractor interactor)
    {
        Debug.Log(" Switched to r s mode"); 
            _interactor = interactor;
        _spawnPoint = interactor.GetSpawnPoint();

        _interactor.weaponRenderer.material.color = _interactor.rocketWeaponColor;
    }
    public void Shoot()
    {
        throw new System.NotImplementedException();
    }
}
