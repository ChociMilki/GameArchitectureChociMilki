using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }

    public bool sprintHeld { get; private set; }
    public bool jumpPressed { get; private set; }
    public bool activatePressed { get; private set; }
    public bool primaryShootPressed { get; private set; }
    public bool secondaryShootPressed { get; private set; }

    private bool _clear;

    //Create Singleton
    private static PlayerInput _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }
        _instance = this;
    }

    public static PlayerInput GetInstance() 
    { 
        return _instance; 
    }

    //End of Singleton
    void Update()
    {
        ClearInputs();
        ProcessInputs();
    }

    void ProcessInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        sprintHeld = Input.GetButton("Sprint");
        jumpPressed = Input.GetButtonDown("Jump");
        activatePressed = Input.GetKeyDown(KeyCode.E);

        primaryShootPressed = Input.GetButtonDown("Fire1");
        secondaryShootPressed = Input.GetButtonDown("Fire2");
    }

    private void FixedUpdate()
    {
        _clear = true;
    }
    void ClearInputs()
    {
        if (!_clear) return;

        horizontal = 0;
        vertical = 0;
        mouseX = 0;
        mouseY = 0;

        sprintHeld = false;
        jumpPressed = false;
        activatePressed = false;
        primaryShootPressed = false;
        secondaryShootPressed = false;
    }
}
