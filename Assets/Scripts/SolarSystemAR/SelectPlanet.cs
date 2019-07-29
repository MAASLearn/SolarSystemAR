using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlanet : MonoBehaviour
{
    public bool isSelected;
    public GameObject selector;
    public GameObject activate;
    UnityEngine.UI.Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<UnityEngine.UI.Toggle>();
        selector.SetActive(false);
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void ToggleValueChanged(UnityEngine.UI.Toggle change)
    {
        if (toggle.isOn)
        {
            selector.SetActive(true);
            activate.SetActive(true);
        }
        else
        {
            selector.SetActive(false);
            activate.SetActive(false);
        }
    }

}
