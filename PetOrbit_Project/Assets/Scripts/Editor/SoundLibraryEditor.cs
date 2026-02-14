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
        VisualElement root = new VisualElement();

        // Get the list of SoundLists from the SoundLibrary
        SerializedProperty listsProperty = serializedObject.FindProperty("SoundLists");

        PropertyField listsField = new PropertyField(listsProperty, "Sound Lists");
        root.Add(listsField);

        // Container for nested content
        VisualElement nestedContainer = new VisualElement();
        nestedContainer.style.marginTop = 10;
        root.Add(nestedContainer);

        // Update the view when the list changes
        root.TrackSerializedObjectValue(serializedObject, (so) => 
        {
            RenderNestedLists(nestedContainer, listsProperty);
        });

        RenderNestedLists(nestedContainer, listsProperty);

        return root;
    }

    void RenderNestedLists(VisualElement container, SerializedProperty listsProp)
    {
        container.Clear();

        for (int i = 0; i < listsProp.arraySize; i++)
        {
            SerializedProperty element = listsProp.GetArrayElementAtIndex(i);
            
            if (element.objectReferenceValue is SoundList soundList)
            {
                // Create a foldout for each sub-asset
                Foldout foldout = new Foldout { text = soundList.name };
                
                // Create a SerializedObject for the nested Scriptable Object
                SerializedObject nestedSo = new SerializedObject(soundList);
                SerializedProperty clipsProp = nestedSo.FindProperty("audioClips");

                // Bind the property field to the nested object
                PropertyField clipsField = new PropertyField(clipsProp,clipsProp.name);
                clipsField.Bind(nestedSo);
                
                foldout.Add(clipsField);
                container.Add(foldout);
        
            }
        }
    }
}