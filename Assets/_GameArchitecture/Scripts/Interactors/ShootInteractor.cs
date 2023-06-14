using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [Header("Gun")]
    public MeshRenderer gunRenderer;
    public Color bulletGunColor;
    public Color rocketGunColor;



    [Header("Shoot")]
    //[SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootForce;
    //[SerializeField] private ShootInputType _shootInput;
    [SerializeField] private PlayerMovementBehaviour _moveBehaviour;

    private float _finalShootVelocity;

    private IShootStrategy _currentStrategy; //Reference to our current shooting strategy
    //public enum ShootInputType
    //{
    //    Primary, //Left Click
    //    Secondary //Right Click
    //}

    public override void Interact()
    {
        //if (_shootInput == ShootInputType.Primary && _input.primaryShootPressed
        //    || _shootInput == ShootInputType.Secondary && _input.secondaryShootPressed)
        //{
        //    Shoot();
        //}

        //Default Shoot Strategy
        if (_currentStrategy == null)
        {
            _currentStrategy = new BulletShootStrategy(this);
        }
    }

    void Shoot()
    {
            _finalShootVelocity = _moveBehaviour.GetForwardSpeed() + _shootForce;

        PooledObject pooledBullet = _bulletPool.GetPooledObject();
        pooledBullet.gameObject.SetActive(true);

        Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();

        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;

        //bullet.AddForce(_spawnPoint.forward * _finalShootVelocity, ForceMode.Impulse);
        bullet.velocity = _spawnPoint.forward * _finalShootVelocity;

        //Rigidbody bulletRb = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        //bulletRb.AddForce(_spawnPoint.forward * _finalShootVelocity, ForceMode.Impulse);

        //Destroy(bulletRb.gameObject, 5f);
        _bulletPool.DestroyPooledObject(pooledBullet, 1.0f);
    }

    public Transform GetSpawnPoint()
    {
        return _spawnPoint;
    }
}
