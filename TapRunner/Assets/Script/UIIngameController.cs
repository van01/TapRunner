using UnityEngine;
using System.Collections;

public class UIIngameController : MonoBehaviour {

	public PlayerControl m_playerControl;
	public UISlider	m_SliderStamina;
	public UILabel	m_lblSpeed;

	public float m_fRepeatTime = 0.5f;
	public float m_fCheckTime = 0.0f;

	// Use this for initialization
	void Start () {
		m_fRepeatTime = 1110.5f;
	}
	
	// Update is called once per frame
	void Update () {

		m_SliderStamina.value = m_playerControl.getStamina ();


		m_lblSpeed.text = ""+m_playerControl.getSpeed();

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
		GameManager.Instance.onTouch();

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

	public void onAcceleration()
	{
		Debug.Log ("Acceleration");
		m_playerControl.setBoost ();
	}
}
