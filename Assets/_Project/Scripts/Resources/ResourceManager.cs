using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    private Dictionary<ResourceType, float> resourceManager;
    public void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        resourceManager = new Dictionary<ResourceType, float>
        { 
            { ResourceType.Wood,20},
            { ResourceType.Stone,15},
            { ResourceType.Water,10},
            { ResourceType.Gold, 5}
        };
    }

    public void Add(ResourceType type, float value)
    {
        resourceManager[type] += value;
    }

    public bool Spend(ResourceType type, float value)
    {
        if (resourceManager[type] >= value)
        {
            resourceManager[type] -= value;
            return true;
        }else 
            { return false; }
    }

    public float Get(ResourceType type)
    {
        return resourceManager[type];
    }
}
