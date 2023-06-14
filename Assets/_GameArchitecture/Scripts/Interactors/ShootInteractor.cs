using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [Header("Shoot")]
    //[SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootForce;
    [SerializeField] private ShootInputType _shootInput;
    [SerializeField] private PlayerMovementBehaviour _moveBehaviour;

    private float _finalShootVelocity;
    public enum ShootInputType
    {
        Primary, //Left Click
        Secondary //Right Click
    }

    public override void Interact()
    {
        if (_shootInput == ShootInputType.Primary && _input.primaryShootPressed
            || _shootInput == ShootInputType.Secondary && _input.secondaryShootPressed)
        {
            Shoot();
        }
    }
    /// <summary>
    /// TT: Shoot -spawn returned object at spawn point position then add force. 
    /// </summary>
    void Shoot()
    {
            _finalShootVelocity = _moveBehaviour.GetForwardSpeed() + _shootForce;
        PooledObject pooledBullet = _bulletPool.GetPooledObject();
        pooledBullet.gameObject.SetActive(true);
        Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;
        bullet.velocity = _spawnPoint.forward * _finalShootVelocity;
        _bulletPool.DestroyPooledObject(pooledBullet, 1.0f);
    }
}
