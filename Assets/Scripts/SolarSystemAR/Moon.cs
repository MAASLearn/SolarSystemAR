using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

    public float radius;
    public float axialTilt;
    public float rotationalPeriod;
    public float orbitalDistance;
    public float orbitalPeriod;
    public float orbitalPlaneAngle;
    Vector3 orbitalPlane;

	// Use this for initialization
	void Start () {
        transform.localScale *= radius;
        transform.localPosition = new Vector3(0f, 0f, orbitalDistance * GameManager.Instance.distanceMultiplier + GameManager.Instance.distanceOffset);
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
            transform.RotateAround(Vector3.zero, orbitalPlane, -360 * Time.deltaTime / orbitalPeriod);
        }
    }
        
}
