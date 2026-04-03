using UnityEngine;

public class ProductionBuilding : Building
{
    // ------------ TREBALO BI DA SE NAPRAVI BUILDING KLASA KOJA CE DA BUDE MAIN I DECA BUDU PRODUCTION BUILDINZI ITD OSTALE KLASE BUILDINGA
    private float productionTime;
    private float buildingCost, buildingProductionAmount, buildingConsumptionAmount;
    private ResourceType buildingCostType, buildingProductionType, buildingConsumptionType;
    private float timer = 0;
    private float inputCapacity, outputCapacity;
    private ResourceContainer inputStorage;
    private ResourceContainer outputStorage;

    private void Awake()
    {
        buildingCost = BuildingDataSO.resourceCost;
        buildingCostType = BuildingDataSO.resourceTypeCost;
        buildingProductionAmount = BuildingDataSO.resourceProduction;
        buildingProductionType = BuildingDataSO.resourceTypeProduction;
        buildingConsumptionAmount = BuildingDataSO.resourceConsumption;
        buildingConsumptionType = BuildingDataSO.resourceTypeConsumption;
        productionTime = BuildingDataSO.productionTime;
        inputCapacity = BuildingDataSO.maxCapacity;
        outputCapacity = BuildingDataSO.maxCapacity;
        inputStorage = new ResourceContainer(inputCapacity);
        outputStorage = new ResourceContainer(outputCapacity);
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
        if (inputStorage.GetAmount(buildingConsumptionType) >= buildingConsumptionAmount && outputStorage.HasSpace(buildingProductionAmount))
        {
            inputStorage.TryTake(buildingConsumptionType, buildingConsumptionAmount);
            outputStorage.Add(buildingProductionType, buildingProductionAmount);
        }
    }
}
