using UnityEngine;
using System.Collections;

public class BgScroll : MonoBehaviour {

	float m_fBgScrollSpeed = 0.9f;
	public Transform m_targetObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform t in transform) {
			if (t != null && t.gameObject != null)
			{
				Vector3 pos = t.transform.position;
				pos.x = m_targetObject.position.x - m_targetObject.position.x * 0.1f;
				t.transform.position = pos;

				float colliderWidth = t.GetComponent<BoxCollider2D>().size.x;
				pos.x += colliderWidth * transform.localScale.x;
			}
		}
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
