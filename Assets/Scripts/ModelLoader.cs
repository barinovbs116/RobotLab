using UnityEngine;
using UnityEngine.UI;

public class ModelLoader : MonoBehaviour
{
    public Transform modelHolder;
    public Text robotNameText;

    public float targetSize = 2f; // Целевой размер модели на экране

    void Start()
    {
        string selectedModel = PlayerPrefs.GetString("SelectedRobotModel", "");

        if (string.IsNullOrEmpty(selectedModel))
        {
            Debug.LogError("Не выбрана модель для отображения.");
            return;
        }

        GameObject modelPrefab = Resources.Load<GameObject>("Models/" + selectedModel);

        if (modelPrefab == null)
        {
            Debug.LogError("Не удалось загрузить префаб модели: " + selectedModel);
            return;
        }

        GameObject modelInstance = Instantiate(modelPrefab, modelHolder);
        modelInstance.transform.localPosition = Vector3.zero;
        modelInstance.transform.localRotation = Quaternion.identity;

        NormalizeScale(modelInstance);

        if (robotNameText != null)
        {
            robotNameText.text = "Робот: " + selectedModel;
        }

        FocusCameraOnModel(modelInstance);
    }

    void NormalizeScale(GameObject model)
    {
        Renderer[] renderers = model.GetComponentsInChildren<Renderer>();
        Bounds bounds = new Bounds(model.transform.position, Vector3.zero);

        foreach (Renderer rend in renderers)
        {
            bounds.Encapsulate(rend.bounds);
        }

        float largestSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);

        // Получаем имя модели из PlayerPrefs
        string selectedModel = PlayerPrefs.GetString("SelectedRobotModel", "");
        float manualScale = 1f;

        // Можно подбирать на глаз, чтобы уравнять размеры
        if (selectedModel == "articulated_robot")
            manualScale = 50f;
        else if (selectedModel == "cartesian_robot")
            manualScale = 1f;
        else if (selectedModel == "delta_robot")
            manualScale = 1f;

        float scaleFactor = (targetSize / largestSize) * manualScale;
        model.transform.localScale = Vector3.one * scaleFactor;
    }


    void FocusCameraOnModel(GameObject model)
    {
        OrbitCamera orbitCamera = FindObjectOfType<OrbitCamera>();
        if (orbitCamera != null)
        {
            Bounds bounds = GetModelBounds(model);
            Vector3 center = bounds.center;
            float size = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);

            Vector3 offset = new Vector3(0, size * 0.7f, -size * 1.5f);
            orbitCamera.target = model.transform;
            orbitCamera.SetCustomView(center + offset);
        }
    }

    Bounds GetModelBounds(GameObject model)
    {
        Renderer[] renderers = model.GetComponentsInChildren<Renderer>();
        Bounds bounds = new Bounds(model.transform.position, Vector3.zero);

        foreach (Renderer rend in renderers)
        {
            bounds.Encapsulate(rend.bounds);
        }

        return bounds;
    }
}
