using System.Collections.Generic;
using System.Linq;

public class ResourceContainer
{
    private Dictionary<ResourceType, float> resourceStorage;
    private float maxCapacity;

    public ResourceContainer(float maxCapacity)
    {
        this.maxCapacity = maxCapacity;
        resourceStorage = new Dictionary<ResourceType, float>();
    }

    public void Add(ResourceType type, float amount)
    {
        if (!HasSpace(amount))
            return;
        if (!resourceStorage.ContainsKey(type))
        {
            resourceStorage.Add(type, amount);
        }
        else
        {
            resourceStorage[type] += amount;
        }
    }

    public bool TryTake(ResourceType type, float amount) 
    { 
        if(resourceStorage.ContainsKey(type) && resourceStorage[type] >= amount)
        {
            resourceStorage[type]-=amount;
            return true;
        }
        else 
            { return false; }
    }

    public float GetAmount(ResourceType type)
    {
        if(resourceStorage.ContainsKey(type))
        {
            return resourceStorage[type];
        }
        else 
            { return 0f; }
    }

    public bool HasSpace(float amount)
    {
        if (maxCapacity - resourceStorage.Values.Sum() >= amount)
            return true;
        else 
            return false;
    }
}
