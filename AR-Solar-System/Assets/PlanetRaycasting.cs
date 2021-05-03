using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetRaycasting : MonoBehaviour
{
    string btName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Testing1.1");
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            //Debug.Log("Testing1.5");
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Testing2.1");
                btName = hit.transform.name;
                switch (btName)
                {
                    case "Sun":
                        SceneManager.LoadScene("PlanetSun");
                        break;
                    case "Venus":
                        SceneManager.LoadScene("PlanetVenus");
                        break;
                    case "Mercury":
                        SceneManager.LoadScene("PlanetMercury");
                        break;
                    case "Earth":
                        SceneManager.LoadScene("PlanetEarth");
                        break;
                    case "Mars":
                        SceneManager.LoadScene("PlanetMars");
                        break;
                    case "Jupiter":
                        SceneManager.LoadScene("PlanetJupiter");
                        break;
                    case "Saturn":
                        SceneManager.LoadScene("PlanetSaturn");
                        break;
                    case "Uranus":
                        SceneManager.LoadScene("PlanetUranus");
                        break;
                    case "Neptune":
                        SceneManager.LoadScene("PlanetNeptune");
                        break;
                    default:
                    break;
                }
            }
        }
    }
}
