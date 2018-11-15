using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectParameters))]
public class ObjectParametersInspector : Editor {

	SerializedProperty objectName, blunt, breakable, destructible, pickUp, electronic, isElectric, isFire, isWater, activationType, material,
						holdPositionOffset, holdRotationOffset, node;

	private void OnEnable()
	{
		objectName = serializedObject.FindProperty("objectName");
		blunt = serializedObject.FindProperty("blunt");
		breakable = serializedObject.FindProperty("breakable");
		destructible = serializedObject.FindProperty("destructible");
		pickUp = serializedObject.FindProperty("pickUp");
		electronic = serializedObject.FindProperty("electronic");
		isElectric = serializedObject.FindProperty("isElectric");
		isFire = serializedObject.FindProperty("isFire");
		isWater = serializedObject.FindProperty("isWater");
		activationType = serializedObject.FindProperty("activationType");
		material = serializedObject.FindProperty("material");
		holdPositionOffset = serializedObject.FindProperty("holdPositionOffset");
		holdRotationOffset = serializedObject.FindProperty("holdRotationOffset");
		node = serializedObject.FindProperty("node");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(objectName);
		EditorGUILayout.PropertyField(blunt);
		breakable.boolValue = EditorGUILayout.Toggle(breakable.displayName, breakable.boolValue);

		EditorGUI.indentLevel = 1;
		if (breakable.boolValue) EditorGUILayout.PropertyField(destructible);
		EditorGUI.indentLevel = 0;

		EditorGUILayout.PropertyField(pickUp);
		EditorGUILayout.PropertyField(electronic);
		EditorGUILayout.PropertyField(isElectric);
		EditorGUILayout.PropertyField(isFire);
		EditorGUILayout.PropertyField(isWater);
		EditorGUILayout.PropertyField(activationType);
		EditorGUILayout.PropertyField(material);
		EditorGUILayout.PropertyField(holdPositionOffset);
		EditorGUILayout.PropertyField(holdRotationOffset);
		EditorGUILayout.PropertyField(node);

		serializedObject.ApplyModifiedProperties();
	}

}
