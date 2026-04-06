using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    [SerializeField] private Building source;
    [SerializeField] private Building target;
    public static JobManager instance;
    private List<Villager> villagerList;
    private List<Job> jobList;

    private void Start()
    {
        source.AddResource(ResourceType.Wood, 50);

        AddJob(new TransportResourceJob(
            source,
            target,
            10,
            ResourceType.Wood
        ));
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
        villagerList = new List<Villager>();
        jobList = new List<Job>();
    }
    private void Update()
    {
        AssignJobs();
    }

    public void AddJob(Job job)
    {
        jobList.Add(job);
    }

    public void AddVillager(Villager villager)
    {
        villagerList.Add(villager);
    }

    private void AssignJobs()
    {
        foreach(Villager villager in villagerList)
        {
            if (villager.CurrentJob == null)
            {
                foreach (Job job in jobList)
                {
                    if (!job.isAssigned)
                    {
                        villager.AssignJob(job);
                        job.isAssigned = true;
                        break;
                    }
                }
            }
        }
    }
}
