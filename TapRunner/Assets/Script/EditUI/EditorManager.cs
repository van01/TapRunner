using UnityEngine;
using System.Collections;

public class EditorManager : MonoBehaviour {

	public GameObject mMainUI;
	public GroundMaker mGroundMaker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onNewStage()
	{
		GameObject obj = Resources.Load("Prefabs/Editor/Popup_New_Stage") as GameObject;	
		GameObject Popup = NGUITools.AddChild(mMainUI, obj);
		Popup.transform.parent = mMainUI.transform;
		//mNewStagePopup;
	}

	public void onReset() {
		mGroundMaker.onTest ();
	}
}
