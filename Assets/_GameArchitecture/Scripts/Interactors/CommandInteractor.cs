using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// storagehouse for commands we want to execute 
/// queue to keep track of commands , will be present in scene 
/// 
/// </summary>
public class CommandInteractor : Interactor
{
    Queue<Command> _commands = new Queue<Command>();
    [Header("Position Spawn Elements")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject positionPrefab;
    [SerializeField] private Camera _cam;

    private Command _currentCommand;
    /// <summary>
    /// based on user input 
    /// </summary>
    public override void Interact()
    {
        if (_input.commandPressed)
        {
            Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out var hitInfo))
            {
                if (hitInfo.transform.CompareTag("Ground"))
                { 
                    GameObject spawnPositionPrefab = Instantiate(positionPrefab);
                spawnPositionPrefab.transform.position = hitInfo.point;
                    _commands.Enqueue(new MoveCommand(_agent, hitInfo.point)); 
                
                }
                

            }            
        }
    }
}
