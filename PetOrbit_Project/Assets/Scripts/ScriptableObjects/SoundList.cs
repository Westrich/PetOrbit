using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundList", menuName = "Scriptable Objects/SoundList")]
[System.Serializable]
public class SoundList : ScriptableObject
{
    public List<AudioClip> audioClips=new List<AudioClip>();
}
