using UnityEngine;
using System.Collections;

public class ReadyCount : MonoBehaviour {

	UILabel m_labelCount;

	// Use this for initialization
	void Start () {
		m_labelCount = GetComponent<UILabel> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onReady3()
	{
		m_labelCount.text = "3";
	}

	void onReady2()
	{
		m_labelCount.text = "2";
	}

	void onReady1()
	{
		m_labelCount.text = "1";
	}

	void onGo()
	{
		m_labelCount.text = "GO";
		GameManager.Instance.setBoostCheckStart ();
	}

	void onHide()
	{
		m_labelCount.enabled = false;
	}
}
