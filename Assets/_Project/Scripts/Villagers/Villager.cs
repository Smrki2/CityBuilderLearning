using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
    private NavMeshAgent agent;
    public Job CurrentJob {  get; private set; }
    private bool isMoving;
    private ResourceType carriedResourceType;
    private float carriedAmount;
    [SerializeField] float maxCarryCapacity;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        JobManager.instance.AddVillager(this);
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
    public void PickUpResource(ResourceType resourceType, float amount)
    {
        carriedResourceType = resourceType;
        carriedAmount = Mathf.Min(amount, maxCarryCapacity);
    }
    public float DropOffResource()
    {
        float tempAmount = carriedAmount;
        carriedAmount = 0;
        return tempAmount;
    }
    public float GetCarriedAmount() {  return carriedAmount; }
}
