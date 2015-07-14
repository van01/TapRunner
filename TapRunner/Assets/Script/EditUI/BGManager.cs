using UnityEngine;
using System.Collections;

public class BGManager : MonoBehaviour {

	public Transform m_grBG;
	public Transform []m_prefsBGSlow;
	public Transform []m_prefsBGGround;
	private int m_nStageIndex = 0;

	// Use this for initialization
	void Start () {

		int i = 0;
		Vector3 pos = Vector3.zero;
		for (i=0; i<10; i++) 
		{
			Transform obj = Instantiate (m_prefsBGSlow[m_nStageIndex], pos, Quaternion.identity) as Transform;
			obj.parent = m_grBG;
			pos.x += obj.GetComponent<BoxCollider2D>().size.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
