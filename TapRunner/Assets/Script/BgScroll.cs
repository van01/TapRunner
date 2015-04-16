using UnityEngine;
using System.Collections;

public class BgScroll : MonoBehaviour {

	float m_fBgScrollSpeed = 0.9f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void move(float deltaX)
	{
		foreach (Transform t in transform) {
			if (t != null && t.gameObject != null)
			{
				Vector3 pos = t.transform.position;
				
				pos.x += deltaX * m_fBgScrollSpeed;
				
				t.transform.position = pos;
			}
		}	
	}
}
