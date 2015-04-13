using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float m_fOneStamina = 1.0f;
	public float m_fMaxStamina = 5.0f;
	private float m_fTime = 0.0f;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		move ();
	}

	private void move()
	{
		//m_fTime -= (Time.deltaTime * 2);
		m_fTime -= (Time.deltaTime);

		if (m_fTime > 0.0f)
		{
			Vector3 pos = transform.position;
			float fDeltaTime = m_fTime * Time.deltaTime;
			pos.x += fDeltaTime;
			transform.position = pos;

			GameManager.Instance.onPlayerMove (fDeltaTime);
		}
		else
		{
			m_fTime = 0.0f;
		}
	}

	public void onWalking ()
	{
		m_fTime += m_fOneStamina;

		if (m_fTime > m_fMaxStamina)
		{
			m_fTime = m_fMaxStamina;
		}
	}

	public float getStamina()
	{
		return m_fTime/m_fMaxStamina;
	}

	public void onBoost()
	{
		m_fTime = m_fMaxStamina;
	}
}
