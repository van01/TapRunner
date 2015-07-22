using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public class ObjectMaker : MonoBehaviour {

	public float m_fMinPos;
	public float m_fMaxPos;
	public float m_fRangPosY;
	public float m_fOffsetPosY;
	public float m_fMinScale;
	public float m_fMaxScale;

	public BoxCollider2D	mCollider;

	protected AutoBGDecoContainer mDecoContainer = new AutoBGDecoContainer();
	public List<AutoBGDeco> mDeco = new List<AutoBGDeco>();

	//prefab list
	protected GameObject[][]	mPrefabList;
	protected string []mTagList;

	public int m_nIndex = 0;
	private string mTagName = "none";


	protected void initData(int max, string tagName)
	{
		mTagName = tagName;
		mPrefabList = new GameObject[max][];

		for (int i=0; i<max; i++) {
			mDeco.Add (new AutoBGDeco ());
			mDecoContainer.AddBGDecoData (new AutoBGDecoData());
		}
	}

	public void loadData()
	{
		load ();

		for (int i=0; i<mTagList.Length; i++) {
			mDeco [i] = gameObject.AddComponent<AutoBGDeco> ();
			AutoBGDecoData data = mDecoContainer.GetBGDecoData (i);
			mDeco [i].init (mPrefabList [i], mCollider, data);
		}
	}

	public void Apply()
	{
		
		//mData [m_nIndex].setData (m_fMinPos, m_fMaxPos, m_fRangPosY, m_fOffsetPosY, m_fMinScale, m_fMaxScale);
		
		Debug.Log ("Test : " + m_nIndex);
		//Vector2 vtSacleRange	= new Vector2 (m_fMinScale, m_fMaxScale);
		//Vector2 vtPosRange	= new Vector2 (m_fMinPos, m_fMaxPos);
		
		if (mDeco [m_nIndex] != null) {
			mDeco [m_nIndex] .clear ();
			GameObject.Destroy (mDeco [m_nIndex]);
		}
		mDeco[m_nIndex] = gameObject.AddComponent<AutoBGDeco>();
		AutoBGDecoData data = mDecoContainer.GetBGDecoData (m_nIndex);
		data.setData (mTagList [m_nIndex], m_fMinPos, m_fMaxPos, m_fMinScale, m_fMaxScale, m_fRangPosY, m_fOffsetPosY);
		mDeco[m_nIndex].init (mPrefabList[m_nIndex], mCollider, data);
	}

	
	public void onSelect (int index)
	{
		m_nIndex = index;

		AutoBGDecoData data = mDecoContainer.GetBGDecoData (index);
		
		m_fMinPos = data.fMinPos;
		m_fMaxPos = data.fMaxPos;
		m_fRangPosY = data.fRangPosY;
		m_fOffsetPosY = data.fOffsetY;
		m_fMinScale = data.fMinScale;
		m_fMaxScale = data.fMaxScale;
	}

	private void setData (int index,float minScale, float maxScale, float posX, float posY, float rangeY, float offsetY)
	{
		AutoBGDecoData data = mDecoContainer.GetBGDecoData (m_nIndex);

		mDeco[m_nIndex] = gameObject.AddComponent<AutoBGDeco>();
		mDeco[m_nIndex].init (mPrefabList[index], mCollider, data);
		mDeco[m_nIndex].transform.parent = this.gameObject.transform;
	}
	
	public void Reset()
	{
		mDeco[m_nIndex].reset();
	}

	public virtual string[] getObjectList()
	{
		return mTagList;
	}


	public string getFilePath (string fileTag)
	{
		return Application.dataPath+"/xml/"+fileTag+".xml";
	}

	/// <summary>
	/// save to xml
	/// </summary>
	public void save()
	{
		string path = getFilePath (mTagName);
		
		var serializer = new XmlSerializer (typeof(AutoBGDecoContainer));
		var stream = new FileStream (path, FileMode.Create);
		serializer.Serialize (stream, mDecoContainer);
		stream.Close ();
	}
	
	public void load()
	{
		string path = getFilePath (mTagName);

		var serializer = new XmlSerializer(typeof(AutoBGDecoContainer));
		var stream = new FileStream(path, FileMode.Open);
		mDecoContainer = serializer.Deserialize(stream) as AutoBGDecoContainer;
		stream.Close();
	}

}
