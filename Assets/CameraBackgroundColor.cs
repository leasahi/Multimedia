using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundColor : MonoBehaviour
{
 
    
    public Gradient colorGradient;
    public Camera camera1;
    public Camera camera2;

    public float duration = 5f;

    private float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime;
        float t = Mathf.Clamp01(currentTime / duration);
        Color currentColor = colorGradient.Evaluate(t);
        camera1.backgroundColor = currentColor;
        camera2.backgroundColor = currentColor;
    }
}
