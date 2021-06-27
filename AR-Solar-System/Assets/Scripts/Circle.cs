using System;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class Circle : MonoBehaviour
{
    public int vertexCount = 40;
    public float linewidth = 0.2f;
    public float radius;
    public bool circleFillScreen;

    private LineRenderer Lr;

    void Awake()
    {
        Lr = GetComponent<LineRenderer>();
        SetupCircle();
    }

    private void SetupCircle()
    {
        Lr.widthMultiplier = linewidth;

        if (circleFillScreen)
        {
            radius = Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMax,0f)), Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMin, 0f))) *0.5f - linewidth;
        }
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta =0f;
        Lr.positionCount = vertexCount;
        for (int i=0;i< Lr.positionCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            Lr.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos(){
        float deltaTheta = ( 2f * Mathf.PI)/vertexCount;
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
