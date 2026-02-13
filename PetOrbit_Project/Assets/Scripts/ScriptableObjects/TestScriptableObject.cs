using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestScriptableObject", menuName = "Scriptable Objects/TestScriptableObject")]
public class TestScriptableObject : ScriptableObject
{
    public List<string> names;
}
