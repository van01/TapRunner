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

}
