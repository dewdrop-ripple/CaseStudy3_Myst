using UnityEngine;

public class SC_CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private float cameraSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float FOV;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // Movement
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 moveDirection = mainCamera.transform.forward;
                moveDirection *= cameraSpeed * Time.deltaTime;
                mainCamera.transform.position += moveDirection;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 moveDirection = mainCamera.transform.forward;
                moveDirection *= -1 * cameraSpeed * Time.deltaTime;
                mainCamera.transform.position += moveDirection;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 moveDirection = mainCamera.transform.right;
                moveDirection *= cameraSpeed * Time.deltaTime;
                mainCamera.transform.position += moveDirection;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 moveDirection = mainCamera.transform.right;
                moveDirection *= -1 * cameraSpeed * Time.deltaTime;
                mainCamera.transform.position += moveDirection;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Vector3 moveDirection = Vector3.up;
                moveDirection *= cameraSpeed * Time.deltaTime;
                mainCamera.transform.position += moveDirection;
            }
            if (Input.GetKey(KeyCode.E))
            {
                Vector3 moveDirection = Vector3.down;
                moveDirection *= cameraSpeed * Time.deltaTime;
                mainCamera.transform.position += moveDirection;
            }

            rotation.x += Input.GetAxis(xAxis) * rotationSpeed;
            rotation.y += Input.GetAxis(yAxis) * rotationSpeed;
            rotation.y = Mathf.Clamp(rotation.y, -85, 85);
            var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
            var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

            mainCamera.transform.localRotation = xQuat * yQuat;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
