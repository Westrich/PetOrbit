using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color_SO", menuName = "Scriptable Objects/Color")]
public class Color_SO : ScriptableObject
{
    [SerializeField]private List<Color> colors = new List<Color>();

    public Color GetColor(int index)
    {
        return colors[index];
    }
}
