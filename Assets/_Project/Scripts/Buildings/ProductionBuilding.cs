using System.Collections.Concurrent;
using UnityEngine;

public class ProductionBuilding : MonoBehaviour
{
    [SerializeField] BuildingDataSO buildingDataSO;
    float productionTime;
    float buildingCost, buildingProduction, buildingConsumption;
    ResourceType buildingCostType, buildingProductionType, buildingConsumptionType;
    float timer = 0;

    private void Awake()
    {
        buildingCost = buildingDataSO.resourceCost;
        buildingCostType = buildingDataSO.resourceTypeCost;
        ResourceManager.instance.Spend(buildingCostType, buildingCost);
        buildingProduction = buildingDataSO.resourceProduction;
        buildingProductionType = buildingDataSO.resourceTypeProduction;
        buildingConsumption = buildingDataSO.resourceConsumption;
        buildingConsumptionType = buildingDataSO.resourceTypeConsumption;
        productionTime = buildingDataSO.productionTime;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >=  productionTime)
        {
            Produce();
            timer = 0;
        }
    }

    private void Produce()
    {
        ResourceManager.instance.Add(buildingProductionType, buildingProduction);
        ResourceManager.instance.Spend(buildingConsumptionType, buildingConsumption);
    }
}
