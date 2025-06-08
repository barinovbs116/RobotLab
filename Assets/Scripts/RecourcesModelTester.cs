using UnityEngine;

public class ResourcesModelTester : MonoBehaviour
{
    public string[] modelNames = { "articulated_robot", "cartesian_robot", "delta_robot" };

    void Start()
    {
        Debug.Log("=== ���� �������� ������� �� Resources/Models ===");

        foreach (string name in modelNames)
        {
            GameObject model = Resources.Load<GameObject>("Models/" + name);
            if (model != null)
            {
                Debug.Log($"��������� �������: {name}");
            }
            else
            {
                Debug.LogError($"�� ������� ���������: {name}");
            }
        }

        Debug.Log("=== ����� ����� ===");
    }
}
