using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlanetProperties : MonoBehaviour
{
    public GameObject planetReticle;
    public UnityEngine.UI.Text planetName;
    public UnityEngine.UI.Text planetRotPeriod;
    public UnityEngine.UI.Text planetOrbPeriod;
    public UnityEngine.UI.Text planetDistance;
    public UnityEngine.UI.Text planetDiameter;

    GameObject currentPlanet;
    PlanetProperties currentPlanetProperties;

    Vector3 planetScreenPos;
    float planetScreenDistance;
    float planetScreenSize;
    Vector3 originalPlanetReticleScale;

    // Start is called before the first frame update
    void Start()
    {
        currentPlanet = GameManager.Instance.planets[GameManager.Instance.activePlanet];
        originalPlanetReticleScale = planetReticle.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        planetScreenPos = Camera.main.WorldToScreenPoint(currentPlanet.transform.position);
        planetReticle.transform.position = planetScreenPos;

        planetScreenDistance = Camera.main.transform.position.magnitude;

        if (System.Math.Abs(planetScreenDistance) > 0.01)
        {
            planetReticle.transform.localScale = originalPlanetReticleScale * 1 / planetScreenDistance;
        }
    }

    public void UpdatePlanetProperties()
    {
        currentPlanet = GameManager.Instance.planets[GameManager.Instance.activePlanet];
        currentPlanetProperties = currentPlanet.GetComponent<PlanetProperties>();
        planetName.text = currentPlanetProperties.planetName;
        planetRotPeriod.text = currentPlanetProperties.planetRotationalPeriod;
        planetOrbPeriod.text = currentPlanetProperties.planetOrbitalPeriod;
        planetDistance.text = currentPlanetProperties.planetDistance;
        planetDiameter.text = currentPlanetProperties.planetDiameter;
    }
}
