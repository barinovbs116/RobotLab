using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSampleScene : MonoBehaviour
{
    public void GoBack()
    {
        
        PlayerPrefs.SetInt("GoToRobotsPanel", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("SampleScene");
    }
}
