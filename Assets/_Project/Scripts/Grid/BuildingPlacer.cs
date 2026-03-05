using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GridSystem gridSystem;

    RaycastHit hit;
    private void Update()
    {
        
        if(Physics.Raycast(camera.transform.position, camera.,out hit, Mathf.Infinity))
        {
            
        }
    }
}
