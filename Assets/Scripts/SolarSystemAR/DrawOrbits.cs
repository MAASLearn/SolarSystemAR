using UnityEngine;
using System.Collections;

public class DrawOrbits : MonoBehaviour
{
    public int lineSegments;
    public Color lineColor;
    public float lineWidth;
    LineRenderer line;

    void Start ()
    {
        foreach (Planet planet in GetComponentsInChildren<Planet>())
        {
            line = planet.GetComponent<LineRenderer>();
            line.material.color = lineColor;
            line.widthMultiplier = lineWidth;
            line.SetVertexCount(lineSegments + 1);
            line.useWorldSpace = true;
            DrawOrbitPoints(planet.orbitalDistance * GameManager.Instance.distanceMultiplier + GameManager.Instance.distanceOffset, planet.orbitalPlaneAngle);
        }
    }


    void DrawOrbitPoints (float radius, float tilt)
    {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < (lineSegments + 1); i++)
        {
            x = Mathf.Sin (Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Tan(Mathf.Deg2Rad * tilt) * x;
            z = Mathf.Cos (Mathf.Deg2Rad * angle) * radius;

            line.SetPosition (i,new Vector3(x,y,z) );

            angle += (360f / lineSegments);
        }
    }
}