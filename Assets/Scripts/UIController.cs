using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject robotsPanel;

    private void Start()
    {
        // Проверяем, нужно ли сразу открыть RobotsPanel (например, после возврата из 3D сцены)
        int goToRobots = PlayerPrefs.GetInt("GoToRobotsPanel", 0);

        if (goToRobots == 1)
        {
            // Открываем панель роботов, скрываем главное меню
            mainMenuPanel.SetActive(false);
            robotsPanel.SetActive(true);

            // Сбрасываем флаг
            PlayerPrefs.SetInt("GoToRobotsPanel", 0);
            PlayerPrefs.Save();
        }
        else
        {
            // Обычное поведение при старте
            mainMenuPanel.SetActive(true);
            robotsPanel.SetActive(false);
        }
    }

    public void OnRobotsButtonClicked()
    {
        mainMenuPanel.SetActive(false);
        robotsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        robotsPanel.SetActive(false);
    }

    public void ExitApplication()
    {
        Debug.Log("Выход из приложения...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // для редактора
#else
        Application.Quit(); // для билда
#endif
    }
}








