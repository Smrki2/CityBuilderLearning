using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    [SerializeField] private BuildingDataSO buildingData;
    [SerializeField] private BuildingPlacer buildingPlacer;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        buildingPlacer.SelectBuilding(buildingData);
    }
}
