using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Makes stuff appear in the editor

[CustomEditor(typeof(Patrol))]


public class PatrolEditor : Editor
{
    private void OnSceneGUI()
    {
        Patrol source = (Patrol)target;
        Handles.color = Color.blue;
        Handles.DrawLine(source.origin, source.destination);
    }

}
