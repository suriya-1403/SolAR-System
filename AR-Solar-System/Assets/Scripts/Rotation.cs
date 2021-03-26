using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}
    public Transform target;
    public int speed;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
}
