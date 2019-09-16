using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fade;

    // Start is called before the first frame update
    void Start()
    {
        fade.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
    }

    // Update is called once per frame
    void fadeIn()
    {
        fade.CrossFadeAlpha(1, 2, false);
    }
}