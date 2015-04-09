using UnityEngine;
using System.Collections;

public class LobbyScrollView : MonoBehaviour {

	public TweenScrollBarValue m_tweenScrollBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveNext ()
	{
		m_tweenScrollBar.ResetToBeginning ();
		m_tweenScrollBar.enabled = true;
	}
}
