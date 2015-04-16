using UnityEngine;
using System.Collections;

public class PlayerSkillList : MonoBehaviour {

	public GameObject m_prefab;

	private bool m_isReposition = false;

	// Use this for initialization
	void Start () {
		if (m_prefab != null) {

			UIGrid grid = GetComponentInChildren<UIGrid>();

			NGUITools.AddChild(grid.gameObject, m_prefab);
			NGUITools.AddChild(grid.gameObject, m_prefab);
			NGUITools.AddChild(grid.gameObject, m_prefab);
			NGUITools.AddChild(grid.gameObject, m_prefab);

			grid.Reposition ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
