using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("AutoBGDecoContainer")]
public class AutoBGDecoContainer{
	[XmlArray("BGObjects")]
	[XmlArrayItem("BGObject")]
	public List<AutoBGDecoData> mDecoData = new List<AutoBGDecoData>();


	public void AddBGDecoData (AutoBGDecoData data)
	{
		mDecoData.Add (data);
	}

	public AutoBGDecoData GetBGDecoData (int nIndex)
	{
		return mDecoData[nIndex];
	}

	public void save()
	{
		var serializer = new XmlSerializer (typeof(AutoBGDecoContainer));
		string path = Application.dataPath+"/test.xml";
		Debug.Log("Save Start : " + path);
		var stream = new FileStream (path, FileMode.Create);
		serializer.Serialize (stream, this);
		stream.Close ();
		Debug.Log("Save End");

	}
}
