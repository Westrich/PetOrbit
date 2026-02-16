using UnityEngine;

[CreateAssetMenu(fileName = "Species", menuName = "Scriptable Objects/Species")]
public class Species_SO : ScriptableObject
{
    public GameObject modelPrefab;

    public VoiceType voiceType;
}
