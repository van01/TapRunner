using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoBGDeco : MonoBehaviour{

	private List<GameObject> myList = new List<GameObject>();

	private GameObject[] 	mListDeco;
	private BoxCollider2D	mBoxCollider;

	public Vector2 mBoxSize = new Vector2(); 

	public AutoBGDecoData mData;
	
	public Vector2 mStartPoint;
	public Vector2 mEndPoint;

	public void init (GameObject []list, BoxCollider2D collider, AutoBGDecoData data)
	{
		mData = data;
		mListDeco 		= list;
		mBoxCollider 	= collider;
		//mScaleRange 	= fScaleRange;

		mBoxSize.x 		= mBoxCollider.size.x * mBoxCollider.transform.localScale.x;
		mBoxSize.y 		= mBoxCollider.size.y * mBoxCollider.transform.localScale.y;

		Debug.Log ("box : " + mBoxSize.x + " : " + mBoxSize.y);

		float x 		= mBoxSize.x/2;
		float y			= mBoxSize.y/2 + mData.fOffsetY;
		mStartPoint		= new Vector2 (-x, -y + mData.fRangPosY);
		mEndPoint		= new Vector2 (x, -y - mData.fRangPosY);

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

		//randomPosition (transform, mListDeco, mStartPoint, mEndPoint, fMinGap, fMaxGap, mScaleRange.x, mScaleRange.y);
		randomPosition (transform, mListDeco, 
		                mStartPoint, mEndPoint, 
		                mData.fMinPos, mData.fMaxPos, 
		                mData.fMinScale, mData.fMaxScale);
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
		int MAX = 100;
		int cnt = 0;
		float x = start.x;
		while (x < end.x & ++cnt < MAX)
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
