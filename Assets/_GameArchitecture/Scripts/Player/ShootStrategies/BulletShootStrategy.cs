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
        _interactor.gunRenderer.material.color = _interactor.bulletGunColor;
        _interactor.gunRenderer.material.color = _interactor.rocketGunColor;
    }
    /// <summary>
    /// 
    /// </summary>
    public void Shoot()
    {
        PooledObject pooledBullet = _interactor._bulletPool.GetPooledObject();
        pooledBullet.gameObject.SetActive(true);
        Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;
        // takes private var and construcr 
        bullet.velocity = _spawnPoint.forward *_interactor. GetFinalShootVelocity();
        // bullet pool just made public 
        _interactor._bulletPool.DestroyPooledObject(pooledBullet, 1.0f);
    }
}

    // Start is called before the first frame update


