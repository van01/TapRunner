using UnityEngine;
using System.Collections;

using System.Xml;
using System.Xml.Serialization;

public class AutoBGDecoData{

	[XmlAttribute("name")]
	public string strName;

	[XmlAttribute("MinScale")]
	public float fMinScale;
	
	[XmlAttribute("MaxScale")]
	public float fMaxScale;
	
	[XmlAttribute("MinPos")]
	public float fMinPos;
	
	[XmlAttribute("MaxPos")]
	public float fMaxPos;
	
	[XmlAttribute("RangePosY")]
	public float fRangPosY;
	
	[XmlAttribute("OffsetPosY")]
	public float fOffsetY;

	//data.setData (mTagList [m_nIndex], m_fMinPos, m_fMaxPos, m_fRangPosY, m_fOffsetPosY, m_fMinScale, m_fMaxScale);
	public void setData (string name, float fMinPos, float fMaxPos, float fMinScale, float fMaxScale, float fRangPosY, float fOffsetY)
	{
		this.strName = name;

		this.fMinPos = fMinPos;
		this.fMaxPos = fMaxPos;
		this.fMinScale = fMinScale;
		this.fMaxScale = fMaxScale;

		this.fRangPosY = fRangPosY;
		this.fOffsetY = fOffsetY;

	}
}
