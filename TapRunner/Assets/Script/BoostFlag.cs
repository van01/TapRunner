using UnityEngine;
using System.Collections;

public enum BoostState
{
	NONE,
	ON,
	FAILED,
}



public class BoostFlag : MonoBehaviour {

	private BoostState			m_eState;
	private BoostState			m_eBoostState = BoostState.NONE;
	private float				m_fBoostCheck = 0.0f;
	private float 				m_fBoostEndTime = 0.5f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (GameManager.Instance.getState())
		{
		case STATE.STATE_GAME:
			if (m_eBoostState == BoostState.NONE)
			{
				m_fBoostCheck += Time.deltaTime;
				if (m_fBoostCheck > m_fBoostEndTime)
				{
					Debug.Log ("boost failed");
					m_eBoostState = BoostState.FAILED;
				}
			}
			break;
		}
	}

	public void checkBoost()
	{
		if (m_eBoostState != BoostState.NONE)
		{
			return;
		}

		switch (GameManager.Instance.getState ()) 
		{
		case STATE.STATE_READY:
			Debug.Log ("boost failed at Ready");
			m_eBoostState = BoostState.FAILED;
			break;
		case STATE.STATE_GAME:
			Debug.Log ("boost on");
			m_eBoostState = BoostState.ON;
			GameManager.Instance.setBoost();
			break;
		}
	}
}
