using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorLibrary", menuName = "Scriptable Objects/ColorLibrary")]
public class ColorList : ScriptableObject
{
    public List<ColorData> colorLists = new List<ColorData>();

    public List<ColorData> GetList()
    {
        return colorLists;
    }

    public void SetList(List<ColorData> list)
    {
        
    }

}
