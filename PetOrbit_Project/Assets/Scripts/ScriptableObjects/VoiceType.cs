using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VoiceType", menuName = "Scriptable Objects/VoiceType")]
public class VoiceType : ScriptableObject
{
    public List<AudioClip> voiceSounds;
}
