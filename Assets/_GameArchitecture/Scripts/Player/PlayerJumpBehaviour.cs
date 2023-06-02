using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementBehaviour))]
public class PlayerJumpBehaviour : Interactor
{
    [Header("Jump")]
    [SerializeField] private float _jumpVelocity;

    private PlayerMovementBehaviour _moveBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        _moveBehaviour = GetComponent<PlayerMovementBehaviour>();
    }

    public override void Interact()
    {
        if (_input.jumpPressed && _moveBehaviour.isGrounded)
            _moveBehaviour.SetYVelocity(_jumpVelocity);
    }


}
