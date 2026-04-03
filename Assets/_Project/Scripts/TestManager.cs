using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField] Villager villager;
    [SerializeField] Building source;
    [SerializeField] Building target;



    void Start()
    {
        TransportResourceJob job = new TransportResourceJob(source, target, 0, ResourceType.Wood);
        villager.AssignJob(job);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
