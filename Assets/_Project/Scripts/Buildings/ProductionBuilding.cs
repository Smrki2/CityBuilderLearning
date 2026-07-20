using UnityEngine;

public class ProductionBuilding : Building
{
    // ------------ TREBALO BI DA SE NAPRAVI BUILDING KLASA KOJA CE DA BUDE MAIN I DECA BUDU PRODUCTION BUILDINZI ITD OSTALE KLASE BUILDINGA
    private float timer = 0;
    private ResourceContainer inputStorage;
    private ResourceContainer outputStorage;

    public override void Initialize(BuildingDataSO data)
    {
        base.Initialize(data);
        inputStorage = new ResourceContainer(BuildingDataSO.maxCapacity);
        outputStorage = new ResourceContainer(BuildingDataSO.maxCapacity);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >=  BuildingDataSO.productionTime)
        {
            Produce();
            timer = 0;
        }
    }

    private void Produce()
    {
        if (inputStorage.GetAmount(BuildingDataSO.resourceTypeConsumption) >= BuildingDataSO.resourceConsumption && outputStorage.HasSpace(BuildingDataSO.resourceProduction))
        {
            inputStorage.TryTake(BuildingDataSO.resourceTypeConsumption, BuildingDataSO.resourceConsumption);
            outputStorage.Add(BuildingDataSO.resourceTypeProduction, BuildingDataSO.resourceProduction);
        }
    }

    public override bool TryTakeResource(ResourceType resourceType, float amount)
    {
        return outputStorage.TryTake(resourceType, amount);
    }
    public override void AddResource(ResourceType resourceType, float amount)
    {
        inputStorage.Add(resourceType, amount);
    }
    public override bool HasResource(ResourceType resourceType, float amount)
    {
        return outputStorage.GetAmount(resourceType) >= amount;
    }
    public override bool HasSpace(float amount)
    {
        return inputStorage.HasSpace(amount);
    }
}
