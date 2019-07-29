using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public float radius;
    public float axialTilt;
    public float rotationalPeriod;
    public float orbitalDistance;
    public float orbitalPeriod;
    public float orbitalPlaneAngle;
    Vector3 orbitalPlane;
    float defaultRadius;

	// Use this for initialization
	void Awake () {
        //transform.localScale *= radius * GameManager.Instance.raduisMultiplier;
        defaultRadius = radius;
        transform.localScale = Vector3.one * radius * GameManager.Instance.raduisMultiplier;
        transform.position = new Vector3(0f, 0f, orbitalDistance * GameManager.Instance.distanceMultiplier + GameManager.Instance.distanceOffset);
        transform.up = Quaternion.Euler(new Vector3(0f, 0f, axialTilt)) * Vector3.up;
        orbitalPlane = Quaternion.Euler(new Vector3(0f, 0f, orbitalPlaneAngle)) * Vector3.up;
        rotationalPeriod *= orbitalPeriod / (GameManager.Instance.orbitalPeriodMultiplier * 365);

        // Randomise initial orbital position
        transform.RotateAround(Vector3.zero, orbitalPlane, Random.Range(0,360));
	}

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            transform.RotateAround(transform.position, transform.up, -360 * Time.deltaTime * GameManager.Instance.rotationalPeriodMultiplier / rotationalPeriod);
            transform.RotateAround(Vector3.zero, orbitalPlane, -360 * Time.deltaTime * GameManager.Instance.orbitalPeriodMultiplier / orbitalPeriod);
        }
    }

    public void ScaleRadius(int multiplier)
    {
        Debug.Log(multiplier);
        radius = defaultRadius * multiplier;
        transform.localScale = Vector3.one * radius * GameManager.Instance.raduisMultiplier;
    }
        
}
