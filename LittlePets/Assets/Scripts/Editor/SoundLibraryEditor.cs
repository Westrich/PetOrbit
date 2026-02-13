using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Collections.Generic;
[CustomEditor(typeof(SoundLibrary))]
public class SoundLibraryEditor : Editor
{
  public VisualTreeAsset visualTree;
  public override VisualElement CreateInspectorGUI()
  {
    VisualElement root= new VisualElement();
    visualTree.CloneTree(root);
    return root;
  }
}
