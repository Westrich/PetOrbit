using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "Scriptable Objects/SoundLibrary")]
[System.Serializable]
public class SoundLibrary : ScriptableObject
{
    public List<ScriptableObject> Soundlists =new List<ScriptableObject>() ;
}
