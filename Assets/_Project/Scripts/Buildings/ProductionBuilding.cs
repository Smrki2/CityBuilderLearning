using System.Collections.Concurrent;
using UnityEngine;

public class ProductionBuilding : MonoBehaviour
{
    // ------------ TREBALO BI DA SE NAPRAVI BUILDING KLASA KOJA CE DA BUDE MAIN I DECA BUDU PRODUCTION BUILDINZI ITD OSTALE KLASE BUILDINGA
    [SerializeField] BuildingDataSO buildingDataSO;
    float productionTime;
    float buildingCost, buildingProduction, buildingConsumption;
    ResourceType buildingCostType, buildingProductionType, buildingConsumptionType;
    float timer = 0;

    private void Awake()
    {
        buildingCost = buildingDataSO.resourceCost;
        buildingCostType = buildingDataSO.resourceTypeCost;
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
