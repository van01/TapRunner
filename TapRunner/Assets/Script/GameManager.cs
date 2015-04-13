using UnityEngine;
using System.Collections;

public enum STATE
{
	STATE_NONE,
	STATE_READY,
	STATE_GAME,
	STATE_GAMEOVER,
}


public class GameManager : MonoBehaviour {

	static private string 		HIGHSCORE = "HIGHSCORE";
	static private GameManager			m_instance = null;

	private float 				m_fReadyCount = 0.0f;
	private float 				m_fGameSpeed 	= 1.0f;
	private float 				m_fHighScore = 0.0f;
	private float				m_fScore = 0.0f;
	private STATE				m_eState = STATE.STATE_NONE;

	private bool				m_isBoost = false;
	private float				m_fBoostCheck = 0.0f;
	private float 				m_fBoostEndTime = 0.5f;

	public BgScroll			m_BgScroll;
	public PlayerControl	m_playerControl;

	public static GameManager Instance 
	{
		get 
		{
			if (m_instance == null)
			{
//			 	container = new GameObject();  
//				container.name = "GameManager";  
//				m_instance = container.AddComponent(typeof(GameManager)) as GameManager;  
				m_instance = GameObject.FindObjectOfType (typeof(GameManager)) as GameManager;
			}

			return m_instance;
		}
	}

	//-------------------------------------------------------------------------------------

	public void changeState (STATE eState )
	{
		switch (eState)
		{
		case STATE.STATE_NONE:
			break;
		case STATE.STATE_READY:
			onReady();
			break;
		case STATE.STATE_GAME:
			onGameStart();
			break;
		case STATE.STATE_GAMEOVER:
			onGameOver();
			break;
		}
		m_eState = eState;
	}

	//-------------------------------------------------------------------------------------

	public STATE getState()
	{
		return m_eState;
	}

	//-------------------------------------------------------------------------------------

	public float fGameSpeed
	{
		get
		{
			return m_fGameSpeed;;
		}

		set
		{
			m_fGameSpeed = value;
		}
	}

	//-------------------------------------------------------------------------------------

	public void addScore (float fAddScore)
	{
		m_fScore += (fAddScore/2);
	}

	//-------------------------------------------------------------------------------------

	public float getScore()
	{
		return m_fScore;
	}

	//-------------------------------------------------------------------------------------

	public float getHighScore()
	{
		return m_fHighScore;
	}

	//-------------------------------------------------------------------------------------

	// Use this for initialization
	void Start () {

		Screen.orientation = ScreenOrientation.Landscape;
		m_fHighScore = PlayerPrefs.GetFloat (HIGHSCORE, 0);


		changeState (STATE.STATE_READY);
	}

	//-------------------------------------------------------------------------------------

	// Update is called once per frame
	void Update () {
		if ( m_eState == STATE.STATE_READY)
		{
			if (m_isBoost)
			{
				m_fBoostCheck += Time.deltaTime;
				if (m_fBoostCheck > m_fBoostEndTime)
				{
					m_isBoost = false;
				}
			}
		}
	}

	//-------------------------------------------------------------------------------------

	void onReady() {
		m_fGameSpeed = 0.0f;
		m_fReadyCount = 0.0f;
	}

	//-------------------------------------------------------------------------------------

	void onGameStart()
	{
		m_fGameSpeed = 1.0f;
	}

	//-------------------------------------------------------------------------------------

	void onGameOver()
	{
		m_fGameSpeed = 0.0f;

	}

	public void onPlayerMove (float deltaMoveX)
	{
		m_BgScroll.move (deltaMoveX);

		Vector3  pos = Camera.main.transform.position;
		pos.x += deltaMoveX;
		Camera.main.transform.position = pos;
	}

	public void setBoostCheckStart ()
	{
		changeState (STATE.STATE_GAME);
		m_isBoost = true;
		m_fBoostCheck = 0.0f;
	}

	public void onBoost()
	{
		if (m_isBoost) 
		{
			m_isBoost = false;
			m_playerControl.onBoost();
		}
	}
}
