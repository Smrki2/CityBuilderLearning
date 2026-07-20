using UnityEngine;

public class ConstructionSite : Building
{
    private ResourceContainer storage;
    private GameObject placedBuilding;

    public override void Initialize(BuildingDataSO data)
    {
        base.Initialize(data);
        storage = new ResourceContainer(BuildingDataSO.resourceCost);
    }

    public override void AddResource(ResourceType type, float value)
    {
        storage.Add(type, value);
        if(!storage.HasSpace(1))
        {
            Vector2Int gridPos = GridPosition;
            placedBuilding = Instantiate(BuildingDataSO.buildingPrefab, transform.position, BuildingDataSO.buildingPrefab.transform.rotation);
            placedBuilding.GetComponent<Building>().GridPosition = gridPos;
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
