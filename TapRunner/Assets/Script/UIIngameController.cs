using UnityEngine;
using System.Collections;

public class UIIngameController : MonoBehaviour {

	public PlayerControl m_playerControl;
	public UISlider	m_SliderStamina;

	public float m_fRepeatTime = 0.5f;
	public float m_fCheckTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		m_SliderStamina.value = m_playerControl.getStamina ();

		///test
		m_fCheckTime += Time.deltaTime;
		if (m_fRepeatTime < m_fCheckTime)
		{
			onTouchClick();
			m_fCheckTime = 0;
		}
	}

	void onTouchClick()
	{
		switch (GameManager.Instance.getState ())
		{
		case STATE.STATE_READY:

			break;
		case STATE.STATE_GAME:
			m_playerControl.onWalking ();
			break;
		}
	}

	public void onAutoClickUp()
	{
		m_fRepeatTime -= 0.1f;
	}

	public void onAutoClickDown()
	{
		m_fRepeatTime += 0.1f;
	}
}
