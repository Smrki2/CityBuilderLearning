using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProductionBuilding : MonoBehaviour
{
    // ------------ TREBALO BI DA SE NAPRAVI BUILDING KLASA KOJA CE DA BUDE MAIN I DECA BUDU PRODUCTION BUILDINZI ITD OSTALE KLASE BUILDINGA
    [SerializeField] BuildingDataSO buildingDataSO;
    private float productionTime;
    private float buildingCost, buildingProduction, buildingConsumption;
    private ResourceType buildingCostType, buildingProductionType, buildingConsumptionType;
    private float timer = 0;
    private float inputCapacity, outputCapacity;
    private Dictionary<ResourceType, float> inputStorage;
    private Dictionary<ResourceType, float> outputStorage;

    private void Awake()
    {
        buildingCost = buildingDataSO.resourceCost;
        buildingCostType = buildingDataSO.resourceTypeCost;
        buildingProduction = buildingDataSO.resourceProduction;
        buildingProductionType = buildingDataSO.resourceTypeProduction;
        buildingConsumption = buildingDataSO.resourceConsumption;
        buildingConsumptionType = buildingDataSO.resourceTypeConsumption;
        productionTime = buildingDataSO.productionTime;
        inputCapacity = buildingDataSO.maxCapacity;
        outputCapacity = buildingDataSO.maxCapacity;
        inputStorage = new Dictionary<ResourceType, float>();
        outputStorage = new Dictionary<ResourceType, float>();
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
        float currentInput = inputStorage.Values.Sum();
        if (currentInput < buildingConsumption)
            return;
        float currentOutput = outputStorage.Values.Sum();
        if (currentOutput + buildingProduction > outputCapacity)
            return;

        if (outputStorage.ContainsKey(buildingProductionType))
        {
            outputStorage[buildingProductionType] += buildingProduction;
        }
        else
        {
            outputStorage[buildingProductionType] = buildingProduction;
        }

        ResourceManager.instance.Add(buildingProductionType, buildingProduction);
        ResourceManager.instance.Spend(buildingConsumptionType, buildingConsumption);
    }
}
