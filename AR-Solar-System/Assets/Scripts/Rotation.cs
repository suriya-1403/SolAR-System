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
        //Vector3 difference = this.transform.position - target.transform.position;
        //float dist = difference.magnitude;
        //Vector3 gravityDirection = difference.normalized;
        //float gravity = 6.7f * (this.transform.localScale.x * target.transform.localScale.x * 80) / (dist * dist);
        //Vector3 gravityVector = (gravityDirection * gravity);
        ////target.transform.GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Acceleration);
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
}
