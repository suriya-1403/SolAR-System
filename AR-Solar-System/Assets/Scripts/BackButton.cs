using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    int sceneIndex;
    string btName;

    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(1);

        
    }
    public void Back_Button()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            //Debug.Log("Testing1.5");
            if (Physics.Raycast(ray, out hit))
            {
                btName = hit.transform.name;
                switch (btName)
                {
                    case "Canvas":
                        SceneManager.LoadScene(1);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
