﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float m_fSpeed = 2.0f;
	public Transform m_targetObject;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (m_targetObject)
		{
			Vector3 point = Camera.main.WorldToViewportPoint(m_targetObject.position);
			Vector3 delta = m_targetObject.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}
