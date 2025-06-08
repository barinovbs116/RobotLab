using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    public void LoadRobotListScene()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void LoadRobotViewScene()
    {
        SceneManager.LoadScene("RobotViewScene");
    }

    
    void Update()
    {
        
    }
}
