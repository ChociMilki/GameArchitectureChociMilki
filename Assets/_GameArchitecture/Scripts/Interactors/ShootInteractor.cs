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
    public ObjectPool bulletPool;
    public ObjectPool rocketPool;

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


        //Change Strategy based on User Input [Key 1 = Bullet, Key 2 = Rocket]
        if (_input.weapon1Pressed)
        {
            _currentStrategy = new BulletShootStrategy(this);
        }

        if (_input.weapon2Pressed)
        {
            _currentStrategy = new RocketShootStrategy(this);
        }

        if (_input.primaryShootPressed && _currentStrategy != null)
        {
            _currentStrategy.Shoot();
        }
    }

    public Transform GetSpawnPoint()
    {
        return _spawnPoint;
    }

    public float GetFinalShootVelocity()
    {
        _finalShootVelocity = _moveBehaviour.GetForwardSpeed() + _shootForce;
        return _finalShootVelocity;
    }
}
