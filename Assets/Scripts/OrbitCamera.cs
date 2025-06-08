using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 4f;
    public float zoomSpeed = 7f;
    public float rotationSpeed = 300f;

    private float currentX = 0f;
    private float currentY = 0f;
    private float currentDistance;

    private float defaultX;
    private float defaultY;
    private float defaultDistance;

    void Start()
    {
        // Сохраняем дефолтное положение при запуске
        defaultX = currentX;
        defaultY = currentY;
        defaultDistance = distance;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // вращение
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");

            currentX += mouseX * rotationSpeed;
            currentY -= mouseY * rotationSpeed;
            currentY = Mathf.Clamp(currentY, -80f, 80f);
        }

        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, 2f, 20f);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 dir = new Vector3(0, 0, -distance);
        transform.position = target.position + rotation * dir;
        transform.LookAt(target.position);
    }

    public void ResetView()
    {
        currentX = defaultX;
        currentY = defaultY;
        distance = defaultDistance;
    }

    public void SetCustomView(Vector3 position)
    {
        transform.position = position;
        transform.LookAt(target.position);
        currentDistance = Vector3.Distance(transform.position, target.position);
    }

    public void AlignX() => currentY = 0f;
    public void AlignY() => currentY = 90f;
    public void AlignZ() => currentX = 0f;
}
