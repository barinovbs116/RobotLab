using UnityEngine;

public class ResourcesModelTester : MonoBehaviour
{
    public string[] modelNames = { "articulated_robot", "cartesian_robot", "delta_robot" };

    void Start()
    {
        Debug.Log("=== Тест загрузки моделей из Resources/Models ===");

        foreach (string name in modelNames)
        {
            GameObject model = Resources.Load<GameObject>("Models/" + name);
            if (model != null)
            {
                Debug.Log($"Загружено успешно: {name}");
            }
            else
            {
                Debug.LogError($"Не удалось загрузить: {name}");
            }
        }

        Debug.Log("=== Конец теста ===");
    }
}
