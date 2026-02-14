using UnityEngine;

[CreateAssetMenu(fileName = "Species", menuName = "Scriptable Objects/Species")]
public class Species : ScriptableObject
{
    public GameObject modelPrefab;

    public VoiceType voiceType;
}
