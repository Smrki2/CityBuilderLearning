using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GridSystem gridSystem;
    [SerializeField] private InputAction placeBuildingAction;
    [SerializeField] private BuildingDataSO prefab;

    private GameObject placedBuilding;
    RaycastHit hit;
    private void Awake()
    {
        placeBuildingAction.Enable();

        placeBuildingAction.performed += OnPlaceBuildingPerformed;
    }

    private void OnPlaceBuildingPerformed(InputAction.CallbackContext context)
    {
        Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            Vector2Int pos = new Vector2Int((int)Mathf.Floor(hit.point.x), (int)Mathf.Floor(hit.point.z));

            if(!gridSystem.GetCellState(pos))
            {
                Vector3 place = new Vector3(gridSystem.GetCell(pos).cellPosition.x, 0, gridSystem.GetCell(pos).cellPosition.y);
                placedBuilding = Instantiate(prefab.buildingPrefab, place, prefab.buildingPrefab.transform.rotation);
                gridSystem.GetCell(pos).isUsed = true;
                gridSystem.GetCell(pos).building = placedBuilding;
                gridSystem.GetCell(pos).buildingType = prefab;
            }
        }
    }
}
