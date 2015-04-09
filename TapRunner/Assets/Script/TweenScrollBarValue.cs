//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Tween the widget's size.
/// </summary>

[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Tween/Tween ScrollBar Value")]
public class TweenScrollBarValue : UITweener
{
	public float from = 0;
	public float to = 1;
	public bool updateTable = false;
	
	UIScrollBar mWidget;
	UITable mTable;
	
	public UIScrollBar cachedWidget { 
		get { 
			if (mWidget == null) 
				mWidget = GetComponent<UIScrollBar>(); 
			return mWidget; 
		} 
	}
	
	/// <summary>
	/// Tween's current value.
	/// </summary>
	
	public float value { 
		get { return cachedWidget.value; } 
		set { cachedWidget.value = value; } 
	}
	
	/// <summary>
	/// Tween the value.
	/// </summary>
	
	protected override void OnUpdate (float factor, bool isFinished)
	{
		//value = Mathf.RoundToInt(from * (1f - factor) + to * factor);
		value = from * (1f - factor) + to * factor;
		Debug.Log ( value + " = " + from +"*"+ "(1f - "+ factor + ") + " + to + "*" + factor);
		Debug.Log ("cachedWidget.value : " + cachedWidget.value);
		
		if (updateTable)
		{
			if (mTable == null)
			{
				mTable = NGUITools.FindInParents<UITable>(gameObject);
				if (mTable == null) { updateTable = false; return; }
			}
			mTable.repositionNow = true;
		}
	}
	
	/// <summary>
	/// Start the tweening operation.
	/// </summary>
	
	static public TweenHeight Begin (UIWidget widget, float duration, int height)
	{
		TweenHeight comp = UITweener.Begin<TweenHeight>(widget.gameObject, duration);
		comp.from = widget.height;
		comp.to = height;
		
		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}
	
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue () { from = value; }
	
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue () { to = value; }
	
	[ContextMenu("Assume value of 'From'")]
	void SetCurrentValueToStart () { value = from; }
	
	[ContextMenu("Assume value of 'To'")]
	void SetCurrentValueToEnd () { value = to; }
}
