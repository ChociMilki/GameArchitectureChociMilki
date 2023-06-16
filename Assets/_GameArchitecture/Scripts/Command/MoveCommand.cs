using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
/// <summary>
/// inherits from command abstract class
/// construct a new object based on agent and destination 
/// 
/// </summary>
public class MoveCommand : Command
{
    private NavMeshAgent _agent;
    //v3 over transform since we only need destination points 
    private Vector3 _destination; 
    /// <summary>
    /// constructor - 
    /// </summary>
    /// <param name="agent"></param>
    /// <param name="destination"></param>
    public MoveCommand(NavMeshAgent agent, Vector3 destination)
    {
        //reference for each time this function is called 
        _agent = agent;
        _destination = destination;
    }

    public override bool isComplete => HasReachedDestination(); 

    public override void Execute()
    {
        _agent.SetDestination(_destination); 
    }
/// <summary>
/// checks with guard close if distance for agent is greater than x value 
/// </summary>
/// <returns></returns>
bool HasReachedDestination()
    {
        if (_agent.remainingDistance > 0.1f) return false; // gaurd clause 
        {
            return true; 
        }
}
}
