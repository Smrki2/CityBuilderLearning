using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Camera camera;
    [SerializeField] InputActionReference cameraMovementAction;
    [SerializeField] InputActionReference cameraZoomAction;

    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float zoomSpeed = 1f;

    Vector2 cameraMovement;
    Vector2 cameraZoom;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        if (cameraMovementAction != null && cameraZoomAction != null)
        {
            cameraMovementAction.action.Enable();
            cameraZoomAction.action.Enable();
        }
    }

    private void Update()
    {
        cameraMovement = cameraMovementAction.action.ReadValue<Vector2>();
        cameraZoom = cameraZoomAction.action.ReadValue<Vector2>();

        Vector3 tempCamMov = new Vector3(cameraMovement.x, 0, cameraMovement.y);
        camera.transform.position += tempCamMov * movementSpeed * Time.deltaTime;

        Vector3 tempCamZoom = new Vector3(0, cameraZoom.y, 0);
        camera.transform.position -= tempCamZoom * zoomSpeed * Time.deltaTime;
    }
}
