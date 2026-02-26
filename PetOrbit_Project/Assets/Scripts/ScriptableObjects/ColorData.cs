using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ColorData", menuName = "Scriptable Objects/Color")]
public class ColorData : ScriptableObject
{
    [SerializeField]private List<Color> colors = new List<Color>();

    public Color GetColor(int index)
    {
        return colors[index];
    }

    private void OnValidate()
    {
        RegisterToList(this);
    }

    private static void RegisterToList(ColorData colorList)
    {
      
        string[] guid = AssetDatabase.FindAssets("t:ColorList");

        if (guid.Length == 0)
        {
            //Debug.Log("no soundlibrary found");
            return;
        }

        string listPath = AssetDatabase.GUIDToAssetPath(guid[0]);
      
        //Debug.Log(libraryPath);

        ColorList list = AssetDatabase.LoadAssetAtPath< ColorList>(listPath);

        if (list != null)
        {
            if (!list.colorLists.Contains(colorList))
            {
                list.colorLists.Add(colorList);
                EditorUtility.SetDirty(list);
                // AssetDatabase.SaveAssets();
            
                Debug.Log($"Added {colorList.name} to {list.name}");
            }
        }
    }

}
