using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor : MonoBehaviour
{
    [SerializeField] protected PlayerInput _input;
    // Start is called before the first frame update

    void Update()
    {
        Interact();
    }

    public abstract void Interact();
}
