using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetToggleTextures : MonoBehaviour
{

    public Texture texture1;
    public Texture texture2;
    public Sprite sprite1;
    public Sprite sprite2;

    private void OnEnable()
    {
        GameManager.Instance.texture1 = texture1;
        GameManager.Instance.texture2 = texture2;
        GameManager.Instance.sprite1 = sprite1;
        GameManager.Instance.sprite2 = sprite2;
    }

	private void OnDisable()
	{
		GameManager.Instance.texture1 = null;
		GameManager.Instance.texture2 = null;
		GameManager.Instance.sprite1 = null;
		GameManager.Instance.sprite2 = null;
	}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
