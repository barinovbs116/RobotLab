using UnityEngine;
using TMPro; 
using UnityEngine.UI;
public class RobotDescriptionManager : MonoBehaviour
{
    public GameObject descriptionPanel;
    public TMP_Text titleText;       // Название робота
    public TMP_Text descriptionText; // Описание робота

    public void ShowDescription(string robotName, string description)
    {
        descriptionPanel.SetActive(true);
        titleText.text = robotName;
        descriptionText.text = description;
    }

    public void HideDescription()
    {
        descriptionPanel.SetActive(false);
    }
}
