using UnityEngine;
using System.Collections;

public class GroundMaker : MonoBehaviour {

	public GameObject[]		mSmallWoodList;
	public GameObject[]		mBallWoodList;
	public GameObject[]		mWoodList;
	public BoxCollider2D	mCollider;

	AutoBGDeco []mDeco = new AutoBGDeco[5];

	[Range (0, 5)]
	public float m_fMinPos = 2.25f;
	[Range (0, 10)]
	public float m_fMaxPos = 3.0f;
	public float m_fRangPosY = 0.1f;
	[Range (-5, 5)]
	public float m_fOffsetPosY = 2.1f;


	public void onTest()
	{
		Debug.Log ("Test");
		Vector2 fSacleRange	= new Vector2 (1.0f, 1.0f);
		Vector2 fPosRange	= new Vector2 (m_fMinPos, m_fMaxPos);

		mDeco [0].clear ();
		mDeco [0] = gameObject.AddComponent<AutoBGDeco>();
		mDeco [0].init (mWoodList, mCollider, fSacleRange, fPosRange, m_fRangPosY,m_fOffsetPosY);
	}

	// Use this for initialization
	void Start () {
		float rangeY = 0.1f;
		Vector2 fSacleRange = new Vector2 (1.0f, 1.0f);
		Vector2 fPosRange = new Vector2 (2.25f, 3.0f);
		mDeco [0] = gameObject.AddComponent<AutoBGDeco>();
		mDeco [0].init (mSmallWoodList, mCollider, fSacleRange, fPosRange, rangeY, 2.1f);
		mDeco [0].transform.parent = this.gameObject.transform;

		fSacleRange = new Vector2 (1.0f, 1.0f);
		fPosRange = new Vector2 (0.75f, 5.0f);
		mDeco [1] = gameObject.AddComponent<AutoBGDeco>();
		mDeco [1].init (mBallWoodList, mCollider, fSacleRange, fPosRange, rangeY, 2.1f);
		mDeco [1].transform.parent = this.gameObject.transform;


		fSacleRange = new Vector2 (1.0f, 1.0f);
		fPosRange = new Vector2 (1.92f, 10.0f);
		mDeco [2] = gameObject.AddComponent<AutoBGDeco>();
		mDeco [2].init (mWoodList, mCollider, fSacleRange, fPosRange, rangeY, 2.1f);
		mDeco [2].transform.parent = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
