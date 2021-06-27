using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        Debug.Log("AR System is Loading...");
        SceneManager.LoadScene("SampleScene");
    }
    public void threeDButton()
    {
        Debug.Log("3D System is Loading...");
        SceneManager.LoadScene("View3D");
    }
    // Update is called once per frame
    public void QuitButton()
    {
        Debug.LogError("Application System Stopped");
        Application.Quit();
    }
}
