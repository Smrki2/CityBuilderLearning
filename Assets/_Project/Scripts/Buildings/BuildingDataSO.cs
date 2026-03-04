using UnityEngine;

[CreateAssetMenu(fileName ="NewBuildingDataSO", menuName ="CityBuilder/Building Data")]
public class BuildingDataSO : ScriptableObject
{
    public string buildingName;
    public GameObject buildingPrefab;
    public Vector2Int buildingSize;
    public ResourceType resourceTypeProduction;
    public float resourceProduction;
    public ResourceType resourceTypeConsumption;
    public float resourceConsumption;
    public ResourceType resourceTypeCost;
    public float resourceCost;
}
