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
        PooledObject pooledBullet = _interactor._rocketPool.GetPooledObject();
        pooledBullet.gameObject.SetActive(true);
        Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;
        // takes private var and construcr 
        bullet.velocity = _spawnPoint.forward * _interactor.GetFinalShootVelocity();
        // bullet pool just made public 
        _interactor._bulletPool.DestroyPooledObject(pooledBullet, 1.0f);
    }
}
