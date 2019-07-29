using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlanet : MonoBehaviour {

	public float axialTilt;

	// Use this for initialization
	void Start()
	{
		transform.up = Quaternion.Euler(new Vector3(0f, 0f, axialTilt)) * Vector3.up;
	}

	// Update is called once per frame
	void Update()
	{
        if (!GameManager.Instance.isPaused)
        {
            transform.RotateAround(transform.position, transform.up, -360 * Time.deltaTime / 5.0f);
        }
	}
}
