using UnityEngine;
using System.Collections;

public class BgScroll : MonoBehaviour {

	float m_fBgScrollSpeed = 0.9f;
	public Transform m_targetObject;

	float mStartCameraX = 0.0f;
	float mPrevCameraX = 0.0f;
	// Use this for initialization
	void Start () {
		mStartCameraX = mPrevCameraX = Camera.main.transform.position.x;
	}
	
	// Update is called once per frame
	//void Update () {
	void Update() {
		float cameraX = Camera.main.transform.position.x; 
		float offsetX = cameraX - mPrevCameraX;
		offsetX -= (offsetX * 0.1f);

		foreach (Transform t in transform) {
			if (t != null && t.gameObject != null)
			{
				Vector3 pos = t.transform.position;
				pos.x += offsetX;
				t.transform.position = pos;
			}
		}

		mPrevCameraX = cameraX;
	}

	public void move(float deltaX)
	{
		/*
		foreach (Transform t in transform) {
			if (t != null && t.gameObject != null)
			{
				Vector3 pos = t.transform.position;
				
				pos.x += deltaX * m_fBgScrollSpeed;
				
				t.transform.position = pos;
			}
		}
		*/
	}
}
