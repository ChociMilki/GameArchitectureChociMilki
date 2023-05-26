using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private bool _invertMouse;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _sprintMultiplier;
    [SerializeField] private float _yTurnMin;
    [SerializeField] private float _yTurnMax;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundCheckDistance;

    [Header("Shoot")]
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Rigidbody _rocketPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootForce;


    private CharacterController _characterController;

    private float _horizontal, _vertical;
    private float _mouseX, _mouseY;
    private float _camXRotation;
    private Vector3 _playerVelocity;
    private bool _isGrounded;
    private float _moveMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        //Hide Mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        GroundCheck();
        MovePlayer();
        TurnPlayer();
        Jump();
        Shoot();
        ShootRocket();
    }

    void GetInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _moveMultiplier = Input.GetButton("Sprint") ? _sprintMultiplier : 1;
    }

    void MovePlayer()
    {
        _characterController.Move((transform.forward * _vertical + transform.right * _horizontal) * _moveSpeed * Time.deltaTime);

        //Ground Check
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        //Set Player Velocity
        // v = u + a*t  v = g* t
        _playerVelocity.y += _gravity * Time.deltaTime;

        // V = 1/2 * a * t^2
        _characterController.Move(_playerVelocity * Time.deltaTime);

    }

    void TurnPlayer()
    {
        // Player turn Movement
        transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime * _mouseX);

        //Camera Up/Down Movement
        _camXRotation += Time.deltaTime * _mouseY * _turnSpeed * (_invertMouse ? 1 : -1);
        _camXRotation = Mathf.Clamp(_camXRotation, _yTurnMin, _yTurnMax);
        _cameraTransform.localRotation = Quaternion.Euler(_camXRotation, 0, 0);
    }

    void GroundCheck()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckDistance, _groundMask);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _playerVelocity.y = _jumpVelocity;
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bulletRb = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
            bulletRb.AddForce(_spawnPoint.forward * _shootForce, ForceMode.Impulse);
            Destroy(bulletRb.gameObject, 5f);
        }
    }

    void ShootRocket()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody rocketRB = Instantiate(_rocketPrefab, _spawnPoint.position, _spawnPoint.rotation);
            rocketRB.AddForce(_spawnPoint.forward * _shootForce, ForceMode.Impulse);
            Destroy(rocketRB.gameObject, 5f);
        }
    }
}
