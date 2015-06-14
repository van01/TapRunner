using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoBGDeco : MonoBehaviour{

	private List<GameObject> myList = new List<GameObject>();

	private GameObject[] 	mListDeco;
	private BoxCollider2D	mBoxCollider;
	Vector2 mBoxSize = new Vector2(); 

	Vector2 mScaleRange;
	Vector2 mPosRange;
	
	Vector2 mStartPoint;
	Vector2 mEndPoint;
	float m_fRangPosY;

	public AutoBGDeco ()
	{
	}

	public void init (GameObject []list, BoxCollider2D collider, Vector2 fScaleRange, Vector2 fPosRange,float fRangPosY, float fOffsetY)
	{
		mListDeco 		= list;
		mBoxCollider 	= collider;
		mScaleRange 	= fScaleRange;
		mPosRange		= fPosRange;

		mBoxSize.x 		= mBoxCollider.size.x * mBoxCollider.transform.localScale.x;
		mBoxSize.y 		= mBoxCollider.size.y * mBoxCollider.transform.localScale.y;

		Debug.Log ("box : " + mBoxSize.x + " : " + mBoxSize.y);

		float x 		= mBoxSize.x/2;
		float y			= mBoxSize.y/2 + fOffsetY;
		m_fRangPosY		= fRangPosY;
		mStartPoint		= new Vector2 (-x, -y + m_fRangPosY);
		mEndPoint		= new Vector2 (x, -y - m_fRangPosY);

		reset ();
	}

	public void clear()
	{
		foreach (GameObject obj in myList) 
		{
			Destroy (obj);
		}
	}

	public void reset ()
	{
		clear ();
		myList.Clear ();

		float fMaxGap = mPosRange.x;
		float fMinGap = mPosRange.y;
		randomPosition (transform, mListDeco, mStartPoint, mEndPoint, fMinGap, fMaxGap, mScaleRange.x, mScaleRange.y);
	}


	/**
	 * lpSprite : 이미지 스프라이트
	 * start  : 랜덤 영역 왼쪽 상단 지점
	 * end : 랜덤 영역 오른쪽 하단 지점
	 * fMinGap : 랜덤 최소값 (좌표)
	 * fMaxGap : 램덤 최대값 (좌표)
	 * fMinScale : 램덤 최대값 (스케일)
	 * fMaxScale : 램덤 최대값 (스케일)
	 */
	void randomPosition (Transform parent, GameObject []lpSprite, Vector2 start, Vector2 end, float fMinGap, float fMaxGap, float fMinScale = 1, float fMaxScale = 1)
	{
		float x = start.x;
		while (x < end.x)
		{
			int index = Random.Range (0, lpSprite.Length);
			
			if (x > end.x)	break;
			
			float y = Random.Range (start.y, end.y);
			float scale = Random.Range (fMinScale, fMaxScale);
			Vector3 pos = new Vector3 (x, y, 0);
			pos += transform.localPosition;
			GameObject obj = Instantiate (lpSprite [index], pos, Quaternion.identity) as GameObject;
			obj.transform.localScale = new Vector3 (scale, scale, 1.0f);
			obj.transform.parent = parent;

			myList.Add (obj);

			x += Random.Range (fMinGap, fMaxGap);

		}
	}
	
}
