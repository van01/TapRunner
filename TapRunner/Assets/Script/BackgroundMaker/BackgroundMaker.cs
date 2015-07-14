using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;


public class BackgroundMaker : ObjectMaker {

	public enum OBJ_TYPE{
		TYPE_CLOUD,
		TYPE_MOUNT,
		TYPE_MAX
	};
	private static int MAX = (int)OBJ_TYPE.TYPE_MAX;

	public GameObject[]		mMountList;
	public GameObject[]		mCloudList;


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
		initData (MAX);

		//2. set prefabs
		mPrefabList [(int)OBJ_TYPE.TYPE_MOUNT] = mMountList;
		mPrefabList [(int)OBJ_TYPE.TYPE_CLOUD] = mCloudList;

		//3. load data from xml
		loadData ();
		onSelect (0);
	}
	
}


