using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor

{
    [Header(" Weapon")]
    public MeshRenderer weaponRenderer;
    public Color bulletWeaponColor;
    public Color rocketWeaponColor; 

    [Header("Shoot")]
    //[SerializeField] private Rigidbody _bulletPrefab;
    // either can be constructed our made public 
   public  ObjectPool _bulletPool;
    public ObjectPool _rocketPool; 
    // limited access to this class, BSS uses via 
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootForce;
  //  [SerializeField] private ShootInputType _shootInput;
    [SerializeField] private PlayerMovementBehaviour _moveBehaviour;

    private float _finalShootVelocity;
    private IShootStrategy _currentStrategy;  // reference to our current shooting strategy 
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



        // default shoot strategy 
        if(_currentStrategy == null)
        {
          
            _currentStrategy = new BulletShootStrategy(this); 
        }

        //Change Strategy based on UserInput [Key 1 = Bullet, Key 2 = Rocket] 
        if(_input.weapon1Pressed)
        {
            _currentStrategy = new BulletShootStrategy(this); 
        }
        if (_input.weapon2Pressed)
        {
            _currentStrategy = new RocketShootStrategy(this);
        }
        // references current strategy and calls it to shoot 
        if (_input.primaryShootPressed && _currentStrategy != null)
        {
            _currentStrategy.Shoot(); 
        }


    }
    /// <summary>
    /// TT: Shoot -spawn returned object at spawn point position then add force. 
    /// </summary>
    void Shoot()
    {
         
        //PooledObject pooledBullet = _bulletPool.GetPooledObject();
        //pooledBullet.gameObject.SetActive(true);
        //Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
        //bullet.transform.position = _spawnPoint.position;
        //bullet.transform.rotation = _spawnPoint.rotation;
        //bullet.velocity = _spawnPoint.forward * _finalShootVelocity;
        //_bulletPool.DestroyPooledObject(pooledBullet, 1.0f);
    }
    /// <summary>
    /// needed to return private spawn point to BSS for constructor 
    /// </summary>
    /// <returns></returns>
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
