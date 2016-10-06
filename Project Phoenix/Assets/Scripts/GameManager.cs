using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	private GameObject Dialog;
	private GameObject Background;
	private GameObject DialogBoxBackground;
	private GameObject Person1;
	private GameObject Person2;
	private GameObject DialogBoxBackgroundUpper;
	private GameObject DialogText;
	private GameObject Fades;
	private static GameObject Content;
	private static GameObject Choices;
	private static GameObject ChoiceButton;
	private static GameObject[] ChoiceButtons;
	private GameObject Name;
	private static bool Play;
	public static string startPoint = "0,0";
	public static int startDirection = 0;
	public static string startLevel = "Test";
	public string dialog;
	private int placeHolder;
	public static bool ChoicesSet = false;
	private static Character Player;
	public Dictionary<string, BattleOption> Abilities;

	void Awake() {
		Application.LoadLevel (startLevel);
		this.gameObject.GetComponent<GameManager> ().enabled = true;
		this.gameObject.GetComponent<AudioManager> ().playBackground (1);
	}

	// Use this for initialization
	void Start () {
		makeSpacesMovable ();
		Play = false;
		findObjects ();
		resizeContent ();
		deactiveObjects ();
	}

	void Update() {
		
	}

	private void createSortAbilities() {
		Skill Ray = new Skill ("Ray", 5, 0, 2);
		Skill Beam = new Skill ("Beam", 10, 0, 2);
		Skill Laser = new Skill ("Laser", 15, 0, 2);
		Skill Fire = new Skill ("Fire", 10, 0, 7);
		Skill Fira = new Skill ("Fira", 15, 0, 7);
		Skill Firaga = new Skill ("Firaga", 20, 0, 7);
		Skill SkNull = new Skill ("Null", -1, -1, -1);
		Magic Thunder = new Magic ("Thunder", 10, 10, 0, 2, "Lightning", Resources.Load<Sprite>("Lightning"), this.gameObject.GetComponent<AudioManager>().battleSounds[8]);
		Magic MagNull = new Magic ("Null", -1, -1, -1, -1);
		Item Harm = new Item ("Harm", 1, 5, 0, 5);
		Item Potion = new Item ("Potion", 1, -20, 0, 0, "hp", Resources.Load<Sprite>("hp"), this.gameObject.GetComponent<AudioManager>().battleSounds[9]);
		Item Speed = new Item ("Speed", 5, 0, -1, 0, "hp", Resources.Load<Sprite>("Wisp"), this.gameObject.GetComponent<AudioManager>().battleSounds[9]);
		Item ItNull = new Item ("Null", -1, -1, -1, -1);
		Special Beserk = new Special ("Beserk", 50, 0, 5);
		Special SpecNull = new Special ("Null", -1, -1, -1);
		Abilities.Add ("Ray", Ray);
		Abilities.Add ("Beam", Beam);
		Abilities.Add ("Laser", Laser);
		Abilities.Add ("Fire", Fire);
		Abilities.Add ("Fira", Fira);
		Abilities.Add ("Firaga", Firaga);
		Abilities.Add ("SkNull", SkNull);
		Abilities.Add ("Thunder", Thunder);
		Abilities.Add ("MagNull", MagNull);
		Abilities.Add ("Harm", Harm);
		Abilities.Add ("Potion", Potion);
		Abilities.Add ("Speed", Speed);
		Abilities.Add ("ItNull", ItNull);
		Abilities.Add ("Beserk", Beserk);
		Abilities.Add ("SpecNull", SpecNull);
	}

	private void ActivateBattleMode(Character Enemy1, Character Enemy2, Character Enemy3) {
		this.gameObject.GetComponent<BattleManager> ().enabled = true;
		ArrayList Skills = new ArrayList ();
		Skills.Add (Abilities["Ray"]);
		Skills.Add (Abilities["Beam"]);
		Skills.Add (Abilities["Laser"]);
		Skills.Add (Abilities["Fire"]);
		Skills.Add (Abilities["Fira"]);
		Skills.Add (Abilities["Firaga"]);
		ArrayList Skills2 = new ArrayList ();
		Skills2.Add (Abilities["Ray"]);
		Skills2.Add (Abilities["Beam"]);
		Skills2.Add (Abilities["Fire"]);
		Skills2.Add (Abilities["Fira"]);
		ArrayList Skills3 = new ArrayList ();
		Skills3.Add (Abilities["Laser"]);
		Skills3.Add (Abilities["Firaga"]);
		ArrayList Magic = new ArrayList ();
		Magic.Add (Abilities["Thunder"]);
		ArrayList Items = new ArrayList ();
		Items.Add (Abilities["Harm"]);
		Items.Add (Abilities["Speed"]);
		Items.Add (Abilities ["Potion"]);
		ArrayList Specials = new ArrayList ();
		Specials.Add (Abilities["Beserk"]);
		Character player = new Character ("Test", 100, 10, 15, 2, null, Skills, Magic, Items, Specials);
		Player = player;
		Character player2 = new Character ("P2", 200, 50, 25, 5, null, Skills2, Magic, Items, Specials);
		Character player3 = new Character ("P3", 50, 200, 20, 7, null, Skills3, Magic, Items, new ArrayList());
		Character enemy2 = new Character ("badGuy2", 100, 100, 10, 0, null, Skills,new ArrayList(), new ArrayList(), new ArrayList());
		Debug.Log (Player.Name);
		Debug.Log (player2.Name);
		Debug.Log (player3.Name);
		Debug.Log (Enemy1.Name);
		Debug.Log (Enemy2.Name);
		Debug.Log (Enemy3.Name);
		this.gameObject.GetComponent<BattleManager> ().SetUpBattle (Player, player2, player3, Enemy1, Enemy2, Enemy3);
		this.gameObject.GetComponent<GameManager> ().enabled = false;
	}

	private void ActivateBattleMode(Character Enemy1, Character Enemy2) {
		ActivateBattleMode (Enemy1, Enemy2, new Character (null, 0, 0, 0, 0, null, new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList()));
	}

	private void ActivateBattleMode(Character Enemy1) {
		ActivateBattleMode (Enemy1, new Character (null, 0, 0, 0, 0, null, new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList()), new Character (null, 0, 0, 0, 0, null, new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList()));
	}

	//IEnumerator for waiting the given amount of time
	IEnumerator WaitFade(float time, Character Enemy1, Character Enemy2, Character Enemy3) {
		Fades.SetActive (true);
		this.gameObject.GetComponent<AudioManager> ().playSound (0, 0);
		yield return new WaitForSeconds (time);
		ActivateBattleMode (Enemy1, Enemy2, Enemy3);
	}

	//sets up the transition from open world to dialoge
	public void interact() {
		DialogSetUp (true);
	}

	//grabs each object that the GameManager is in charge of
	void findObjects() {
		Content = GameObject.Find ("Content");
		ChoiceButton = GameObject.Find ("Choice Button");
		Abilities = new Dictionary<string, BattleOption> ();
		createSortAbilities ();
		ChoiceButton.GetComponent<ButtonStuff> ().IntializeCharacter ();
		ChoiceButtons = new GameObject[20];
		ChoiceButtons [0] = ChoiceButton;
		Choices = GameObject.Find ("Choices");
		DialogText = GameObject.Find ("DialogText");
		DialogBoxBackgroundUpper = GameObject.Find ("DialogBoxBackgroundUpper");
		Person2 = GameObject.Find ("Person 2");
		Person1 = GameObject.Find ("Person 1");
		DialogBoxBackground = GameObject.Find ("DialogBoxBackground");
		Background = GameObject.Find ("Background");
		Dialog = GameObject.Find ("Dialog");
		Name = GameObject.Find ("Name");
		Fades = GameObject.Find ("Fades");
	}

	//deactivate the UI objects
	void deactiveObjects() {
		Choices.SetActive (false);
		DialogText.SetActive (false);
		DialogBoxBackgroundUpper.SetActive (false);
		Person2.SetActive (false);
		Person1.SetActive (false);
		DialogBoxBackground.SetActive (false);
		Background.SetActive (false);
		Name.SetActive (false);
		Fades.SetActive (false);
		Play = true;
	}

	//resizes the choice buttons to the correct size
	void resizeContent() {
		RectTransform rt = Content.GetComponent<RectTransform> ();
		rt.sizeDelta = new Vector2 (rt.sizeDelta.x, rt.childCount * 60 + 10);
	}

	//makes each object with the "Space" tag a space that is movable to
	void makeSpacesMovable() {
		foreach (GameObject space in GameObject.FindGameObjectsWithTag("Space")) {
			space.name = (space.transform.position.x / 5) + "," + (space.transform.position.y / 5);
		}
	}

	//Have the TextScroll script load(method) the given Button's link and turn off the button options
	public void AttachScriptsToButtons(GameObject Button) {
		if (Button.GetComponent<ButtonStuff> ().link.Equals ("fight")) {
			Fight (Button.GetComponent<ButtonStuff> ().Enemy1, Button.GetComponent<ButtonStuff> ().Enemy2, Button.GetComponent<ButtonStuff> ().Enemy3);
			DialogSetUp (false);
			ChoicesSetUp (false);
		} else {
			TextScroll.load ((TextAsset)Resources.Load (Button.GetComponent<ButtonStuff> ().link));
			GameObject.Find ("GameManager").GetComponent<GameManager> ().ChoicesSetUp (false);
		}
	}

	public void Fight(Character enemy1, Character enemy2, Character enemy3) {
		StartCoroutine (WaitFade (1.5f, enemy1, enemy2, enemy3));
	}

	public static bool isPlayable() {
		return Play;
	}

	//sets up the button choices
	public void ChoicesSetUp(bool setactive) {
		Choices.SetActive (setactive);
		ChoicesSet = setactive;

		if (setactive) {
			//skip past the intial dashes
			placeHolder = dialog.IndexOf ('\n');
			placeHolder++;
			dialog = dialog.Substring (placeHolder);
			placeHolder = 0;

			//grab the initial text and make the first button use it
			placeHolder = dialog.IndexOf ('-');
			ChoiceButton.GetComponentInChildren<Text> ().text = dialog.Substring (0, placeHolder);

			//skip past the dash
			placeHolder++;
			dialog = dialog.Substring (placeHolder);

			//grab and use the script location
			placeHolder = dialog.IndexOf ('\n');
			if (dialog.Substring (0, 4) != null && dialog.Substring (0, 4).Equals("fight")) {
				ChoiceButton.GetComponent<ButtonStuff> ().link = dialog.Substring (0, 4);
				dialog = dialog.Substring (4);
				placeHolder = dialog.IndexOf ('\n');
				if (dialog.Substring (0, placeHolder - 1).IndexOf (',') != -1) {
					placeHolder = dialog.Substring (0, placeHolder - 1).IndexOf (',');
					ChoiceButton.GetComponent<ButtonStuff> ().Enemy1 = CharacterSetUp (dialog.Substring (0, placeHolder));
					placeHolder++;
					dialog = dialog.Substring (placeHolder);
					placeHolder = dialog.IndexOf ('\n');
					if (dialog.Substring (0, placeHolder - 1).IndexOf (',') != -1) {
						placeHolder = dialog.Substring (0, placeHolder - 1).IndexOf (',');
						ChoiceButton.GetComponent<ButtonStuff> ().Enemy2 = CharacterSetUp (dialog.Substring (0, placeHolder));
						placeHolder++;
						dialog = dialog.Substring (placeHolder);
						placeHolder = dialog.IndexOf ('\n');
						ChoiceButton.GetComponent<ButtonStuff> ().Enemy3 = CharacterSetUp (dialog.Substring (0, placeHolder));
					} else {
						ChoiceButton.GetComponent<ButtonStuff> ().Enemy2 = CharacterSetUp (dialog.Substring (0, placeHolder));
					}
				} else {
					ChoiceButton.GetComponent<ButtonStuff> ().Enemy1 = CharacterSetUp (dialog.Substring (0, placeHolder));
				}
			} else {
				ChoiceButton.GetComponent<ButtonStuff> ().link = dialog.Substring (0, placeHolder - 1);
			}
			ChoiceButton.GetComponent<ButtonStuff> ().addScriptListener ();

			//skip to the next line
			placeHolder++;
			dialog = dialog.Substring (placeHolder);
			placeHolder = 0;

			//repeat with the rest of the button options
			int count = 1;
			while (!dialog.Substring (0, 3).Equals ("---")) {
				ChoiceButtons [count] = ((GameObject)Instantiate (ChoiceButtons [count - 1]));
				ChoiceButtons [count].transform.SetParent (Content.transform);
				ChoiceButtons [count].GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				ChoiceButtons [count].transform.localPosition = new Vector2 (ChoiceButtons [count - 1].transform.localPosition.x, ChoiceButtons [count - 1].transform.localPosition.y - 55);
				ChoiceButtons [count].GetComponent<ButtonStuff> ().IntializeCharacter ();
				placeHolder = dialog.IndexOf ('-');
				ChoiceButtons [count].GetComponentInChildren<Text> ().text = dialog.Substring (0, placeHolder);
				placeHolder++;
				dialog = dialog.Substring (placeHolder);
				placeHolder = dialog.IndexOf ('\n');
				if (dialog.Substring (0, 5) != null && dialog.Substring (0, 5).Equals("fight")) {
					ChoiceButtons [count].GetComponent<ButtonStuff> ().link = dialog.Substring (0, 5);
					dialog = dialog.Substring (5);
					placeHolder = dialog.IndexOf ('\n');
					if (dialog.Substring (0, placeHolder - 1).IndexOf (',') != -1) {
						placeHolder = dialog.Substring (0, placeHolder - 1).IndexOf (',');
						ChoiceButtons [count].GetComponent<ButtonStuff> ().Enemy1 = CharacterSetUp (dialog.Substring (0, placeHolder));
						placeHolder++;
						dialog = dialog.Substring (placeHolder);
						placeHolder = dialog.IndexOf ('\n');
						if (dialog.Substring (0, placeHolder - 1).IndexOf (',') != -1) {
							placeHolder = dialog.Substring (0, placeHolder - 1).IndexOf (',');
							ChoiceButtons [count].GetComponent<ButtonStuff> ().Enemy2 = CharacterSetUp (dialog.Substring (0, placeHolder));
							placeHolder++;
							dialog = dialog.Substring (placeHolder);
							placeHolder = dialog.IndexOf ('\n');
							ChoiceButtons [count].GetComponent<ButtonStuff> ().Enemy3 = CharacterSetUp (dialog.Substring (0, placeHolder));
						} else {
							ChoiceButtons [count].GetComponent<ButtonStuff> ().Enemy2 = CharacterSetUp (dialog.Substring (0, placeHolder));
						}
					} else {
						ChoiceButtons [count].GetComponent<ButtonStuff> ().Enemy1 = CharacterSetUp (dialog.Substring (0, placeHolder));
					}
				} else {
					ChoiceButtons [count].GetComponent<ButtonStuff> ().link = dialog.Substring (0, placeHolder - 1);
				}
				ChoiceButtons [count].GetComponent<ButtonStuff> ().addScriptListener ();
				placeHolder++;
				dialog = dialog.Substring (placeHolder);
				placeHolder = 0;
				count++;
				placeHolder = 0;
			}
		}
	}

	//sets active the dialog portions of the UI
	void DialogSetUp(bool setactive) {
		DialogBoxBackground.SetActive (setactive);
		DialogBoxBackgroundUpper.SetActive (setactive);
		DialogText.SetActive (setactive);
		DialogText.GetComponent<TextScroll> ().enabled = setactive;
		Person1.SetActive (setactive);
		Person2.SetActive (setactive);
		Name.SetActive (setactive);
		Play = !setactive;
	}

	//
	public  Character CharacterSetUp(string file) {
		string text = ((TextAsset)Resources.Load (file.Trim())).text;
		text = text.Substring (text.IndexOf(':') + 1);
		string name = text.Substring(0, text.IndexOf('\n'));
		text = text.Substring (text.IndexOf(':') + 1);
		int health = int.Parse(text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		int mana = int.Parse(text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		int speed = int.Parse(text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		int element = int.Parse(text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		Sprite sprite = Resources.Load<Sprite>(text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		ArrayList skills = abilitySperator (text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		ArrayList magic = abilitySperator (text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		ArrayList items = abilitySperator (text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		ArrayList specials = abilitySperator (text.Substring(0, text.IndexOf('\n')));
		text = text.Substring (text.IndexOf(':') + 1);
		string AI = text.Substring(0, text.IndexOf('\n'));
		return new Character (name, health, mana, speed, element, sprite, skills, magic, items, specials, AI);
	}

	//
	private ArrayList abilitySperator(string abilities) {
		string[] array;
		if (!abilities.Trim().Equals ("")) {
			array = abilities.Split (',');
			ArrayList abs = new ArrayList ();
			for (int i = 0; i < array.Length; i++) {
				if (abilities.Contains (".")) {
					int PH = array [i].IndexOf ('.');
					Item Ab = (Item) Abilities [array [i].Substring (0, PH)];
					Item New = new Item (Ab.Name, int.Parse(array [i].Substring (PH + 1)), Ab.Damage, Ab.Speed, Ab.Element, Ab.Trigger, Ab.Sprite, Ab.Sound);
					abs.Add (New);
				} else {
					BattleOption New = Abilities [array [i].Trim ()];
					try{
						Magic NewNew = (Magic)New;
						abs.Add (new Magic(New.Name, NewNew.Cost, New.Damage, New.Speed, New.Element, New.Trigger, New.Sprite, New.Sound));
					} catch(System.Exception e) {
						abs.Add (new Skill(New.Name, New.Damage, New.Speed, New.Element, New.Trigger, New.Sprite, New.Sound));
					}
				}

			}
			return abs;
		}
		return new ArrayList ();
	}

	//sets the characters starting position to the correct position when level is loaded
	void OnLevelWasLoaded (int level) {
		makeSpacesMovable ();
		string first = "";
		string second = "";
		if (GameManager.startPoint.Substring (0, 1).Equals ("-")) {
			first = GameManager.startPoint.Substring (0, 2);
		} else {
			first = GameManager.startPoint.Substring (0, 1);
		}
		if (GameManager.startPoint.Substring (2, 1).Equals ("-")) {
			second = GameManager.startPoint.Substring (2, 2);
		} else {
			second = GameManager.startPoint.Substring (2, 1);
		}
		GameObject.Find ("MainCharacter").transform.position = new Vector2 (int.Parse (first) * 5, (int.Parse (second) * 5) - 1);
	}
}
