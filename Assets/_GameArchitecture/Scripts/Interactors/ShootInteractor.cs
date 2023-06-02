using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [Header("Shoot")]
    [SerializeField] private Rigidbody _bulletPrefab;
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

    void Shoot()
    {
            _finalShootVelocity = _moveBehaviour.GetForwardSpeed() + _shootForce;

            Rigidbody bulletRb = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
            bulletRb.AddForce(_spawnPoint.forward * _finalShootVelocity, ForceMode.Impulse);
            Destroy(bulletRb.gameObject, 5f);
    }
}
