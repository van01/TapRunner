using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float m_fOneStamina = 1.0f;
	public float m_fMaxStamina = 5.0f;
	private float m_fStamina = 0.0f;
	private float m_fBoostStamina = 10.0f;
	public Animator m_animator;

	private bool m_isGrounded = true;
	public Transform m_groundCheck;
	private float m_fGroundRadius = 0.2f;
	public LayerMask m_whatIsGround;



	void Start () {
	}

	// Update is called once per frame
	void Update () 
	{
	}

	void FixedUpdate () {
		m_isGrounded = Physics2D.OverlapCircle (m_groundCheck.position, m_fGroundRadius, m_whatIsGround);
		m_animator.SetBool ("isJump", !m_isGrounded);
		move ();
	}

	private void move()
	{
		//m_fTime -= (Time.deltaTime * 2);
		m_fStamina -= (Time.deltaTime);

		if (m_fStamina > 0.0f)
		{
			Vector3 pos = transform.position;
			float fDeltaTime = m_fStamina * Time.deltaTime;
			pos.x += fDeltaTime;
			transform.position = pos;

			GameManager.Instance.onPlayerMove (fDeltaTime);
		}
		else
		{
			m_fStamina = 0.0f;
		}

		processAnimation ();
	}

	public void onWalking ()
	{
		if (m_fStamina < m_fMaxStamina)
		{
			m_fStamina += m_fOneStamina;
		}
	}

	private void processAnimation ()
	{
		int nPlayerState = 0;
		if (m_fStamina < (m_fMaxStamina * 0.5f))
		{
			//level 1
			nPlayerState = 0;
		}
		else if (m_fStamina < (m_fMaxStamina * 0.9f))
		{
			//leve 2
			nPlayerState = 1;
		}
		else if (m_fStamina < (m_fMaxStamina * 1.2f))
		{
			//level3
			nPlayerState = 2;
		}
		else
		{
			//boost
			nPlayerState = 3;
		}

		m_animator.SetInteger ("PlayerState", nPlayerState);
	}


	public float getStamina()
	{
		return m_fStamina/m_fMaxStamina;
	}

	public void setBoost()
	{
		m_fStamina = m_fBoostStamina;
	}

	public float getSpeed()
	{
		return m_fStamina;
	}
}
