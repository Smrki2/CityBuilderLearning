using JetBrains.Annotations;
using UnityEngine;

public abstract class Building : MonoBehaviour 
{
    [SerializeField] private BuildingDataSO buildingDataSO;

    public BuildingDataSO BuildingDataSO => buildingDataSO;

    public abstract bool TryTakeResource(ResourceType resourceType, float amount);
    public abstract void AddResource(ResourceType resourceType, float amount);
    public abstract bool HasResource(ResourceType resourceType, float amount);
    public abstract bool HasSpace(float amount);

}
