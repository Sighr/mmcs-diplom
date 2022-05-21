using UnityEditor;
using UnityEngine;
using Event = EventSystem.Event;

[CustomEditor(typeof(Event))]
public class EventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Event script = (Event) target;
        if (GUILayout.Button("Raise"))
        {
            script.RaiseEvent();
        }
    }
}