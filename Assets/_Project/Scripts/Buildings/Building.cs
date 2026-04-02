using UnityEngine;

public class Building : MonoBehaviour 
{
    [SerializeField] private BuildingDataSO buildingDataSO;

    public BuildingDataSO BuildingDataSO => buildingDataSO;
}
