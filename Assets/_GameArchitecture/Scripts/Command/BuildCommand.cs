using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// sets up what is doing the command and what the command is 
/// 
/// </summary>
public class BuildCommand : Command
{
        private Builder _builder;
    private NavMeshAgent _agent;
    private NavMeshAgent agent;
    private Builder builder;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="agent"></param>
    public BuildCommand(Builder builder, NavMeshAgent agent)
    {
        _builder = builder;
        _agent = agent;
    }

    public BuildCommand(NavMeshAgent agent, Builder builder)
    {
        this.agent = agent;
        this.builder = builder;
    }

    public override bool IsComplete => IsBuildComplete();
    bool  IsBuildComplete()
    {
        if(_agent.remainingDistance > 0.1f) return false;
        if(_builder != null )
        {
            _builder.Build(); 
        }
        return true; 
    }

    public override void Execute()
    {
        _agent.SetDestination(_builder.transform.position); 
    }
}
