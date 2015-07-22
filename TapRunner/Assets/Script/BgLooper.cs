using UnityEngine;
using System.Collections;

public class BgLooper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		
		if (collider.gameObject.tag == "BG_OBJECT")
		{
			Destroy (collider.gameObject);
		}
		else
		{
			Debug.Log ("TriggerEnter2D : " + collider.name);

			Vector3 size = ((BoxCollider2D)collider).size;
			Vector3 position = collider.transform.position;
			Vector3 scale = collider.transform.localScale;
			
			position.x += size.x * scale.x * 2.0f;

			Debug.Log ( size.x + " : " + scale.x);

			collider.transform.localPosition = position;
			collider.transform.SendMessage("reset");
		}
		
	}
}
