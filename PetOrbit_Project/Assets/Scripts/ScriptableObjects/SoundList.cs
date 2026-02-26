using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "SoundList", menuName = "Scriptable Objects/SoundList")]
[System.Serializable]
public class SoundList : ScriptableObject
{
    public List<AudioClip> audioClips=new List<AudioClip>();

    private void OnValidate()
    {
        RegisterToLibrary(this);
        
    }

    private static void RegisterToLibrary(SoundList soundList)
    {
      
        string[] guid = AssetDatabase.FindAssets("t:SoundLibrary");

        if (guid.Length == 0)
        {
            //Debug.Log("no soundlibrary found");
            return;
        }

        string libraryPath = AssetDatabase.GUIDToAssetPath(guid[0]);
      
        //Debug.Log(libraryPath);

        SoundLibrary library = AssetDatabase.LoadAssetAtPath<SoundLibrary>(libraryPath);

        if (library != null)
        {
            if (!library.SoundLists.Contains(soundList))
            {
                library.SoundLists.Add(soundList);
                EditorUtility.SetDirty(library);
               // AssetDatabase.SaveAssets();
            
                Debug.Log($"Added {soundList.name} to {library.name}");
            }
        }
    }
    
}
