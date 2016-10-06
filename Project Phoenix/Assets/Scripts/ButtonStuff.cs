using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;

public class ButtonStuff : MonoBehaviour {
	public string link;
	public Character Enemy1;
	public Character Enemy2;
	public Character Enemy3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//
	public void IntializeCharacter() {
		Enemy1 = new Character (null, 0, 0, 0, 0, null, new ArrayList (), new ArrayList (), new ArrayList (), new ArrayList ());
		Enemy2 = new Character (null, 0, 0, 0, 0, null, new ArrayList (), new ArrayList (), new ArrayList (), new ArrayList ());
		Enemy3 = new Character (null, 0, 0, 0, 0, null, new ArrayList (), new ArrayList (), new ArrayList (), new ArrayList ());
	}

	//add onclick listener for this button and link it to GameManager's AttachScriptsToButtons method
	public void addScriptListener() {
		Debug.Log (link);
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => {
			GameObject.Find("GameManager").GetComponent<GameManager>().AttachScriptsToButtons (this.gameObject);
		});
	}
}
