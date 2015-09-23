using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;


public class NormalBGMaker : ObjectMaker {

	private string tagName = "stage1_bg_normal";
	public enum OBJ_TYPE{
		TYPE_SMALL_WOOD,
		TYPE_BALL_WOOD,
		TYPE_WOOD,
		TYPE_OBSTACLE,
		TYPE_ITEM1,
		TYPE_MAX
	};
	private static int MAX = (int)OBJ_TYPE.TYPE_MAX;

	public GameObject[]		mSmallWoodList;
	public GameObject[]		mBallWoodList;
	public GameObject[]		mWoodList;
	public GameObject[]		mObstacleList;
	public GameObject[]		mItemList1;


	// Use this for initialization
	void Start () {
		initTagList ();
		initData ();
	}

	/* must start in Function of Start of First*/
	protected void initTagList()
	{
		mTagList = new string[MAX];
		for (int i=0; i<MAX; i++) {
			mTagList[i] = ((OBJ_TYPE)i).ToString();
		}
	}
	
	void initData()
	{
		//1. initilaize
		initData (MAX, tagName);

		//2. set prefabs
		mPrefabList [(int)OBJ_TYPE.TYPE_SMALL_WOOD] = mSmallWoodList;
		mPrefabList [(int)OBJ_TYPE.TYPE_BALL_WOOD] = mBallWoodList;
		mPrefabList [(int)OBJ_TYPE.TYPE_WOOD] = mWoodList;
		mPrefabList [(int)OBJ_TYPE.TYPE_OBSTACLE] = mObstacleList;
		mPrefabList [(int)OBJ_TYPE.TYPE_ITEM1] = mItemList1;

		//3. load data from xml
		loadData ();
		onSelect (0);
	}
	
}


