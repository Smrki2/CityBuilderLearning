using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
    private NavMeshAgent agent;
    public Job CurrentJob {  get; private set; }
    private bool isMoving;
    private ResourceType carriedResourceType;
    private float carriedAmount;
    private float maxCarryCapacity;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(CurrentJob != null && !isMoving)
        {
            GoToDestination(CurrentJob.GetDestination());
        }
        if(CurrentJob != null && agent.hasPath && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            isMoving = false;
            CurrentJob.Execute(this);
            if(CurrentJob.isCompleted)
                CurrentJob = null;
        }
    }
    public void AssignJob(Job job)
    {
        CurrentJob = job;
    }

    public void GoToDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
        isMoving = true;
    }
}
