using UnityEngine;

[CreateAssetMenu(fileName ="NewBuildingDataSO", menuName ="CityBuilder/Building Data")]
public class BuildingDataSO : ScriptableObject
{
    //TODO: recipe sistem gde se ovde cuva lista structure fajlova koji sadrze tip i vrednost u slucaju da se koristi vise razlicitih resursa da se napravi jedan
    public string buildingName;
    public GameObject buildingPrefab;
    public Vector2Int buildingSize;
    public ResourceType resourceTypeProduction;
    public float resourceProduction;
    public ResourceType resourceTypeConsumption;
    public float resourceConsumption;
    public ResourceType resourceTypeCost;
    public float resourceCost;
    public float productionTime;
}

