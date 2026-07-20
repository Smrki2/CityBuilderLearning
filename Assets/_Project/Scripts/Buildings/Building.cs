using JetBrains.Annotations;
using UnityEngine;

public abstract class Building : MonoBehaviour 
{
    [SerializeField] private BuildingDataSO buildingDataSO;
    public BuildingDataSO BuildingDataSO { get; protected set; }
    public Vector2Int GridPosition { get; set; }

    protected virtual void Awake()
    {
        if (buildingDataSO != null)
            Initialize(buildingDataSO);
    }

    public virtual void Initialize(BuildingDataSO data)
    {
        BuildingDataSO = data;
    }

    public abstract bool TryTakeResource(ResourceType resourceType, float amount);
    public abstract void AddResource(ResourceType resourceType, float amount);
    public abstract bool HasResource(ResourceType resourceType, float amount);
    public abstract bool HasSpace(float amount);
}
