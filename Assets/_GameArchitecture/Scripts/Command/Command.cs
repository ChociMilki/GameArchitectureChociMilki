using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
/// <summary>
/// an abstract class that detaches implementation
///  to change commands as we like
/// </summary>
public abstract class Command 
{
    //method allowing command execution that allows friend raycast onto ground that spawn prefab for our friend to move to 
    public abstract void Execute(); 
    public abstract bool isComplete { get;  }
}
