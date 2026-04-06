using UnityEngine;
public class StorageBuilding : Building
{
    [SerializeField] private ResourceType debugType;
    [SerializeField] private float debugAmount;
    private float maxCapacity;
    private ResourceContainer storage;

    private void Awake()
    {
        maxCapacity = BuildingDataSO.maxCapacity;
        storage = new ResourceContainer(maxCapacity);
    }
    private void Update()
    {
        Debug.Log($"{gameObject.name} ima {storage.GetAmount(debugType)}");
    }

    public override void AddResource(ResourceType type, float value)
    {
        storage.Add(type, value);
    }

    public override bool TryTakeResource(ResourceType type, float value)
    {
        return storage.TryTake(type, value);
    }

    public override bool HasResource(ResourceType type, float amount)
    {
        return storage.GetAmount(type) >= amount;
    }

    public override bool HasSpace(float value)
    {
        return storage.HasSpace(value);
    }
}
