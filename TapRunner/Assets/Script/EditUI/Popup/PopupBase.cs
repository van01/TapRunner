using UnityEngine;
using System.Collections;

public class PopupBase : MonoBehaviour {

	static int mPopupCount = 0;
	static int mPopupDepth = 0;

	public PopupListener mListener = null;

	// Use this for initialization
	void Start () {
		mPopupDepth = increasePopupDepth ();
		addDepthForChild (gameObject, mPopupDepth);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void addDepthForChild (GameObject parent, int nPopupDepth)
	{
		int cnt = parent.transform.childCount;

		UIWidget widget = parent.GetComponent<UIWidget>();
		if (widget != null) {
			widget.depth += nPopupDepth;
		}
		
		for (int i=0; i<cnt; i++) {
			GameObject obj = parent.transform.GetChild (i).gameObject;
			Debug.Log ("target : " + obj.name);
			addDepthForChild (obj, nPopupDepth);
		}
	}

	protected int increasePopupDepth ()
	{
		mPopupCount++;
		return 100 * mPopupCount;
	}

	protected int decreasePopupDepth()
	{
		mPopupCount--;
		return mPopupCount;
	}

	public void onClose()
	{
		if (mListener != null) 
		{
			mListener.onClose ();
		}

		closePopup ();
	}

	public void onCancel()
	{
		if (mListener != null) 
		{
			mListener.onCancel ();
		}

		closePopup ();
	}

	public void onOK()
	{
		if (mListener != null) 
		{
			mListener.onOK ();
		}

		closePopup ();
	}

	protected void closePopup()
	{
		DestroyObject (this.gameObject);
		decreasePopupDepth ();
	}
}
