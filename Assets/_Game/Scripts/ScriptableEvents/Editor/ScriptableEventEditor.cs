using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScriptableEventBase))]
public class ScriptableEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ScriptableEventBase scriptableEvent = (ScriptableEventBase)target;

        if (GUILayout.Button( "Invoke Event" ))
        {
            scriptableEvent.Invoke();
        }
    }
}
