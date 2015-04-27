using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float m_fSpeed = 2.0f;
	public Transform m_targetObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = m_targetObject.position;
		pos.y += 1.068f;
		pos.z = transform.position.z;
		gameObject.transform.position = pos;
	}
}
