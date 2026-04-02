using System.Collections.Generic;
using System.Linq;

public class StorageBuilding : Building
{
    private Dictionary<ResourceType, float> storage;
    private float maxCapacity;

    private void Awake()
    {
        storage = new Dictionary<ResourceType, float>();
        maxCapacity = BuildingDataSO.maxCapacity;
    }

    public void Add(ResourceType type, float value)
    {
        if (storage.ContainsKey(type))
        {
            storage[type] += value;
        }
        else
        {
            storage[type] = value;
        }
    }

    public bool Take(ResourceType type, float value)
    {
        if (!storage.ContainsKey(type))
        {
            storage[type] = 0;
        }
        if (storage[type] >= value)
        {
            storage[type] -= value;
            return true;
        }
        else
            return false;
    }

    public float GetResourceAmount(ResourceType type)
    {
        if (!storage.ContainsKey(type))
        {
            storage[type] = 0;
        }
        return storage[type];
    }

    public bool HasSpace(float value)
    {
        float storageSum = storage.Values.Sum();
        if (maxCapacity - storageSum > value)
            return true;
        else 
            return false;
    }
}
