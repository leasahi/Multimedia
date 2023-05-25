using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="Sunset Preset", menuName ="Scriptables/Sunset Preset", order =1)]
public class SunsetPreset : ScriptableObject
{
    public Gradient Ambient;
    public Gradient Directional;
    public Gradient Fog;

  
}
