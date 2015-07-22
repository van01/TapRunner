using UnityEditor;
using UnityEngine;
using System.Collections;

public class ObjectEditor : Editor {

	static int mSelected = 0;
	static bool mIsShowBaseInspectorGUI = false;
	
	public override void OnInspectorGUI() {
		// Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
		serializedObject.Update ();
		
		var bgMake = target as ObjectMaker;
		
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
		bgMake.m_fMinScale = EditorGUILayout.FloatField("Min Scale:", bgMake.m_fMinScale);
		bgMake.m_fMaxScale = EditorGUILayout.FloatField("Max Scale:", bgMake.m_fMaxScale);
		bgMake.m_fRangPosY = EditorGUILayout.FloatField("Range pos.y:", bgMake.m_fRangPosY);
		bgMake.m_fOffsetPosY = EditorGUILayout.FloatField("Offset pos.y:", bgMake.m_fOffsetPosY);
		
		if (GUILayout.Button ("Apply")) {
			bgMake.Apply();
		}

		if (GUILayout.Button ("save")) {
			bgMake.save();
		}

		mIsShowBaseInspectorGUI = EditorGUILayout.Toggle("Show base inspector", mIsShowBaseInspectorGUI);
		if (mIsShowBaseInspectorGUI) {
			base.OnInspectorGUI ();
		}

		// Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
		
		
		serializedObject.ApplyModifiedProperties ();
	}
}
