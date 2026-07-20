using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingPlacer : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private InputActionReference placeBuildingAction;
    [SerializeField] private GameObject constructionSitePrefab;
    [SerializeField] LayerMask layerMask;

    private BuildingDataSO selectedBuilding;
    private Ray ray;
    private GameObject placedBuilding;

    private RaycastHit hit;
    private bool demolishMode = false;
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
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground") && !demolishMode)
            {
                if (selectedBuilding == null)
                    return;
                Vector2Int pos = new Vector2Int((int)Mathf.Floor(hit.point.x), (int)Mathf.Floor(hit.point.z));
                if (pos.x >= 0 && pos.x < GridSystem.instance.gridSize.x && pos.y >= 0 && pos.y < GridSystem.instance.gridSize.y)
                    if (!GridSystem.instance.GetCellState(pos))
                    {
                        if (ResourceManager.instance.CheckResourceAvailability(selectedBuilding.resourceTypeCost, selectedBuilding.resourceCost))
                        {
                            Vector3 place = new Vector3(GridSystem.instance.GetCell(pos).cellPosition.x + 0.5f, constructionSitePrefab.GetComponent<Renderer>().bounds.size.y / 2, GridSystem.instance.GetCell(pos).cellPosition.y + 0.5f);
                            placedBuilding = Instantiate(constructionSitePrefab, place, constructionSitePrefab.transform.rotation);
                            placedBuilding.GetComponent<ConstructionSite>().GridPosition = pos;
                            placedBuilding.GetComponent<ConstructionSite>().Initialize(selectedBuilding);
                        }
                    }
            }
            else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Building") && demolishMode)
            {
                Building building = hit.collider.gameObject.GetComponent<Building>();
                if (building == null) return;
                GridSystem.instance.GetCell(building.GridPosition).isUsed = false;
                Destroy(hit.collider.gameObject);
            }
        }
    }


    private void Update()
    {
        ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);
    }

    public void SelectBuilding(BuildingDataSO clickedBuilding)
    {
        demolishMode = false;
        selectedBuilding = clickedBuilding;
    }

    public void SetDemolishMode()
    {
        demolishMode = true;
    }
}
