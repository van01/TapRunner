
using UnityEditor;
using UnityEngine;
using System.Collections;


// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and prefab overrides.
[CustomEditor(typeof(NormalBGMaker))]
[CanEditMultipleObjects]
public class NormalBGEditor : ObjectEditor {

	public override void OnInspectorGUI() {
		// Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
		serializedObject.Update ();
		// Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.

		base.OnInspectorGUI ();

		serializedObject.ApplyModifiedProperties ();
	}
}