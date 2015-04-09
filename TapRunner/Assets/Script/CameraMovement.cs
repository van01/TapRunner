using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float m_fSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float fGameSpeed = GameManager.Instance.fGameSpeed;
		
		Vector3 pos = transform.position;
		
		pos.x += m_fSpeed * Time.deltaTime * fGameSpeed;
		
		transform.position = pos;

	}
}
