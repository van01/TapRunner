using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public GameObject[] 	mListCloud;
	public GameObject[] 	mListMount;
	public GameObject[]		mListSmallWood;
	public GameObject[]		mListBallWood;
	public GameObject[]		mListTree;
	public BoxCollider2D	mBoxCollider;
	Vector2 mBoxSize = new Vector2(); 

	float mfColliderWidth;

	// Use this for initialization
	void Start () {
		mBoxSize.x = mBoxCollider.size.x * mBoxCollider.transform.localScale.x;
		mBoxSize.y = mBoxCollider.size.y * mBoxCollider.transform.localScale.y;
		mfColliderWidth = mBoxSize.x;


		resetPositionBallWood ();
		resetPositionSmallWood ();
		resetPositionCloud ();
		resetPositionMount ();
		resetPositionTree ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void resetPositionTree ()
	{
		float x 	= mBoxSize.x/2;
		float y		= mBoxSize.y/2 - 0.8f;
		float offsetY = 0.0f;
		Vector2 startPoint		= new Vector2 (-x, -y - offsetY);
		Vector2 endPoint		= new Vector2 (x, -y + offsetY);
		
		Debug.Log ("Start : " + startPoint.x + " : " + startPoint.y);
		Debug.Log ("End : " + endPoint.x + " : " + endPoint.y);
		float fMaxGap = mfColliderWidth / 2.0f;
		float fMinGap = mfColliderWidth / 5f;
		
		float nGapX = mfColliderWidth / 2.0f;
		randomPosition (this.transform, mListTree, startPoint, endPoint, fMinGap, fMaxGap, 1.0f, 1.0f);
		//randomPosition (mListMount, startPoint, endPoint, fMinGap, fMaxGap, fMinScale, fMaxScale);
	}

	void resetPositionBallWood ()
	{
		float x 	= mBoxSize.x/2;
		float y		= mBoxSize.y/2 - 0.8f;
		float offsetY = 0.0f;
		Vector2 startPoint		= new Vector2 (-x, -y - offsetY);
		Vector2 endPoint		= new Vector2 (x, -y + offsetY);

		Debug.Log ("Start : " + startPoint.x + " : " + startPoint.y);
		Debug.Log ("End : " + endPoint.x + " : " + endPoint.y);
		float fMaxGap = mfColliderWidth / 2.0f;
		float fMinGap = mfColliderWidth / 5f;

		float nGapX = mfColliderWidth / 2.0f;
		randomPosition (this.transform, mListBallWood, startPoint, endPoint, fMinGap, fMaxGap, 1.0f, 1.0f);
		//randomPosition (mListMount, startPoint, endPoint, fMinGap, fMaxGap, fMinScale, fMaxScale);
	}

	void resetPositionSmallWood ()
	{
		float x 	= mBoxSize.x/2;
		float y		= mBoxSize.y/2 - 0.6f;
		float offsetY = 0.2f;
		Vector2 startPoint		= new Vector2 (-x, -y - offsetY);
		Vector2 endPoint		= new Vector2 (x, -y + offsetY);

		Debug.Log ("Start : " + startPoint.x + " : " + startPoint.y);
		Debug.Log ("End : " + endPoint.x + " : " + endPoint.y);
		
		float nGapX = mfColliderWidth / 2.0f;
		randomPosition (this.transform, mListSmallWood, startPoint, endPoint, 2.5f, 2.6f, 1.0f, 1.0f);
		//randomPosition (mListMount, startPoint, endPoint, fMinGap, fMaxGap, fMinScale, fMaxScale);
	}

	void resetPositionMount ()
	{
		float fMinScale = 0.4f;
		float fMaxScale = 1.3f;
		float x 	= mBoxSize.x/2;
		float y		= mBoxSize.y/2;
		float offsetY = (y / 10);
		Vector2 startPoint		= new Vector2 (-x, -y + offsetY);
		Vector2 endPoint		= new Vector2 (x, -y - offsetY);

		Debug.Log ("Start : " + startPoint.x + " : " + startPoint.y);
		Debug.Log ("End : " + endPoint.x + " : " + endPoint.y);
		
		float fMaxGap = mfColliderWidth / 2.0f;
		float fMinGap = mfColliderWidth / 5f;
		randomPosition (this.transform, mListMount, startPoint, endPoint, fMinGap, fMaxGap, fMinScale, fMaxScale);

	}
	
	void resetPositionCloud ()
	{
		float x 	= mBoxSize.x/2;
		float y		= mBoxSize.y/2;
		Vector2 startPoint		= new Vector2 (-x, y);
		Vector2 endPoint		= new Vector2 (x, 0.0f);

		float fMaxGap = mfColliderWidth / 2.0f;
		float fMinGap = mfColliderWidth / 20f;
		randomPosition (this.transform, mListCloud, startPoint, endPoint, fMinGap, fMaxGap);
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
			int index = Random.Range (0, lpSprite.Length-1);
			
			x += Random.Range (fMinGap, fMaxGap);

			if (x > end.x)	break;

			float y = Random.Range (start.y, end.y);
			float scale = Random.Range (fMinScale, fMaxScale);
			
			GameObject obj = Instantiate (lpSprite [index], new Vector3(x, y, 0), Quaternion.identity) as GameObject;
			obj.transform.localScale = new Vector3 (scale, scale, 1.0f);
			obj.transform.parent = parent;
		}
	}

}
