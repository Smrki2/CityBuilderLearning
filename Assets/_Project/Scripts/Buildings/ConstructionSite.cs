using UnityEngine;

public class ConstructionSite : Building
{
    private ResourceContainer storage;
    private float maxCapacity;
    private GameObject placedBuilding;

    protected override void Awake() { }
    public void SetBuildData(BuildingDataSO buildingDataSO)
    {
        BuildingDataSO = buildingDataSO;
        maxCapacity = BuildingDataSO.resourceCost;
        storage = new ResourceContainer(maxCapacity);
    }

    public override void AddResource(ResourceType type, float value)
    {
        storage.Add(type, value);
        if(!storage.HasSpace(1))
        {
            placedBuilding = Instantiate(BuildingDataSO.buildingPrefab, transform.position, BuildingDataSO.buildingPrefab.transform.rotation);
            Vector2Int gridPos = GetComponent<BuildingInstance>().GridPosition;
            GridSystem.instance.GetCell(gridPos).building = placedBuilding;
            GridSystem.instance.GetCell(gridPos).buildingType = BuildingDataSO;
            GridSystem.instance.GetCell(gridPos).isUsed = true;
            Destroy(gameObject);
        }
    }

    public override bool TryTakeResource(ResourceType type, float value)
    {
        return false;
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
