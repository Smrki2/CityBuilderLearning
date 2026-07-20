using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    public event System.Action OnResourcesChanged;
    private List<StorageBuilding> storageBuildings = new List<StorageBuilding>();
    public void NotifyResourcesChanged() => OnResourcesChanged?.Invoke();
    public void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterStorage(StorageBuilding storageBuilding)
    {
        if (!storageBuildings.Contains(storageBuilding))
        {
            storageBuildings.Add(storageBuilding);
        }
    }
    public void UnregisterStorage(StorageBuilding storageBuilding)
    {
        if (storageBuildings.Contains(storageBuilding))
        {
            storageBuildings.Remove(storageBuilding);
        }
    }
    public float GetResourceOfType(ResourceType type)
    {
        float amount = 0f;
        foreach(StorageBuilding storage in storageBuildings)
        {
            amount += storage.GetResourceOfType(type);
        }
        return amount;
    }

    public bool CheckResourceAvailability(ResourceType type, float amount)
    {
        float sum = 0f;
        foreach(StorageBuilding storage in storageBuildings)
        {
            sum += storage.GetResourceOfType(type);
            if (sum >= amount)
                return true;
        }
        return false;
    }
}
