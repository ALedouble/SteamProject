using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectParameters))]
public class ObjectParametersInspector : Editor {

	SerializedProperty blunt, breakable, destructible, pickUp, electronic, electric, activationType;

	private void OnEnable()
	{
		blunt = serializedObject.FindProperty("blunt");
		breakable = serializedObject.FindProperty("breakable");
		destructible = serializedObject.FindProperty("destructible");
		pickUp = serializedObject.FindProperty("pickUp");
		electronic = serializedObject.FindProperty("electronic");
		electric = serializedObject.FindProperty("electric");
		activationType = serializedObject.FindProperty("activationType");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(blunt);
		breakable.boolValue = EditorGUILayout.Toggle(breakable.displayName, breakable.boolValue);

		EditorGUI.indentLevel = 1;
		if (breakable.boolValue) EditorGUILayout.PropertyField(destructible);
		EditorGUI.indentLevel = 0;

		EditorGUILayout.PropertyField(pickUp);
		EditorGUILayout.PropertyField(electronic);
		EditorGUILayout.PropertyField(electric);
		EditorGUILayout.PropertyField(activationType);

		serializedObject.ApplyModifiedProperties();
	}

}
