using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Notes_SO", menuName = "Scriptable Objects/Notes_SO")]
public class Notes_SO : ScriptableObject
{
    [TextArea(1,20)]
    public List<string> devNotes = new List<string>();
}
