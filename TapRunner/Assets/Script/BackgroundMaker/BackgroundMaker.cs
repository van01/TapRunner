using UnityEngine;
using System.Collections;

public class BackgroundMaker : MonoBehaviour {

	
	public GameObject[]		mMountList;
	public GameObject[]		mCloundList;
	public BoxCollider2D	mCollider;
	
	AutoBGDeco []mDeco = new AutoBGDeco[5];
	
	[Range (0, 5)]
	public float m_fMinPos = 2.25f;
	[Range (0, 10)]
	public float m_fMaxPos = 3.0f;
	public float m_fRangPosY = 0.1f;
	[Range (-5, 5)]
	public float m_fOffsetPosY = 2.1f;

	[Range (0,5)]
	public float m_fMinScale = 1.0f;
	[Range (0,5)]
	public float m_fMaxScale = 1.0f;

	
	public void onTest()
	{
		Debug.Log ("Test");
		Vector2 fSacleRange	= new Vector2 (m_fMinScale, m_fMaxScale);
		Vector2 fPosRange	= new Vector2 (m_fMinPos, m_fMaxPos);
		
		mDeco [1].clear ();
		mDeco [1] = gameObject.AddComponent<AutoBGDeco>();
		mDeco [1].init (mCloundList, mCollider, fSacleRange, fPosRange, m_fRangPosY,m_fOffsetPosY);
	}
	
	// Use this for initialization
	void Start () {
		float rangeY = 0.1f;
		Vector2 fSacleRange = new Vector2 (0.33f, 1.0f);
		Vector2 fPosRange = new Vector2 (5.0f, 10.0f);
		mDeco [0] = gameObject.AddComponent<AutoBGDeco>();
		mDeco [0].init (mMountList, mCollider, fSacleRange, fPosRange, rangeY, 0.1f);
		mDeco [0].transform.parent = this.gameObject.transform;


		rangeY = 1.21f;
		fSacleRange = new Vector2 (0.9f, 1.2f);
		fPosRange = new Vector2 (4.0f, 8.0f);
		mDeco [1] = gameObject.AddComponent<AutoBGDeco>();
		mDeco [1].init (mCloundList, mCollider, fSacleRange, fPosRange, rangeY, -4.4f);
		mDeco [1].transform.parent = this.gameObject.transform;
	}
}
