using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;

public class TextScroll : MonoBehaviour {
	private int placeHolder = 0;
	private string dialog;
	private bool isScrolling = false;
	private bool inUse = false;
	public float textScrollSpeed = .05f;
	public string startingText = "test";

	// Use this for initialization
	void Start () {
		load ((TextAsset) Resources.Load (startingText));
	}
	
	// Update is called once per frame
	void Update () {

		//checks when it should stop scrolling text and stops it
		if (placeHolder >= dialog.IndexOf('\n')) {
			isScrolling = false;
			CancelInvoke ();
			reset ();
		}

		//given an action it performs a text response
		if (Input.GetAxisRaw("Action") != 0 && !inUse) {
			inUse = true;

			//if the text is at the end of the tree
			if (dialog.Substring (0, 3).Equals ("***")) {
				
			} 

			//if the text leads to a fight then method
			else if(dialog.Substring(0,3).Equals("///")) {
				placeHolder = dialog.IndexOf ('\n');
				reset();
				string[] charas = dialog.Substring(0, dialog.IndexOf('\n')).Split(',');
				Debug.Log(charas[0] + " , " + charas[1]);
				Character en2 = new Character (null, 0, 0, 0, 0, null, new ArrayList (), new ArrayList (), new ArrayList (), new ArrayList ());
				Character en3 = new Character (null, 0, 0, 0, 0, null, new ArrayList (), new ArrayList (), new ArrayList (), new ArrayList ());
				Character en1 = GameObject.Find("GameManager").GetComponent<GameManager>().CharacterSetUp(charas[0]);
				if(charas.Length > 1) {
					en2 = GameObject.Find("GameManager").GetComponent<GameManager>().CharacterSetUp(charas[1]);
				}
				if(charas.Length > 2) {
					en3 = GameObject.Find("GameManager").GetComponent<GameManager>().CharacterSetUp(charas[2]);
				}
				GameObject.Find("GameManager").GetComponent<GameManager>().Fight(en1, en2, en3);
			}

			//if the text has choices next then it uses the ChoicesSetUp method in GameManager script
			else if(dialog.Substring (0, 3).Equals ("---")) {

				//if the buttons are not set up already
				if (!GameManager.ChoicesSet) {
					GameObject.Find ("GameManager").GetComponent<GameManager> ().dialog = dialog;
					GameObject.Find ("GameManager").GetComponent<GameManager> ().ChoicesSetUp (true);
				}
			} else {

				//if the text is already scrolling skips scrolling
				if (isScrolling) {
					placeHolder = dialog.IndexOf ('\n');
					this.gameObject.GetComponent<Text> ().text = dialog.Substring (0, placeHolder);
					isScrolling = false;
					CancelInvoke ();
					reset ();
				} 

				//plays next line
				else {
					nextDialog ();
				}
			}
		}

		if (Input.GetAxisRaw("Action") == 0) {
			inUse = false;
		}
	}

	//public method to load given textAsset. Just calls loading method
	public static void load(TextAsset text) {
		GameObject.Find("DialogText").GetComponent<TextScroll> ().loading (text);
	}

	//sets this scripts dialog string as the text in the given TextAsset
	public void loading(TextAsset text) {
		dialog = text.text;
		nextDialog ();
	}

	//clips dialog string at current point
	void reset() {
		placeHolder++;
		dialog = dialog.Substring (placeHolder);
		placeHolder = 0;
	}

	//sets character name from script and sets up text box then invokes scrollText method
	void nextDialog() {
		placeHolder = dialog.IndexOf ('\n');
		GameObject.Find ("Name").GetComponent<Text> ().text = dialog.Substring (0, placeHolder);
		reset ();
		this.gameObject.GetComponent<Text> ().text = "";
		InvokeRepeating ("scrollText", 0, textScrollSpeed);
	}

	//scrolls text by adding letters one at a time
	void scrollText() {
		isScrolling = true;
		this.gameObject.GetComponent<Text> ().text = this.gameObject.GetComponent<Text> ().text.Insert (this.gameObject.GetComponent<Text> ().text.Length, dialog.Substring (placeHolder, 1));
		placeHolder++;
	}
}
