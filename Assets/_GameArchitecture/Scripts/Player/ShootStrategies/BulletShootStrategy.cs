using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  this script will implement the interface 
/// </summary>
public class BulletShootStrategy : IShootStrategy
{
    //need for shooting
    ShootInteractor _interactor;
    Transform _spawnPoint; 
    //use constructor to construct strategy at runtime 
    // for each time bss is created use Constructor - accessing 
    public BulletShootStrategy(ShootInteractor interactor)
    {
        Debug.Log("Switched to Bullet Shooting Mode");
        _interactor = interactor;
        _spawnPoint = _interactor.GetSpawnPoint();
        // change weapon color 
        _interactor.weaponRenderer.material.color = _interactor.bulletWeaponColor; 
    }
    /// <summary>
    /// 
    /// </summary>
    public void Shoot()
    {
       
    }

    // Start is called before the first frame update

}
