using UnityEngine;
using System.Collections;

public class LoadRoom : MonoBehaviour {
	public string SceneName = "test";
	public string Destination = "0,0";
	public int Direction = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Loads room associated with this object
	public void EnterRoom() {
		GameManager.startPoint = Destination;
		GameManager.startDirection = Direction;
		Application.LoadLevel (SceneName);
	}
}
