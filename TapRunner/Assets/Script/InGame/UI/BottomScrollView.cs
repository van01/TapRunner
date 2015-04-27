using UnityEngine;
using System.Collections;

public class BottomScrollView : MonoBehaviour {

	public GameObject []m_listScrollView;	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void toggleShowHideView (int index)
	{
		for (int i=0; i<m_listScrollView.Length; i++)
		{
			if (i == index && m_listScrollView [i].transform.localScale.x == 0.0f)
			{
				m_listScrollView [i].transform.localScale = Vector3.one;
			}
			else
			{
				m_listScrollView [i].transform.localScale = Vector3.zero;
			}
		}
	}

	public void showView1()
	{
		toggleShowHideView (0);
	}

	public void showView2()
	{
		toggleShowHideView (1);
	}

	public void showView3()
	{
		toggleShowHideView (2);
	}

	public void showView4()
	{
		toggleShowHideView (3);
	}
}
