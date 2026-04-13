using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(SceneAttribute))]
public class SceneDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var scenes = EditorBuildSettings.scenes;
        List<string> sceneNames = new List<string>();

        foreach (var scene in scenes)
        {
            if (scene.enabled)
            {
                // Cleans up the path to just show the scene name
                string name = System.IO.Path.GetFileNameWithoutExtension(scene.path);
                sceneNames.Add(name);
            }
        }

        if (sceneNames.Count == 0)
        {
            EditorGUI.LabelField(position, label.text, "Add scenes to Build Settings!");
            return;
        }

        int currentIndex = Mathf.Max(0, sceneNames.IndexOf(property.stringValue));
        int newIndex = EditorGUI.Popup(position, label.text, currentIndex, sceneNames.ToArray());
        
        property.stringValue = sceneNames[newIndex];
    }
}