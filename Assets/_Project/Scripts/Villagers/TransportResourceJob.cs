using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;

public class TransportResourceJob : Job
{
    private Building source;
    private Building target;
    private float amount;
    private ResourceType resourceType;
    public JobPhase jobPhase = JobPhase.GoingToSource;

    public TransportResourceJob(Building source, Building target, float amount, ResourceType resourceType)
    {
        this.source = source;
        this.target = target;
        this.amount = amount;
        this.resourceType = resourceType;
    }

    public override Vector3 GetDestination()
    {
        if (jobPhase == JobPhase.GoingToSource)
        {
            return source.transform.position;
        }
        if (jobPhase == JobPhase.GoingToTarget)
        {
            return target.transform.position;
        }
        return Vector3.zero;
    }

    public override void Execute(Villager villager)
    {
        if (jobPhase == JobPhase.GoingToSource)
        {
            jobPhase = JobPhase.GoingToTarget;
        }
        else if (jobPhase == JobPhase.GoingToTarget)
        {
            isCompleted = true;
            //end job
        }

    }
    public enum JobPhase
    {
        GoingToSource,
        GoingToTarget
    }
}

