using UnityEditor;
using UnityEngine;
using System.Collections;

public class ObjectEditor : Editor {

	static int mSelected = 0;
	
	public override void OnInspectorGUI() {
		// Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
		serializedObject.Update ();
		
		var bgMake = target as BackgroundMaker;
		
		// Show the custom GUI controls.
		EditorGUILayout.LabelField("Custom Inspector for", "Background"); 
		
		string[] options = bgMake.getObjectList ();
		if (options != null) {
			int select = EditorGUILayout.Popup ("Select", mSelected, options); 
		
			if (mSelected != select) {
				mSelected = select;
				bgMake.onSelect (select);
			}
		}
		
		bgMake.m_fMinPos = EditorGUILayout.FloatField("Min pos.y:", bgMake.m_fMinPos);
		bgMake.m_fMaxPos = EditorGUILayout.FloatField("Max pos.y:", bgMake.m_fMaxPos);
		bgMake.m_fRangPosY = EditorGUILayout.FloatField("Range pos.y:", bgMake.m_fRangPosY);
		bgMake.m_fOffsetPosY = EditorGUILayout.FloatField("Offset pos.y:", bgMake.m_fOffsetPosY);
		
		if (GUILayout.Button ("reset")) {
			bgMake.Apply();
		}

		if (GUILayout.Button ("save")) {
			bgMake.save();
		}

		// Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
		
		base.OnInspectorGUI ();
		
		serializedObject.ApplyModifiedProperties ();
	}

}
