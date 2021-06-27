using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class rings : MonoBehaviour
{

    public int vertexCount = 40;
    public float linewidth = 0.2f;
    public float radius;
    public bool circleFillScreen;

    private LineRenderer Lr;

    void Awake()
    {
        Lr = GetComponent<LineRenderer>();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos(){
        float deltaTheta = ( 2f * Mathf.PI)/40f;
        float theta = 0f;
        Vector3 oldPos = Vector3.zero;
        for (int i =0;i<vertexCount +1 ;i++){
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius*Mathf.Sin(theta),0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;

            theta += deltaTheta;
        }
             
    }
#endif
}
