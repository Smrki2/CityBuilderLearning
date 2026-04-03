using UnityEngine;
public class StorageBuilding : Building
{
    private float maxCapacity;
    private ResourceContainer storage;

    private void Awake()
    {
        maxCapacity = BuildingDataSO.maxCapacity;
        storage = new ResourceContainer(maxCapacity);
    }

    public void Add(ResourceType type, float value)
    {
        storage.Add(type, value);
    }

    public bool TryTake(ResourceType type, float value)
    {
        return storage.TryTake(type, value);
    }

    public float GetAmount(ResourceType type)
    {
        return storage.GetAmount(type);
    }

    public bool HasSpace(float value)
    {
        return storage.HasSpace(value);
    }
}
