using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// storagehouse for commands we want to execute 
/// queue to keep track of commands 
/// 
/// </summary>
public class CommandInteractor : MonoBehaviour
{
    Queue<Command> _commands = new Queue<Command>();
}
