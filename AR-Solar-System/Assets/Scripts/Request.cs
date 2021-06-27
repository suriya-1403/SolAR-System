using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Request : MonoBehaviour
{
    InputField OutputArea;
    // Start is called before the first frame update
    void Start()
    {
        OutputArea = GameObject.Find("OutputBox").GetComponent<InputField>();
        OutputArea.lineType = InputField.LineType.MultiLineNewline;
        GameObject.Find("LoadButton").GetComponent<Button>().onClick.AddListener(GetData);
        //StartCoroutine(GetRequest("http://localhost:5000/"));
    }
    void GetData() => StartCoroutine(GetRequest());

    IEnumerator GetRequest()
    {
        //OutputArea.text.horizontalOverflow = HorizontalWrapMode.Overflow;
        OutputArea.text = "Loading...";
        string uri = "http://localhost:5000/";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                Debug.Log("Error on Network: "+webRequest.error);
            }
            else
            {
                OutputArea.text = webRequest.downloadHandler.text;
            }
        }
    }
}
