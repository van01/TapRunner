using UnityEngine;
using System.Collections;

using System.Xml;
using System.Xml.Serialization;

public class AutoBGDecoData{
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
}
