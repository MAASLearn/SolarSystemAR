using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GameManager : MonoBehaviour
{

    #region SINGLETON PATTERN
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    _instance = container.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }
    #endregion

    public DefaultTrackableEventHandler target;
    public bool noMenu;
    public Canvas selectionCanvas;
    public Canvas gameCanvas;
    public Canvas propertiesCanvas;
    public ToggleGroup planetToggleGroup;
    public GameObject[] planets;
    public int activePlanet;
    public float distanceOffset;
    public float raduisMultiplier;
    public float distanceMultiplier;
    public float rotationalPeriodMultiplier;
    public float orbitalPeriodMultiplier;
    public Button propertiesButton;
    public Rotate propertiesReticle;
    public UnityEngine.UI.Image pauseButton;
    public Sprite pauseSprite;
    public int[] scaleMultipliers;
    public Button[] scaleButtons;

    float tmpRotationalPeriodMultiplier;
    float tmpOrbitalPeriodMultiplier;

    public bool isPaused;
    float pauseFlashTime = 1.0f;
    float pauseFlashTimer;
    bool showingProperties;

    [HideInInspector]
    public Texture texture1;
    [HideInInspector]
    public Texture texture2;
    [HideInInspector]
    public Sprite sprite1;
    [HideInInspector]
    public Sprite sprite2;

    public UnityEngine.UI.Image textureButtonImage;
    Renderer r;

    void Start()
    {
        if (noMenu)
        {
            if (gameCanvas)
            {
                gameCanvas.enabled = false;
            }
            if (selectionCanvas)
            {
                selectionCanvas.enabled = false;
            }
            if (propertiesCanvas)
            {
                propertiesCanvas.enabled = false;
            }
            VuforiaBehaviour.Instance.enabled = true;
            if (scaleButtons.Length > 0)
            {
                ScalePlanet(1);
            }
            EnablePlanet();
        }
        else
        {
            if (gameCanvas)
            {
                gameCanvas.enabled = false;
            }
            if (selectionCanvas)
            {
                selectionCanvas.enabled = true;
            }
            if (propertiesCanvas)
            {
                propertiesCanvas.enabled = false;
            }
            VuforiaBehaviour.Instance.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (propertiesCanvas)
        {
            if (!target.tracking)
            {
                propertiesCanvas.enabled = false;
            }
            else
            {
                propertiesCanvas.enabled |= showingProperties;
            }
        }
    }

    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseButton.GetComponent<Blink>().isBlinking = false;
        }
        else
        {
            isPaused = true;
            pauseButton.GetComponent<Blink>().isBlinking = true;
        }
    }

    public void EnablePlanet()
    {
        if (activePlanet > -1 && activePlanet < planets.Length)
        {
            foreach (GameObject planet in planets)
            {
                planet.SetActive(false);
            }
            showingProperties = false;
            VuforiaBehaviour.Instance.enabled = true;
            planets[activePlanet].SetActive(true);
            if (planets[activePlanet].GetComponent<PlanetProperties>() != null)
            {
                propertiesCanvas.GetComponent<DisplayPlanetProperties>().UpdatePlanetProperties();
                propertiesButton.gameObject.SetActive(true);
            }
            else
            {
                if (propertiesButton)
                {
                    propertiesButton.gameObject.SetActive(false);
                }
            }
            r = planets[activePlanet].GetComponent<Renderer>();
            if (sprite2 != null)
            {
                textureButtonImage.sprite = sprite2;
                textureButtonImage.gameObject.SetActive(true);
            }
            else
            {
                if (textureButtonImage)
                {
                    textureButtonImage.gameObject.SetActive(false);
                }
            }
            if (selectionCanvas)
            {
                selectionCanvas.enabled = false;
            }
            gameCanvas.enabled = true;
        }
    }

    public void BeginObjectSelection()
    {
        isPaused = false;
        pauseButton.GetComponent<Blink>().isBlinking = false;
        VuforiaBehaviour.Instance.enabled = false;
        selectionCanvas.enabled = true;
        gameCanvas.enabled = false;
        propertiesCanvas.enabled = false;
        propertiesReticle.revs = 0f;
        planetToggleGroup.SetAllTogglesOff();
    }


    public void ToggleProperties()
    {
        if (showingProperties)
        {
            propertiesReticle.revs = 0f;
            propertiesCanvas.enabled = false;
        }
        else
        {
            propertiesReticle.revs = -0.5f;
            propertiesCanvas.enabled = true; 
        }
        showingProperties = !showingProperties;
    }

    public void SwitchTexture()
    {
        if (r.material.mainTexture == texture1)
        {
            r.material.mainTexture = texture2;
            textureButtonImage.sprite = sprite1;
        }
        else
        {
            r.material.mainTexture = texture1;
            textureButtonImage.sprite = sprite2;
        }
    }

    public void SetActivePlanet(int planet)
    {
        activePlanet = planet;
    }

    public void ScalePlanet(int scaleIdx)
    {
        foreach (Button button in scaleButtons)
        {
            button.GetComponent<Blink>().isBlinking = false;
        }
        if (planets[activePlanet].transform.childCount > 0)
        {
            scaleButtons[scaleIdx].GetComponent<Blink>().isBlinking = true;
            foreach (Transform childPlanet in planets[activePlanet].GetComponentInChildren<Transform>())
            {
                childPlanet.gameObject.GetComponent<Planet>().ScaleRadius(scaleMultipliers[scaleIdx]);
            }
        }
        else
        {
            planets[activePlanet].GetComponent<Planet>().ScaleRadius(scaleMultipliers[scaleIdx]);
        }
    }
}