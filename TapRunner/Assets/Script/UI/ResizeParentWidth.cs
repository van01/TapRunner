using UnityEngine;
using System.Collections;

public class ResizeParentWidth : MonoBehaviour {

	public int offsetWidth = 4;

	// Use this for initialization
	void Start () {
		float fWidth = GetComponentInParent<UIPanel> ().width;
		GetComponent<UISprite> ().width = (int)fWidth - offsetWidth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
