using UnityEngine;

public abstract class Job
{
    public bool isAssigned;
    public bool isCompleted;

    public Job(){}

    public abstract void Execute(Villager villager);
    public abstract Vector3 GetDestination();
}
