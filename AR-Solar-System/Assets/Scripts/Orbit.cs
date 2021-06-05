using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Orbit : MonoBehaviour
{
    public GameObject Planet;
    public GameObject player;
    public float gravity;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 v = (Vector3)Planet.transform.position - (Vector3)player.transform.position;
        float distance = v.magnitude;
        Vector3 direction = v.normalized;

        //float G = gravity * Planet.transform.GetComponent<Rigidbody>().mass * player.transform.GetComponent<Rigidbody>().mass / (distance * distance);
        float G = gravity * Planet.transform.localScale.x * player.transform.localScale.x / (distance * distance);
        Vector2 gvector = (direction * G);
        player.transform.GetComponent<Rigidbody>().AddForce(gvector, ForceMode.Acceleration);

    }
    
}
