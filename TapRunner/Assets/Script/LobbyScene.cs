using UnityEngine;
using System.Collections;

public class LobbyScene : MonoBehaviour {

	public GameObject m_ScrollView_lobby;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onClickMainMenu()
	{
		Debug.Log ("MainMenu");
		LobbyScrollView view = m_ScrollView_lobby.GetComponent<LobbyScrollView> ();
		view.moveNext ();

	}

	public void onSelectStage1(){onSelectStage (1);}
	public void onSelectStage2(){onSelectStage (2);}
	public void onSelectStage3(){onSelectStage (3);}
	public void onSelectStage4(){onSelectStage (4);}
	public void onSelectStage5(){onSelectStage (5);}
	public void onSelectStage6(){onSelectStage (6);}
	public void onSelectStage7(){onSelectStage (7);}
	public void onSelectStage8(){onSelectStage (8);}
	public void onSelectStage9(){onSelectStage (9);}


	public void onSelectStage (int nStage)
	{
		Debug.Log ("onSelectStage : " + nStage);
	}
}
