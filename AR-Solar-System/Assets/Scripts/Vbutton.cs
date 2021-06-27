using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class Vbutton : MonoBehaviour
{
    public VirtualButtonBehaviour vbObj;
    public GameObject planet, planet2, planet3, planet4, planet5, planet6, planet7, planet8;
    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        //vbObj2 = GameObject.Find("EarthButton");
        vbObj.RegisterOnButtonPressed(OnButtonPressed);
        vbObj.RegisterOnButtonReleased(OnButtonNotPressed);
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
        planet.SetActive(false);
        planet2.SetActive(false);
        planet3.SetActive(false);
        planet4.SetActive(false);
        planet5.SetActive(false);
        planet6.SetActive(false);
        planet7.SetActive(false);
        planet8.SetActive(false);

    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //SceneManager.LoadScene("3DMercury");
        planet.SetActive(true);
        planet2.SetActive(false);
        planet3.SetActive(false);
        planet4.SetActive(false);
        planet5.SetActive(false);
        planet6.SetActive(false);
        planet7.SetActive(false);
        planet8.SetActive(false);
        Debug.Log("Button Pressed");
    }
    public void OnButtonNotPressed(VirtualButtonBehaviour vb)
    { 
        Debug.Log("Button Not Pressed");
        planet.SetActive(true);
        planet2.SetActive(true);
        planet3.SetActive(true);
        planet4.SetActive(true);
        planet5.SetActive(true);
        planet6.SetActive(true);
        planet7.SetActive(true);
        planet8.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
