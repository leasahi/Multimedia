using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SunsetManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private SunsetPreset Preset;

    [SerializeField, Range (0,20)] private float TimeOfDay;

    private void Update()
    {
        if(Preset == null)
        {
            return;
        }
        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime*0.10f;
            TimeOfDay %= 20;
            UpdateLighting(TimeOfDay / 20f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 20f);
        }
    }

    private void UpdateLighting(float time)
    {
        RenderSettings.ambientLight = Preset.Ambient.Evaluate(time);
        RenderSettings.fogColor = Preset.Fog.Evaluate(time);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.Directional.Evaluate(time);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f) - 90f, -170, 0));

        }
    }

    private void OnValidate()
    {
        if(DirectionalLight != null)
        {
            return;
        }
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
