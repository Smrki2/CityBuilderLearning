using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingPlacer : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private GridSystem gridSystem;
    [SerializeField] private InputActionReference placeBuildingAction;
    [SerializeField] private BuildingDataSO prefab;
    [SerializeField] LayerMask layerMask;

    private Ray ray;
    private GameObject placedBuilding;
    RaycastHit hit;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        placeBuildingAction.action.Enable();

        placeBuildingAction.action.performed += OnPlaceBuildingPerformed;
    }

    private void OnPlaceBuildingPerformed(InputAction.CallbackContext context)
    {
        ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit,Mathf.Infinity,layerMask))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Vector2Int pos = new Vector2Int((int)Mathf.Floor(hit.point.x), (int)Mathf.Floor(hit.point.z));
                if (pos.x >= 0 && pos.x < gridSystem.gridSize.x && pos.y >= 0 && pos.y < gridSystem.gridSize.y)
                    if (!gridSystem.GetCellState(pos))
                    {
                        Vector3 place = new Vector3(gridSystem.GetCell(pos).cellPosition.x + 0.5f, prefab.buildingPrefab.GetComponent<Renderer>().bounds.size.y / 2, gridSystem.GetCell(pos).cellPosition.y + 0.5f);
                        placedBuilding = Instantiate(prefab.buildingPrefab, place, prefab.buildingPrefab.transform.rotation);
                        gridSystem.GetCell(pos).isUsed = true;
                        gridSystem.GetCell(pos).building = placedBuilding;
                        gridSystem.GetCell(pos).buildingType = prefab;
                    }
                Debug.Log("Hit point: " + hit.point);
                Debug.Log("Grid pos: " + pos);
            }
        }
    }
    private void Update()
    {
        ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);
    }

}
