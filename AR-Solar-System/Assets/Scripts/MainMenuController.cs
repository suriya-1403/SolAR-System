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

    // Update is called once per frame
    public void QuitButton()
    {
        Debug.LogError("AR System Stopped");
        Application.Quit();
    }
}
