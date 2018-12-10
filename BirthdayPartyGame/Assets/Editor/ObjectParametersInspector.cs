using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectParameters))]
public class ObjectParametersInspector : Editor {

	ObjectParameters script;
	Interactable interactable;
	bool initialized;
	SerializedProperty objectName, blunt, breakable, destructible, pickUp, electronic, isElectric, isFire, isWater, activationType, material,
						holdPositionOffset, holdRotationOffset, nodes;

	private void OnEnable()
	{
		script = (ObjectParameters)target;
		interactable = script.GetComponent<Interactable>();

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
		nodes = serializedObject.FindProperty("nodes");
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
		EditorGUILayout.PropertyField(nodes);


		if (interactable.fireParticleSystem == null ||
			interactable.waterParticleSystem == null ||
			interactable.electricityParticleSystem == null ||
			interactable.body == null ||
			interactable.self == null ||
			interactable.colliders == null ||
			interactable.renderers == null)
		{
			initialized = false;
		}
		if (GUILayout.Button("Initialize Object"))
		{
			interactable.fireParticleSystem = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Entities/P_Fire.prefab", typeof(GameObject));
			interactable.waterParticleSystem = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Entities/P_Water.prefab", typeof(GameObject));
			interactable.electricityParticleSystem = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Entities/P_Electricity.prefab", typeof(GameObject));
			interactable.body = interactable.GetComponent<Rigidbody>();
			interactable.self = interactable.transform;
			interactable.colliders = interactable.GetComponents<Collider>();
			interactable.renderers = interactable.GetComponents<Renderer>();
			Undo.RecordObject(target, "Initialized object");
			Undo.RecordObject(interactable, "Changed Area Of Effect");

			initialized = true;
		}
		if (!initialized)
		{
			EditorGUILayout.HelpBox("Error: Object not yet initialized!", MessageType.Error);
		}

		serializedObject.ApplyModifiedProperties();
		EditorUtility.SetDirty(interactable);
	}

}
