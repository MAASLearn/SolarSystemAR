using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    Image image;
    float blinkTimer;
    Color green;
    Color invisible;

    public float blinkTime;
    public bool isBlinking;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        green = image.color;
        invisible = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlinking)
        {
            if (blinkTimer < blinkTime)
            {
                blinkTimer += Time.deltaTime;
            }
            else
            {
                if (System.Math.Abs(image.color.a - 1) < 0.1f)
                {
                    image.color = invisible;
                }
                else
                {
                    image.color = green;
                }
                blinkTimer = 0f;
            }
        }
        else
        {
            image.color = green;
        }
    }
}
