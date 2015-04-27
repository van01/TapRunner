using UnityEngine;
using System.Collections;

public class VScrollViewBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hide () {
		Debug.Log ("hide");
		gameObject.transform.localScale = Vector3.zero;
	}

	public void show () {
		Debug.Log ("show");
		gameObject.transform.localScale = Vector3.one;
	}
}
