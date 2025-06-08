using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RobotListUI : MonoBehaviour
{
    [System.Serializable]
    public class RobotData
    {
        public string name;
        public string modelName;
        public Sprite previewImage;
        public string description;
    }

    public RobotData[] robots;

    public GameObject robotCardPrefab;
    public Transform contentPanel;

    public RobotDescriptionManager descriptionManager; // 👈 Добавили ссылку

    private void Start()
    {
        foreach (RobotData robot in robots)
        {
            GameObject card = Instantiate(robotCardPrefab);
            card.transform.SetParent(contentPanel, false);

            Image image = card.transform.Find("Image").GetComponent<Image>();
            image.sprite = robot.previewImage;

            TextMeshProUGUI nameText = card.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            nameText.text = robot.name;

            // 📌 Кнопка "Подробнее"
            Button moreButton = card.transform.Find("Button").GetComponent<Button>();
            TextMeshProUGUI buttonText = card.transform.Find("Button/Text (TMP)").GetComponent<TextMeshProUGUI>();
            buttonText.text = "Подробнее";

            // 👇 Добавим вызов менеджера описания
            moreButton.onClick.AddListener(() =>
            {
                descriptionManager.ShowDescription(robot.name, robot.description);
            });

            // 📌 Кнопка "3D-визуализация"
            Button view3DButton = card.transform.Find("BtnView3D").GetComponent<Button>();
            view3DButton.onClick.AddListener(() =>
            {
                Debug.Log($"Открытие 3D-визуализации для: {robot.modelName}");

                PlayerPrefs.SetString("SelectedRobotModel", robot.modelName);
                SceneManager.LoadScene("RobotViewScene");
            });
        }
    }
}
