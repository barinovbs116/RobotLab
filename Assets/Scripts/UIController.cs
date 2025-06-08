using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject robotsPanel;

    private void Start()
    {
        // ���������, ����� �� ����� ������� RobotsPanel (��������, ����� �������� �� 3D �����)
        int goToRobots = PlayerPrefs.GetInt("GoToRobotsPanel", 0);

        if (goToRobots == 1)
        {
            // ��������� ������ �������, �������� ������� ����
            mainMenuPanel.SetActive(false);
            robotsPanel.SetActive(true);

            // ���������� ����
            PlayerPrefs.SetInt("GoToRobotsPanel", 0);
            PlayerPrefs.Save();
        }
        else
        {
            // ������� ��������� ��� ������
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
        Debug.Log("����� �� ����������...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ��� ���������
#else
        Application.Quit(); // ��� �����
#endif
    }
}








