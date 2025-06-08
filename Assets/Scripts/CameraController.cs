using UnityEngine;

public class CameraController : MonoBehaviour
{
    public OrbitCamera orbitCamera;

    public void OnResetCameraButtonClicked()
    {
        if (orbitCamera != null)
        {
            orbitCamera.ResetView();
        }
    }
}
