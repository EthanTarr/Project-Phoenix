using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
	private GameObject Battle;
	private GameObject Background;
	private GameObject Options;
	private GameObject Player1Image;
	private GameObject Player2Image;
	private GameObject Player3Image;
	private GameObject Enemy1Image;
	private GameObject Enemy2Image;
	private GameObject Enemy3Image;
	private GameObject Player1Panel;
	private GameObject Player2Panel;
	private GameObject Player3Panel;
	private GameObject Player1Name;
	private GameObject Player2Name;
	private GameObject Player3Name;
	private GameObject Player1Percentage;
	private GameObject Player2Percentage;
	private GameObject Player3Percentage;
	private GameObject Player1Health;
	private GameObject Player2Health;
	private GameObject Player3Health;
	private GameObject Player1Magic;
	private GameObject Player2Magic;
	private GameObject Player3Magic;
	private GameObject ButtonPanel;
	private GameObject SkillButton;
	private GameObject MagicButton;
	private GameObject ItemButton;
	private GameObject SpecialButton;
	private GameObject Player1SkillsPanel;
	private GameObject Player2SkillsPanel;
	private GameObject Player3SkillsPanel;
	private GameObject P1SkillContent;
	private GameObject P2SkillContent;
	private GameObject P3SkillContent;
	private GameObject P1Skill;
	private GameObject P2Skill;
	private GameObject P3Skill;
	private GameObject Player1MagicPanel;
	private GameObject Player2MagicPanel;
	private GameObject Player3MagicPanel;
	private GameObject P1MagicContent;
	private GameObject P2MagicContent;
	private GameObject P3MagicContent;
	private GameObject P1Magic;
	private GameObject P2Magic;
	private GameObject P3Magic;
	private GameObject Player1ItemPanel;
	private GameObject Player2ItemPanel;
	private GameObject Player3ItemPanel;
	private GameObject P1ItemContent;
	private GameObject P2ItemContent;
	private GameObject P3ItemContent;
	private GameObject P1Item;
	private GameObject P2Item;
	private GameObject P3Item;
	private GameObject Player1SpecialPanel;
	private GameObject Player2SpecialPanel;
	private GameObject Player3SpecialPanel;
	private GameObject P1SpecialContent;
	private GameObject P2SpecialContent;
	private GameObject P3SpecialContent;
	private GameObject P1Special;
	private GameObject P2Special;
	private GameObject P3Special;
	private GameObject Enemy1Pointer;
	private GameObject Enemy2Pointer;
	private GameObject Enemy3Pointer;
	private GameObject Player1Pointer;
	private GameObject Player2Pointer;
	private GameObject Player3Pointer;
	private GameObject Fighter;
	private GameObject EnemyFighter;
	private GameObject P1DamageText;
	private GameObject P2DamageText;
	private GameObject P3DamageText;
	private GameObject E1DamageText;
	private GameObject E2DamageText;
	private GameObject E3DamageText;
	private GameObject Fade;
	private GameObject AttackAnimation;
	private GameObject ActualAnimation;
	private GameObject PuppetAnimation;
	private Queue BattleOrder;
	private Queue EnemyBattleOrder;
	private Character Player1;
	private Character Player2;
	private Character Player3;
	private Character Enemy1;
	private Character Enemy2;
	private Character Enemy3;
	private Sprite WaterButton;
	private Sprite FireButton;
	private Sprite LightningButton;
	private Sprite AirButton;
	private Sprite EarthButton;
	private Sprite EtherealButton;
	private Sprite ForceButton;
	private Sprite BlankButton;
	private int Player1Count = 0;
	private int Player2Count = 0;
	private int Player3Count = 0;
	private int Enemy1Percentage = 0;
	private int Enemy2Percentage = 0;
	private int Enemy3Percentage = 0;
	private int Enemy1Count = 0;
	private int Enemy2Count = 0;
	private int Enemy3Count = 0;
	private bool Wait = false;
	private bool EnemyWait = false;
	private bool HoldLoad = false;
	private bool P1Queued = false;
	private bool P2Queued = false;
	private bool P3Queued = false;
	private bool E1Queued = false;
	private bool E2Queued = false;
	private bool E3Queued = false;
	private BattleOption LoadedOption;
	public int Player1Pace = 5;
	public int Player2Pace = 5;
	public int Player3Pace = 5;
	public int Enemy1Pace = 5;
	public int Enemy2Pace = 5;
	public int Enemy3Pace = 5;
	public float Enemy1CounterChance = 1f;
	public float Enemy2CounterChance = 1f;
	public float Enemy3CounterChance = 1f;
	public string victim;

	// Use this for initialization
	void Awake () {
		Battle = GameObject.Find ("Battle");
		Background = GameObject.Find ("Background");
		Options = GameObject.Find ("Options");
		Player1Image = GameObject.Find ("Player1Image");
		Player2Image = GameObject.Find ("Player2Image");
		Player3Image = GameObject.Find ("Player3Image");
		Enemy1Image = GameObject.Find ("Enemy1Image");
		Enemy2Image = GameObject.Find ("Enemy2Image");
		Enemy3Image = GameObject.Find ("Enemy3Image");
		Player1Panel = GameObject.Find ("Player1Panel");
		Player2Panel = GameObject.Find ("Player2Panel");
		Player3Panel = GameObject.Find ("Player3Panel");
		Player1Name = GameObject.Find ("Player1Name");
		Player2Name = GameObject.Find ("Player2Name");
		Player3Name = GameObject.Find ("Player3Name");
		Player1Percentage = GameObject.Find ("Player1Percentage");
		Player2Percentage = GameObject.Find ("Player2Percentage");
		Player3Percentage = GameObject.Find ("Player3Percentage");
		Player1Health = GameObject.Find ("Player1Health");
		Player2Health = GameObject.Find ("Player2Health");
		Player3Health = GameObject.Find ("Player3Health");
		Player1Magic = GameObject.Find ("Player1Magic");
		Player2Magic = GameObject.Find ("Player2Magic");
		Player3Magic = GameObject.Find ("Player3Magic");
		ButtonPanel = GameObject.Find ("ButtonPanel");
		SkillButton = GameObject.Find ("SkillButton");
		MagicButton = GameObject.Find ("MagicButton");
		ItemButton = GameObject.Find ("ItemButton");
		SpecialButton = GameObject.Find ("SpecialButton");
		Player1SkillsPanel = GameObject.Find ("Player1SkillsPanel");
		Player2SkillsPanel = GameObject.Find ("Player2SkillsPanel");
		Player3SkillsPanel = GameObject.Find ("Player3SkillsPanel");
		P1SkillContent = GameObject.Find ("P1SkillContent");
		P2SkillContent = GameObject.Find ("P2SkillContent");
		P3SkillContent = GameObject.Find ("P3SkillContent");
		P1Skill = GameObject.Find ("P1Skill");
		P2Skill = GameObject.Find ("P2Skill");
		P3Skill = GameObject.Find ("P3Skill");
		Player1MagicPanel = GameObject.Find ("Player1MagicPanel");
		Player2MagicPanel = GameObject.Find ("Player2MagicPanel");
		Player3MagicPanel = GameObject.Find ("Player3MagicPanel");
		P1MagicContent = GameObject.Find ("P1MagicContent");
		P2MagicContent = GameObject.Find ("P2MagicContent");
		P3MagicContent = GameObject.Find ("P3MagicContent");
		P1Magic = GameObject.Find ("P1Magic");
		P2Magic = GameObject.Find ("P2Magic");
		P3Magic = GameObject.Find ("P3Magic");
		Player1ItemPanel = GameObject.Find ("Player1ItemPanel");
		Player2ItemPanel = GameObject.Find ("Player2ItemPanel");
		Player3ItemPanel = GameObject.Find ("Player3ItemPanel");
		P1ItemContent = GameObject.Find ("P1ItemContent");
		P2ItemContent = GameObject.Find ("P2ItemContent");
		P3ItemContent = GameObject.Find ("P3ItemContent");
		P1Item = GameObject.Find ("P1Item");
		P2Item = GameObject.Find ("P2Item");
		P3Item = GameObject.Find ("P3Item");
		Player1SpecialPanel = GameObject.Find ("Player1SpecialPanel");
		Player2SpecialPanel = GameObject.Find ("Player2SpecialPanel");
		Player3SpecialPanel = GameObject.Find ("Player3SpecialPanel");
		P1SpecialContent = GameObject.Find ("P1SpecialContent");
		P2SpecialContent = GameObject.Find ("P2SpecialContent");
		P3SpecialContent = GameObject.Find ("P3SpecialContent");
		P1Special = GameObject.Find ("P1Special");
		P2Special = GameObject.Find ("P2Special");
		P3Special = GameObject.Find ("P3Special");
		Enemy1Pointer = GameObject.Find ("Enemy1Pointer");
		Enemy2Pointer = GameObject.Find ("Enemy2Pointer");
		Enemy3Pointer = GameObject.Find ("Enemy3Pointer");
		Player1Pointer = GameObject.Find ("Player1Pointer");
		Player2Pointer = GameObject.Find ("Player2Pointer");
		Player3Pointer = GameObject.Find ("Player3Pointer");
		P1DamageText = GameObject.Find ("P1DamageText");
		P2DamageText = GameObject.Find ("P2DamageText");
		P3DamageText = GameObject.Find ("P3DamageText");
		E1DamageText = GameObject.Find ("E1DamageText");
		E2DamageText = GameObject.Find ("E2DamageText");
		E3DamageText = GameObject.Find ("E3DamageText");
		Fade = GameObject.Find ("Fade");
		AttackAnimation = GameObject.Find ("AttackAnimation");
		ActualAnimation = GameObject.Find ("ActualAnimation");
		PuppetAnimation = GameObject.Find ("PuppetImage");
		WaterButton = Resources.Load<Sprite> ("Water Button");
		FireButton = Resources.Load<Sprite> ("Fire Button");
		LightningButton = Resources.Load<Sprite> ("Lightning Button");
		EarthButton = Resources.Load<Sprite> ("Earth Button");
		AirButton = Resources.Load<Sprite> ("Air Button");
		EtherealButton = Resources.Load<Sprite> ("Ethereal Button");
		ForceButton = Resources.Load<Sprite> ("Force Button");
		BlankButton = Resources.Load<Sprite> ("Blank Button");
		P1DamageText.SetActive (false);
		P2DamageText.SetActive (false);
		P3DamageText.SetActive (false);
		E1DamageText.SetActive (false);
		E2DamageText.SetActive (false);
		E3DamageText.SetActive (false);
		Enemy1Pointer.SetActive (false);
		Enemy2Pointer.SetActive (false);
		Enemy3Pointer.SetActive (false);
		Player1Pointer.SetActive (false);
		Player2Pointer.SetActive (false);
		Player3Pointer.SetActive (false);
		P1Skill.SetActive (false);
		P2Skill.SetActive (false);
		P3Skill.SetActive (false);
		Player1SkillsPanel.SetActive (false);
		Player2SkillsPanel.SetActive (false);
		Player3SkillsPanel.SetActive (false);
		P1Magic.SetActive (false);
		P2Magic.SetActive (false);
		P3Magic.SetActive (false);
		Player1MagicPanel.SetActive (false);
		Player2MagicPanel.SetActive (false);
		Player3MagicPanel.SetActive (false);
		P1Item.SetActive (false);
		P2Item.SetActive (false);
		P3Item.SetActive (false);
		Player1ItemPanel.SetActive (false);
		Player2ItemPanel.SetActive (false);
		Player3ItemPanel.SetActive (false);
		P1Special.SetActive (false);
		P2Special.SetActive (false);
		P3Special.SetActive (false);
		Player1SpecialPanel.SetActive (false);
		Player2SpecialPanel.SetActive (false);
		Player3SpecialPanel.SetActive (false);
		ButtonPanel.SetActive (false);
		ActualAnimation.SetActive (false);
		Enemy1Image.GetComponent<Button> ().enabled = false;
		Enemy2Image.GetComponent<Button> ().enabled = false;
		Enemy3Image.GetComponent<Button> ().enabled = false;
		Player1Image.GetComponent<Button> ().enabled = false;
		Player2Image.GetComponent<Button> ().enabled = false;
		Player3Image.GetComponent<Button> ().enabled = false;
		BattleOrder = new Queue ();
		EnemyBattleOrder = new Queue ();
		Battle.SetActive (false);
		this.gameObject.GetComponent<BattleManager> ().enabled = false;
	}

	void Start() {
		Battle.SetActive (true);
		this.gameObject.GetComponent<AudioManager> ().stopBackground ();
		StartCoroutine (WaitBackground (1));
		this.gameObject.GetComponent<AudioManager> ().playBattleSound (6, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (!HoldLoad) {

			//Player 1 turn loader
			if (Player1Panel.activeSelf) {
				Player1Count++;

				if (Player1Count >= Player1Pace) {
					Player1Count = 0;

					if (int.Parse (Player1Percentage.GetComponent<Text> ().text.Substring (0, 3)) >= 100) {
						if (!P1Queued) {
							P1Queued = true;
							BattleOrder.Enqueue (Player1Image);
						}
					} else if (int.Parse (Player1Percentage.GetComponent<Text> ().text.Substring (0, 3)) < 9) {
						Player1Percentage.GetComponent<Text> ().text = "00" + (int.Parse (Player1Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					} else if (int.Parse (Player1Percentage.GetComponent<Text> ().text.Substring (0, 3)) < 99) {
						Player1Percentage.GetComponent<Text> ().text = "0" + (int.Parse (Player1Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					} else {
						Player1Percentage.GetComponent<Text> ().text = (int.Parse (Player1Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					}
				}
			}

			//Player 2 turn loader
			if (Player2Panel.activeSelf) {
				Player2Count++;

				if (Player2Count >= Player2Pace) {
					Player2Count = 0;

					if (int.Parse (Player2Percentage.GetComponent<Text> ().text.Substring (0, 3)) >= 100) {
						if (!P2Queued) {
							P2Queued = true;
							BattleOrder.Enqueue (Player2Image);
						}
					} else if (int.Parse (Player2Percentage.GetComponent<Text> ().text.Substring (0, 3)) < 9) {
						Player2Percentage.GetComponent<Text> ().text = "00" + (int.Parse (Player2Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					} else if (int.Parse (Player2Percentage.GetComponent<Text> ().text.Substring (0, 3)) < 99) {
						Player2Percentage.GetComponent<Text> ().text = "0" + (int.Parse (Player2Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					} else {
						Player2Percentage.GetComponent<Text> ().text = (int.Parse (Player2Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					}
				}
			}

			//Player 3 turn loader
			if (Player3Panel.activeSelf) {
				Player3Count++;

				if (Player3Count >= Player3Pace) {
					Player3Count = 0;

					if (int.Parse (Player3Percentage.GetComponent<Text> ().text.Substring (0, 3)) >= 100) {
						if (!P3Queued) {
							P3Queued = true;
							BattleOrder.Enqueue (Player3Image);
						}
					} else if (int.Parse (Player3Percentage.GetComponent<Text> ().text.Substring (0, 3)) < 9) {
						Player3Percentage.GetComponent<Text> ().text = "00" + (int.Parse (Player3Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					} else if (int.Parse (Player3Percentage.GetComponent<Text> ().text.Substring (0, 3)) < 99) {
						Player3Percentage.GetComponent<Text> ().text = "0" + (int.Parse (Player3Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					} else {
						Player3Percentage.GetComponent<Text> ().text = (int.Parse (Player3Percentage.GetComponent<Text> ().text.Substring (0, 3)) + 1) + "%";
					}
				}
			}

			//Enemy 1 turn loader
			if (Enemy1Image.activeSelf) {
				if (Random.value <= Enemy1CounterChance) {
					Enemy1Count++;
				}

				if (Enemy1Count >= Enemy1Pace) {
					Enemy1Count = 0;

					if (Enemy1Percentage == 100) {
						if (!E1Queued) {
							
							E1Queued = true;
							EnemyBattleOrder.Enqueue (Enemy1Image);
							Debug.Log (EnemyBattleOrder.Count);
						}
					} else {
						Enemy1Percentage++;
					}
				}
			}

			//Enemy 2 turn loader
			if (Enemy2Image.activeSelf) {
				if (Random.value <= Enemy2CounterChance) {
					Enemy2Count++;
				}

				if (Enemy2Count >= Enemy2Pace) {
					Enemy2Count = 0;
					if (Enemy2Percentage == 100) {
						if (!E2Queued) {
							Debug.Log ("Enemy2");
							E2Queued = true;
							EnemyBattleOrder.Enqueue (Enemy2Image);
						}
					} else {
						Enemy2Percentage++;
					}
				}
			}

			//Enemy 3 turn loader
			if (Enemy3Image.activeSelf) {
				if (Random.value <= Enemy3CounterChance) {
					Enemy3Count++;
				}

				if (Enemy3Count >= Enemy3Pace) {
					Enemy3Count = 0;

					if (Enemy3Percentage == 100) {
						if (!E3Queued) {
							Debug.Log ("Enemy3");
							E3Queued = true;
							EnemyBattleOrder.Enqueue (Enemy3Image);
						}
					} else {
						Enemy3Percentage++;
					}
				}
			}

		}

		if (EnemyBattleOrder.Count != 0 && !EnemyWait) {
			EnemyWait = true;
			EnemyFighter = (GameObject) EnemyBattleOrder.Dequeue();
			HoldLoad = true;
			ButtonPanel.SetActive (false);
			Player1SkillsPanel.SetActive (false);
			Player2SkillsPanel.SetActive (false);
			Player3SkillsPanel.SetActive (false);
			Player1MagicPanel.SetActive (false);
			Player2MagicPanel.SetActive (false);
			Player3MagicPanel.SetActive (false);
			Player1ItemPanel.SetActive (false);
			Player2ItemPanel.SetActive (false);
			Player3ItemPanel.SetActive (false);
			Player1SpecialPanel.SetActive (false);
			Player2SpecialPanel.SetActive (false);
			Player3SpecialPanel.SetActive (false);
			Enemy1Pointer.SetActive (false);
			Enemy1Image.GetComponent<Button> ().enabled = false;
			Enemy2Pointer.SetActive (false);
			Enemy2Image.GetComponent<Button> ().enabled = false;
			Enemy3Pointer.SetActive (false);
			Enemy3Image.GetComponent<Button> ().enabled = false;
			Player1Pointer.SetActive (false);
			Player1Image.GetComponent<Button> ().enabled = false;
			Player2Pointer.SetActive (false);
			Player2Image.GetComponent<Button> ().enabled = false;
			Player3Pointer.SetActive (false);
			Player3Image.GetComponent<Button> ().enabled = false;
			StartCoroutine (Waitting (1.5f));
		}

		//Activates a turn for whoever is next in the battle queue
		if (BattleOrder.Count != 0 && !Wait) {
			Wait = true;
			Fighter = (GameObject) BattleOrder.Dequeue ();
			while (!Fighter.activeSelf) {
				Fighter = (GameObject) BattleOrder.Dequeue (); 
			}
			if (Fighter.name.Substring (0, 1).Equals ("P")) { // if it is the player's turn
				ButtonPanel.SetActive (true);
				if (Fighter.name.Substring (6, 1).Equals ("1")) {
					Color temp = Player1Panel.GetComponent<Image> ().color;
					temp.a = 1;
					Player1Panel.GetComponent<Image> ().color = temp;
				} else if (Fighter.name.Substring (6, 1).Equals ("2")) {
					Color temp = Player2Panel.GetComponent<Image> ().color;
					temp.a = 1;
					Player2Panel.GetComponent<Image> ().color = temp;
				} else {
					Color temp = Player3Panel.GetComponent<Image> ().color;
					temp.a = 1;
					Player3Panel.GetComponent<Image> ().color = temp;
				}
			} /*else { // if it is the Enemy's turn
				HoldLoad = true;
				StartCoroutine (Waitting (1.5f));
			}*/
		}
	}

	//
	private void EnemyTurn() {
		int min = 2;
		int max = 2;
		if (Player1Panel.activeSelf) {
			min = 1;
		} 
		if (Player3Panel.activeSelf) {
			max = 3;
		}
		victim = "P" + Random.Range (min, max);
		BattleOption use;
		if (EnemyFighter.name.Substring (5, 1).Equals ("1")) {
			Enemy1Percentage = 0;
			E1Queued = false;
			Enemy1Image.GetComponent<Animator> ().SetTrigger ("Attack");
			use = EnemyAI (Enemy1);
			if (victim.Equals ("self")) {
				Enemy1.Health += use.Damage;
				setDamageAnimation (E1DamageText, use.Damage);
				if (!use.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Enemy1Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = use.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (use.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
			}
		} else if (EnemyFighter.name.Substring (5, 1).Equals ("2")) {
			Enemy2Percentage = 0;
			E2Queued = false;
			Enemy2Image.GetComponent<Animator> ().SetTrigger ("Attack");
			use = EnemyAI (Enemy2);
			if (victim.Equals ("self")) {
				Enemy2.Health += use.Damage;
				setDamageAnimation (E2DamageText, use.Damage);
				if (!use.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Enemy2Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = use.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (use.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
			}
		} else {
			Debug.Log (EnemyFighter.name);
			Enemy3Percentage = 0;
			E3Queued = false;
			Enemy3Image.GetComponent<Animator> ().SetTrigger ("Attack");
			use = EnemyAI (Enemy3);
			if (victim.Equals ("self")) {
				Enemy3.Health += use.Damage;
				setDamageAnimation (E3DamageText, use.Damage);
				if (!use.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Enemy3Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = use.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (use.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
			}
		}
		Debug.Log (use.Name);
		if (use.Sound != null) {
			this.gameObject.GetComponent<AudioManager> ().playSound (use.Sound, 0);
		} else {
			this.gameObject.GetComponent<AudioManager> ().playBattleSound (Random.Range (0, 1), Random.value);
		}
		if (!victim.Equals ("self")) {
			if (victim.Equals ("P1")) {
				Player1Health.GetComponent<Text> ().text = (int.Parse (Player1Health.GetComponent<Text> ().text.Substring (0, Player1Health.GetComponentInChildren<Text> ().text.IndexOf (" "))) - use.Damage) + " HP";
				setDamageAnimation (P1DamageText, use.Damage);
				if (!use.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Player1Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = use.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (use.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (int.Parse (Player1Health.GetComponent<Text> ().text.Substring (0, Player1Health.GetComponentInChildren<Text> ().text.IndexOf (" "))) <= 0) {
					Player1Image.SetActive (false);
					this.gameObject.GetComponent<AudioManager> ().playBattleSound (4, 0);
				}
			} else if (victim.Equals ("P2")) {
				Player2Health.GetComponent<Text> ().text = (int.Parse (Player2Health.GetComponent<Text> ().text.Substring (0, Player2Health.GetComponentInChildren<Text> ().text.IndexOf (" "))) - use.Damage) + " HP";
				setDamageAnimation (P2DamageText, use.Damage);
				if (!use.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Player2Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = use.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (use.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (int.Parse (Player2Health.GetComponent<Text> ().text.Substring (0, Player2Health.GetComponentInChildren<Text> ().text.IndexOf (" "))) <= 0) {
					Player2Image.SetActive (false);
					this.gameObject.GetComponent<AudioManager> ().playBattleSound (4, 0);
				}
			} else {
				Player3Health.GetComponent<Text> ().text = (int.Parse (Player3Health.GetComponent<Text> ().text.Substring (0, Player3Health.GetComponentInChildren<Text> ().text.IndexOf (" "))) - use.Damage) + " HP";
				setDamageAnimation (P3DamageText, use.Damage);
				if (!use.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Player3Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = use.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (use.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (int.Parse (Player3Health.GetComponent<Text> ().text.Substring (0, Player3Health.GetComponentInChildren<Text> ().text.IndexOf (" "))) <= 0) {
					Player3Image.SetActive (false);
					this.gameObject.GetComponent<AudioManager> ().playBattleSound (4, 0);
				}
			}
		}
		checkDefeat ();
		EnemyWait = false;
		HoldLoad = false;
		ButtonPanel.SetActive (true);
	}

	//
	private BattleOption EnemyAI(Character enemy) {
		Enemy temp = GameObject.Find ("EnemyManager").GetComponent (enemy.AI.Trim()) as Enemy;
		return temp.EnemyAI (enemy);
	}

	//IEnumerator for waiting the given amount of time
	IEnumerator WaitBackground(float time) {
		yield return new WaitForSeconds (time);
		this.gameObject.GetComponent<AudioManager> ().playBackground (0);
	}

	//IEnumerator for waiting the given amount of time
	IEnumerator Waitting(float time) {
		yield return new WaitForSeconds (time);
		EnemyTurn ();
	}

	//IEnumerator for waiting the given amount of time
	IEnumerator WaitForAnimation() {
		yield return new WaitForSeconds (1.5f);
		placeHolder ();
	}

	//Takes up space in order to wait for seconds
	void placeHolder() {

	}

	//Activated the standard UI mode
	void ActivateStandardMode() {
		this.gameObject.GetComponent<GameManager> ().enabled = true;
		Battle.SetActive (false);
		this.gameObject.GetComponent<BattleManager> ().enabled = false;
	}

	//sets up the initial battle information for the player characters
	public void SetUpBattle(Character player2, Character player1, Character player3, Character enemy2, Character enemy1, Character enemy3) {

		ArrayList Skilles;
		ArrayList Magic;
		ArrayList Items;
		ArrayList Specials;
		int heighty;
		RectTransform rect;
		int counter;

		//player1 information set
		if (player1.Name != null) {
			Player1Name.GetComponent<Text> ().text = player1.Name;
			if (player1.Speed == 100) {
				Player1Percentage.GetComponent<Text> ().text = player1.Speed + "%";
			} else if (player1.Speed > 9) {
				Player1Percentage.GetComponent<Text> ().text = "0" + player1.Speed + "%";
			} else {
				Player1Percentage.GetComponent<Text> ().text = "00" + player1.Speed + "%";
			}
			Player1Health.GetComponent<Text> ().text = player1.Health + " HP";
			Player1Magic.GetComponent<Text> ().text = player1.MagicPoints + " MP";
			UpdateCharacterElementIcon (Player1Panel, player1);
			this.Player1 = player1;

			//gets and organizes players skills
			Skilles = player1.getSkills ();
			heighty = 5 + (Skilles.Count * 35);
			rect = P1SkillContent.GetComponent<RectTransform> ();
			rect.sizeDelta = new Vector2 (0, heighty);
			counter = 0;
			foreach (Skill skill in Skilles) {
				counter++;
				GameObject temp = (GameObject) Instantiate (P1Skill, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
				temp.transform.SetParent (P1SkillContent.transform, false);
				temp.GetComponentInChildren<Text> ().text = skill.Name;
				temp.name = "P1" + skill.Name;
				UpdateElementalIcon (temp, skill);
				temp.SetActive (true);
			}

			//gets and organizes players magic
			Magic = player1.getMagics ();
			heighty = 5 + (Magic.Count * 35);
			rect = P1MagicContent.GetComponent<RectTransform> ();
			rect.sizeDelta = new Vector2 (0, heighty);
			counter = 0;
			foreach (Magic magic in Magic) {
				counter++;
				GameObject temp = (GameObject) Instantiate (P1Magic, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
				temp.transform.SetParent (P1MagicContent.transform, false);
				temp.GetComponentInChildren<Text> ().text = magic.Name + " - " + magic.Cost;
				temp.name = "P1" + magic.Name;
				UpdateElementalIcon (temp, magic);
				temp.SetActive (true);
			}

			//gets and organizes players items
			Items = player1.getItems ();
			heighty = 5 + (Items.Count * 35);
			rect = P1ItemContent.GetComponent<RectTransform> ();
			rect.sizeDelta = new Vector2 (0, heighty);
			counter = 0;
			foreach (Item item in Items) {
				counter++;
				GameObject temp = (GameObject) Instantiate (P1Item, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
				temp.transform.SetParent (P1ItemContent.transform, false);
				temp.GetComponentInChildren<Text> ().text = item.Name + " - " + item.Quantity;
				temp.name = "P1" + item.Name;
				UpdateElementalIcon (temp, item);
				temp.SetActive (true);
			}

			//gets and organizes players specials
			Specials = player1.getSpecials ();
			heighty = 5 + (Specials.Count * 35);
			rect = P1SpecialContent.GetComponent<RectTransform> ();
			rect.sizeDelta = new Vector2 (0, heighty);
			counter = 0;
			foreach (Special special in Specials) {
				counter++;
				GameObject temp = (GameObject) Instantiate (P1Special, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
				temp.transform.SetParent (P1SpecialContent.transform, false);
				temp.GetComponentInChildren<Text> ().text = special.Name;
				temp.name = "P1" + special.Name;
				UpdateElementalIcon (temp, special);
				temp.SetActive (true);
			}
		} else {
			Player1Panel.SetActive (false);
			Player1Image.SetActive (false);
		}
		this.Player1 = player1;

		//player2 information set
		Player2Name.GetComponent<Text>().text = player2.Name;
		if (player2.Speed == 100) {
			Player2Percentage.GetComponent<Text> ().text = player2.Speed + "%";
		} else if (player2.Speed > 9) {
			Player2Percentage.GetComponent<Text> ().text = "0" + player2.Speed + "%";
		} else {
			Player2Percentage.GetComponent<Text> ().text = "00" + player2.Speed + "%";
		}
		Player2Health.GetComponent<Text> ().text = player2.Health + " HP";
		Player2Magic.GetComponent<Text> ().text = player2.MagicPoints + " MP";
		UpdateCharacterElementIcon (Player2Panel, player2);
		this.Player2 = player2;

		//gets and organizes players skills
		Skilles = player2.getSkills ();
		heighty = 5 + (Skilles.Count * 35);
		rect = P2SkillContent.GetComponent<RectTransform> ();
		rect.sizeDelta = new Vector2 (0, heighty);
		counter = 0;
		foreach (Skill skill in Skilles) {
			counter++;
			GameObject temp = (GameObject) Instantiate (P2Skill, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
			temp.transform.SetParent (P2SkillContent.transform, false);
			temp.GetComponentInChildren<Text> ().text = skill.Name;
			temp.name = "P2" + skill.Name;
			UpdateElementalIcon (temp, skill);
			temp.SetActive (true);
		}

		//gets and organizes players magic
		Magic = player2.getMagics ();
		heighty = 5 + (Magic.Count * 35);
		rect = P2MagicContent.GetComponent<RectTransform> ();
		rect.sizeDelta = new Vector2 (0, heighty);
		counter = 0;
		foreach (Magic magic in Magic) {
			counter++;
			GameObject temp = (GameObject) Instantiate (P2Magic, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
			temp.transform.SetParent (P2MagicContent.transform, false);
			temp.GetComponentInChildren<Text> ().text = magic.Name + " - " + magic.Cost;
			temp.name = "P2" + magic.Name;
			UpdateElementalIcon (temp, magic);
			temp.SetActive (true);
		}

		//gets and organizes players items
		Items = player2.getItems ();
		heighty = 5 + (Items.Count * 35);
		rect = P2ItemContent.GetComponent<RectTransform> ();
		rect.sizeDelta = new Vector2 (0, heighty);
		counter = 0;
		foreach (Item item in Items) {
			counter++;
			GameObject temp = (GameObject) Instantiate (P2Item, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
			temp.transform.SetParent (P2ItemContent.transform, false);
			temp.GetComponentInChildren<Text> ().text = item.Name + " - " + item.Quantity;
			temp.name = "P2" + item.Name;
			UpdateElementalIcon (temp, item);
			temp.SetActive (true);
		}

		//gets and organizes players specials
		Specials = player2.getSpecials ();
		heighty = 5 + (Specials.Count * 35);
		rect = P2SpecialContent.GetComponent<RectTransform> ();
		rect.sizeDelta = new Vector2 (0, heighty);
		counter = 0;
		foreach (Special special in Specials) {
			counter++;
			GameObject temp = (GameObject) Instantiate (P2Special, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
			temp.transform.SetParent (P2SpecialContent.transform, false);
			temp.GetComponentInChildren<Text> ().text = special.Name;
			temp.name = "P2" + special.Name;
			UpdateElementalIcon (temp, special);
			temp.SetActive (true);
		}
		this.Player2 = player2;

		//player3 information set
		if (player3.Name != null) {
			Player3Name.GetComponent<Text>().text = player3.Name;
			if (player3.Speed == 100) {
				Player3Percentage.GetComponent<Text> ().text = player3.Speed + "%";
			} else if (player3.Speed > 9) {
				Player3Percentage.GetComponent<Text> ().text = "0" + player3.Speed + "%";
			} else {
				Player3Percentage.GetComponent<Text> ().text = "00" + player3.Speed + "%";
			}
			Player3Health.GetComponent<Text> ().text = player3.Health + " HP";
			Player3Magic.GetComponent<Text> ().text = player3.MagicPoints + " MP";
			UpdateCharacterElementIcon (Player3Panel, player3);
			this.Player3 = player3;

			//gets and organizes players skills
			Skilles = player3.getSkills ();
			heighty = 5 + (Skilles.Count * 35);
			rect = P3SkillContent.GetComponent<RectTransform> ();
			rect.sizeDelta = new Vector2 (0, heighty);
			counter = 0;
			foreach (Skill skill in Skilles) {
				counter++;
				GameObject temp = (GameObject) Instantiate (P3Skill, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
				temp.transform.SetParent (P3SkillContent.transform, false);
				temp.GetComponentInChildren<Text> ().text = skill.Name;
				temp.name = "P3" + skill.Name;
				UpdateElementalIcon (temp, skill);
				temp.SetActive (true);
			}

			//gets and organizes players magic
			Magic = player3.getMagics ();
			heighty = 5 + (Magic.Count * 35);
			rect = P3MagicContent.GetComponent<RectTransform> ();
			rect.sizeDelta = new Vector2 (0, heighty);
			counter = 0;
			foreach (Magic magic in Magic) {
				counter++;
				GameObject temp = (GameObject) Instantiate (P3Magic, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
				temp.transform.SetParent (P3MagicContent.transform, false);
				temp.GetComponentInChildren<Text> ().text = magic.Name + " - " + magic.Cost;
				temp.name = "P3" + magic.Name;
				UpdateElementalIcon (temp, magic);
				temp.SetActive (true);
			}

			//gets and organizes players items
			Items = player3.getItems ();
			heighty = 5 + (Items.Count * 35);
			rect = P3ItemContent.GetComponent<RectTransform> ();
			rect.sizeDelta = new Vector2 (0, heighty);
			counter = 0;
			foreach (Item item in Items) {
				counter++;
				GameObject temp = (GameObject) Instantiate (P3Item, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
				temp.transform.SetParent (P3ItemContent.transform, false);
				temp.GetComponentInChildren<Text> ().text = item.Name + " - " + item.Quantity;
				temp.name = "P3" + item.Name;
				UpdateElementalIcon (temp, item);
				temp.SetActive (true);
			}

			//gets and organizes players specials
			Specials = player3.getSpecials ();
			heighty = 5 + (Specials.Count * 35);
			rect = P3SpecialContent.GetComponent<RectTransform> ();
			rect.sizeDelta = new Vector2 (0, heighty);
			counter = 0;
			foreach (Special special in Specials) {
				counter++;
				GameObject temp = (GameObject) Instantiate (P3Special, new Vector3 (0, ((heighty / 2) + 15) - (counter * 35)), Quaternion.identity);
				temp.transform.SetParent (P3SpecialContent.transform, false);
				temp.GetComponentInChildren<Text> ().text = special.Name;
				temp.name = "P3" + special.Name;
				UpdateElementalIcon (temp, special);
				temp.SetActive (true);
			}
		} else {
			Player3Panel.SetActive (false);
			Player3Image.SetActive (false);
		}
		this.Player3 = player3;

		//enemy1 information set
		if (enemy1.Name != null) {
			Enemy1Percentage = enemy1.Speed;
			Enemy en1 = GameObject.Find ("EnemyManager").GetComponent (enemy1.AI.Trim()) as Enemy;
			Enemy1CounterChance = en1.getChance();
			Enemy1Pace = en1.getPace ();
		} else {
			Enemy1Image.SetActive (false);
		}
		this.Enemy1 = enemy1;

		//enemy2 information set
		Enemy2Percentage = enemy2.Speed;
		Enemy en2 = GameObject.Find ("EnemyManager").GetComponent (enemy2.AI.Trim()) as Enemy;
		Enemy2CounterChance = en2.getChance();
		Enemy2Pace = en2.getPace ();
		this.Enemy2 = enemy2;

		//enemy3 information set
		if (enemy3.Name != null) {
			Enemy3Percentage = enemy3.Speed;
			Enemy en3 = GameObject.Find ("EnemyManager").GetComponent (enemy3.AI.Trim()) as Enemy;
			Enemy3CounterChance = en3.getChance();
			Enemy3Pace = en3.getPace ();
		} else {
			Enemy3Image.SetActive (false);
		}
		this.Enemy3 = enemy3;
	}
		
	public void SetUpBattle(Character player2, Character player1, Character enemy2, Character enemy1, Character enemy3) {
		SetUpBattle (player2, player1, new Character(null, 0, 0, 0, 0), enemy2, enemy1, enemy3);
	}
		
	public void SetUpBattle(Character player2, Character enemy2, Character enemy1, Character enemy3) {
		SetUpBattle (player2, new Character(null, 0, 0, 0, 0), enemy2, enemy1, enemy3);
	}

	//Activates the Panels that contain the skills for the selected Player
	public void PullUpSkills() {
		Player1MagicPanel.SetActive (false);
		Player2MagicPanel.SetActive (false);
		Player3MagicPanel.SetActive (false);
		Player1ItemPanel.SetActive (false);
		Player2ItemPanel.SetActive (false);
		Player3ItemPanel.SetActive (false);
		Player1SpecialPanel.SetActive (false);
		Player2SpecialPanel.SetActive (false);
		Player3SpecialPanel.SetActive (false);
		if (Fighter.name.Substring (6, 1).Equals ("1")) {
			Player1SkillsPanel.SetActive (true);
		} else if (Fighter.name.Substring (6, 1).Equals ("2")) {
			Player2SkillsPanel.SetActive (true);
		} else {
			Player3SkillsPanel.SetActive (true);
		}
	}

	//Activates the Panels that contain the Magic for the selected Player
	public void PullUpMagic() {
		Player1SkillsPanel.SetActive (false);
		Player2SkillsPanel.SetActive (false);
		Player3SkillsPanel.SetActive (false);
		Player1ItemPanel.SetActive (false);
		Player2ItemPanel.SetActive (false);
		Player3ItemPanel.SetActive (false);
		Player1SpecialPanel.SetActive (false);
		Player2SpecialPanel.SetActive (false);
		Player3SpecialPanel.SetActive (false);
		if (Fighter.name.Substring (6, 1).Equals ("1")) {
			Player1MagicPanel.SetActive (true);
			foreach(Magic magic in Player1.getMagics()) {
				if (int.Parse (Player1Magic.GetComponent<Text> ().text.Substring (0, Player1Magic.GetComponent<Text> ().text.IndexOf (" "))) < magic.Cost) {
					GameObject button = GameObject.Find ("P1" + magic.Name);
					button.GetComponent<Button> ().enabled = false;
					button.GetComponentInChildren<Text> ().color = Color.gray;
				}
			}
		} else if (Fighter.name.Substring (6, 1).Equals ("2")) {
			Player2MagicPanel.SetActive (true);
			foreach(Magic magic in Player2.getMagics()) {
				if (int.Parse (Player2Magic.GetComponent<Text> ().text.Substring (0, Player2Magic.GetComponent<Text> ().text.IndexOf (" "))) < magic.Cost) {
					GameObject button = GameObject.Find ("P2" + magic.Name);
					button.GetComponent<Button> ().enabled = false;
					button.GetComponentInChildren<Text> ().color = Color.gray;
				}
			}
		} else {
			Player3MagicPanel.SetActive (true);
			foreach(Magic magic in Player3.getMagics()) {
				if (int.Parse (Player3Magic.GetComponent<Text> ().text.Substring (0, Player3Magic.GetComponent<Text> ().text.IndexOf (" "))) < magic.Cost) {
					GameObject button = GameObject.Find ("P3" + magic.Name);
					button.GetComponent<Button> ().enabled = false;
					button.GetComponentInChildren<Text> ().color = Color.gray;
				}
			}
		}
	}

	//Activates the Panels that contain the Items for the selected Player
	public void PullUpItems() {
		Player1SkillsPanel.SetActive (false);
		Player2SkillsPanel.SetActive (false);
		Player3SkillsPanel.SetActive (false);
		Player1MagicPanel.SetActive (false);
		Player2MagicPanel.SetActive (false);
		Player3MagicPanel.SetActive (false);
		Player1SpecialPanel.SetActive (false);
		Player2SpecialPanel.SetActive (false);
		Player3SpecialPanel.SetActive (false);
		if (Fighter.name.Substring (6, 1).Equals ("1")) {
			Player1ItemPanel.SetActive (true);
		} else if (Fighter.name.Substring (6, 1).Equals ("2")) {
			Player2ItemPanel.SetActive (true);
		} else {
			Player3ItemPanel.SetActive (true);
		}
	}

	//Activates the Panels that contain the Specials for the selected Player
	public void PullUpSpecials() {
		Player1SkillsPanel.SetActive (false);
		Player2SkillsPanel.SetActive (false);
		Player3SkillsPanel.SetActive (false);
		Player1MagicPanel.SetActive (false);
		Player2MagicPanel.SetActive (false);
		Player3MagicPanel.SetActive (false);
		Player1ItemPanel.SetActive (false);
		Player2ItemPanel.SetActive (false);
		Player3ItemPanel.SetActive (false);
		if (Fighter.name.Substring (6, 1).Equals ("1")) {
			Player1SpecialPanel.SetActive (true);
		} else if (Fighter.name.Substring (6, 1).Equals ("2")) {
			Player2SpecialPanel.SetActive (true);
		} else {
			Player3SpecialPanel.SetActive (true);
		}
	}

	//To be used by skill buttons to activate targets and determine the skill being used
	public void Skill(GameObject button) {
		TargetEnemy ();
		if (button.name.Substring (1, 1).Equals ("1")) {
			LoadedOption = Player1.getSkill (button.GetComponentInChildren<Text> ().text);
		} else if (button.name.Substring (1, 1).Equals ("2")) {
			LoadedOption = Player2.getSkill (button.GetComponentInChildren<Text> ().text);
		} else {
			LoadedOption = Player3.getSkill (button.GetComponentInChildren<Text> ().text);
		}
	}

	//To be used by magic buttons to activate targets and determine the magic being used
	public void Magic(GameObject button) {
		TargetEnemy ();
		if (button.name.Substring (1, 1).Equals ("1")) {
			LoadedOption = Player1.getMagic (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" ")));
			Player1Magic.GetComponent<Text>().text = (int.Parse(Player1Magic.GetComponent<Text>().text.Substring(0, Player1Magic.GetComponent<Text>().text.IndexOf(" "))) - Player1.getMagic (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" "))).Cost) + " MP";
		} else if (button.name.Substring (1, 1).Equals ("2")) {
			LoadedOption = Player2.getMagic (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" ")));
			Player2Magic.GetComponent<Text>().text = (int.Parse(Player2Magic.GetComponent<Text>().text.Substring(0, Player2Magic.GetComponent<Text>().text.IndexOf(" "))) - Player2.getMagic (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" "))).Cost) + " MP";
		} else {
			LoadedOption = Player3.getMagic (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" ")));
			Player3Magic.GetComponent<Text>().text = (int.Parse(Player3Magic.GetComponent<Text>().text.Substring(0, Player3Magic.GetComponent<Text>().text.IndexOf(" "))) - Player3.getMagic (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" "))).Cost) + " MP";
		}
	}

	//To be used by item buttons to activate targets and determine the item being used
	public void Item(GameObject button) {
		TargetEnemy ();
		TargetSelf ();
		int quant;
		if (button.name.Substring (1, 1).Equals ("1")) {
			LoadedOption = Player1.getItem (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" ")));
			quant = Player1.getItem (button.GetComponentInChildren<Text> ().text.Substring (0, button.GetComponentInChildren<Text> ().text.IndexOf (" "))).Quantity;
			Player1.getItem (button.GetComponentInChildren<Text> ().text.Substring (0, button.GetComponentInChildren<Text> ().text.IndexOf (" "))).Quantity = quant - 1;
		} else if (button.name.Substring (1, 1).Equals ("2")) {
			LoadedOption = Player2.getItem (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" ")));
			quant = Player2.getItem (button.GetComponentInChildren<Text> ().text.Substring (0, button.GetComponentInChildren<Text> ().text.IndexOf (" "))).Quantity;
			Player2.getItem (button.GetComponentInChildren<Text> ().text.Substring (0, button.GetComponentInChildren<Text> ().text.IndexOf (" "))).Quantity = quant - 1;
		} else {
			LoadedOption = Player3.getItem (button.GetComponentInChildren<Text> ().text.Substring(0, button.GetComponentInChildren<Text> ().text.IndexOf(" ")));
			quant = Player3.getItem (button.GetComponentInChildren<Text> ().text.Substring (0, button.GetComponentInChildren<Text> ().text.IndexOf (" "))).Quantity;
			Player3.getItem (button.GetComponentInChildren<Text> ().text.Substring (0, button.GetComponentInChildren<Text> ().text.IndexOf (" "))).Quantity = quant - 1;
		}
		button.GetComponentInChildren<Text> ().text = button.GetComponentInChildren<Text> ().text.Replace ("" + quant, "" + (quant - 1));
		if (quant == 1) {
			button.GetComponent<Button> ().enabled = false;
			button.GetComponentInChildren<Text> ().color = Color.gray;
		}
	}

	//To be used by special buttons to activate targets and determine the special being used
	public void Special(GameObject button) {
		TargetEnemy ();
		if (button.name.Substring (1, 1).Equals ("1")) {
			LoadedOption = Player1.getSpecial (button.GetComponentInChildren<Text> ().text);
		} else if (button.name.Substring (1, 1).Equals ("2")) {
			LoadedOption = Player2.getSpecial (button.GetComponentInChildren<Text> ().text);
		} else {
			LoadedOption = Player3.getSpecial (button.GetComponentInChildren<Text> ().text);
		}
		button.GetComponent<Button> ().enabled = false;
		button.GetComponentInChildren<Text> ().color = Color.gray;
	}

	//Allows the enemy characters to be targetable
	public void TargetEnemy() {
		if (Enemy1Image.activeSelf) {
			Enemy1Pointer.SetActive (true);
			Enemy1Image.GetComponent<Button> ().enabled = true;
		}
		if (Enemy2Image.activeSelf) {
			Enemy2Pointer.SetActive (true);
			Enemy2Image.GetComponent<Button> ().enabled = true;
		}
		if (Enemy3Image.activeSelf) {
			Enemy3Pointer.SetActive (true);
			Enemy3Image.GetComponent<Button> ().enabled = true;
		}
	}

	//Allows the player characters to be targetable
	public void TargetSelf() {
		if (Player1Image.activeSelf) {
			Player1Pointer.SetActive (true);
			Player1Image.GetComponent<Button> ().enabled = true;
		}
		if (Player2Image.activeSelf) {
			Player2Pointer.SetActive (true);
			Player2Image.GetComponent<Button> ().enabled = true;
		}
		if (Player3Image.activeSelf) {
			Player3Pointer.SetActive (true);
			Player3Image.GetComponent<Button> ().enabled = true;
		}
	}

	//Does the intended effect on the target and resets the character to play as again
	public void Targeted(GameObject button) {
		if (button.name.Substring (0, 1).Equals ("E")) {
			if (button.name.Substring (5, 1).Equals ("1")) {
				int damage;
				if (Enemy1.isWeakAgainst (LoadedOption.Element)) {
					damage = LoadedOption.Damage * 2;
					Enemy1.Health -= damage;
				} else {
					damage = LoadedOption.Damage;
					Enemy1.Health -= damage;
				}
				Enemy1Pace += LoadedOption.Speed;
				setDamageAnimation (E1DamageText, damage);
				if (!LoadedOption.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Enemy1Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = LoadedOption.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (LoadedOption.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (Enemy1.Health <= 0) {
					Enemy1Image.SetActive (false);
					this.gameObject.GetComponent<AudioManager> ().playBattleSound (3, 0);
				}
			} else if (button.name.Substring (5, 1).Equals ("2")) {
				int damage;
				if (Enemy2.isWeakAgainst (LoadedOption.Element)) {
					damage = LoadedOption.Damage * 2;
					Enemy2.Health -= damage;
				} else {
					damage = LoadedOption.Damage;
					Enemy2.Health -= damage;
				}
				Enemy2Pace += LoadedOption.Speed;
				setDamageAnimation (E2DamageText, damage);
				if (!LoadedOption.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Enemy2Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = LoadedOption.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (LoadedOption.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (Enemy2.Health <= 0) {
					Enemy2Image.SetActive (false);
					this.gameObject.GetComponent<AudioManager> ().playBattleSound (3, 0);
				}
			} else {
				int damage;
				if (Enemy3.isWeakAgainst (LoadedOption.Element)) {
					damage = LoadedOption.Damage * 2;
					Enemy3.Health -= damage;
				} else {
					damage = LoadedOption.Damage;
					Enemy3.Health -= damage;
				}
				Enemy3Pace += LoadedOption.Speed;
				setDamageAnimation (E3DamageText, damage);
				if (!LoadedOption.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Enemy3Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = LoadedOption.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (LoadedOption.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (Enemy3.Health <= 0) {
					Enemy3Image.SetActive (false);
					this.gameObject.GetComponent<AudioManager> ().playBattleSound (3, 0);
				}
			}
		} else {
			if (button.name.Substring (6, 1).Equals ("1")) {
				int damage;
				if (Player1.isWeakAgainst (LoadedOption.Element)) {
					damage = LoadedOption.Damage * 2;
					Player1.Health -= damage;
				} else {
					damage = LoadedOption.Damage;
					Player1.Health -= damage;
				}
				Player1Pace += LoadedOption.Speed;
				setDamageAnimation (P1DamageText, damage);
				if (!LoadedOption.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Player1Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = LoadedOption.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (LoadedOption.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (Player1.Health <= 0) {
					Player1Image.SetActive (false);
				}
			} else if (button.name.Substring (6, 1).Equals ("2")) {
				int damage;
				if (Player2.isWeakAgainst (LoadedOption.Element)) {
					damage = LoadedOption.Damage * 2;
					Player2.Health -= damage;
				} else {
					damage = LoadedOption.Damage;
					Player2.Health -= damage;
				}
				Player2Pace += LoadedOption.Speed;
				setDamageAnimation (P2DamageText, damage);
				if (!LoadedOption.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Player2Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = LoadedOption.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (LoadedOption.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (Player2.Health <= 0) {
					Player2Image.SetActive (false);
				}
			} else {
				int damage;
				if (Player3.isWeakAgainst (LoadedOption.Element)) {
					damage = LoadedOption.Damage * 2;
					Player3.Health -= damage;
				} else {
					damage = LoadedOption.Damage;
					Player3.Health -= damage;
				}
				Player3Pace += LoadedOption.Speed;
				setDamageAnimation (P3DamageText, damage);
				if (!LoadedOption.Trigger.Equals ("Attack")) {
					ActualAnimation.SetActive (true);
					AttackAnimation.transform.localPosition = Player3Image.transform.localPosition;
					PuppetAnimation.GetComponent<Image> ().sprite = LoadedOption.Sprite;
					ActualAnimation.GetComponent<Animator> ().SetTrigger (LoadedOption.Trigger);
					StartCoroutine (WaitForAnimation ());
				}
				if (Player3.Health <= 0) {
					Player3Image.SetActive (false);
				}
			}
		}
		Enemy1Pointer.SetActive (false);
		Enemy1Image.GetComponent<Button> ().enabled = false;
		Enemy2Pointer.SetActive (false);
		Enemy2Image.GetComponent<Button> ().enabled = false;
		Enemy3Pointer.SetActive (false);
		Enemy3Image.GetComponent<Button> ().enabled = false;
		Player1Pointer.SetActive (false);
		Player1Image.GetComponent<Button> ().enabled = false;
		Player2Pointer.SetActive (false);
		Player2Image.GetComponent<Button> ().enabled = false;
		Player3Pointer.SetActive (false);
		Player3Image.GetComponent<Button> ().enabled = false;
		Debug.Log ("Enemy1Health " + Enemy1.Health);
		Debug.Log ("Enemy2Health " + Enemy2.Health);
		Debug.Log ("Enemy3Health " + Enemy3.Health);
		if (LoadedOption.Sound != null) {
			this.gameObject.GetComponent<AudioManager> ().playSound (LoadedOption.Sound, 0);
		} else {
			this.gameObject.GetComponent<AudioManager> ().playBattleSound (Random.Range (0, 1), Random.value);
		}
		if (Fighter.name.Substring (6, 1).Equals ("1")) {
			Player1Percentage.GetComponent<Text>().text = "000%";
			P1Queued = false;
		} else if (Fighter.name.Substring (6, 1).Equals ("2")) {
			Player2Percentage.GetComponent<Text>().text = "000%";
			P2Queued = false;
		} else {
			Player3Percentage.GetComponent<Text>().text = "000%";
			P3Queued = false;
		}
		if (Fighter.name.Substring (6, 1).Equals ("1")) {
			Color temp = Player1Panel.GetComponent<Image> ().color;
			temp.a = 100/255f;
			Player1Panel.GetComponent<Image> ().color = temp;
			Player1Image.GetComponent<Animator> ().SetTrigger ("Attack");
		} else if (Fighter.name.Substring (6, 1).Equals ("2")) {
			Color temp = Player2Panel.GetComponent<Image> ().color;
			temp.a = 100/255f;
			Player2Panel.GetComponent<Image> ().color = temp;
			Player2Image.GetComponent<Animator> ().SetTrigger ("Attack");
		} else {
			Color temp = Player3Panel.GetComponent<Image> ().color;
			temp.a = 100/255f;
			Player3Panel.GetComponent<Image> ().color = temp;
			Player3Image.GetComponent<Animator> ().SetTrigger ("Attack");
		}
		Wait = false;
		checkVictory ();
	}

	//checks and ends the battle if the conditions are meet
	private void checkVictory() {
		if (!(Enemy1Image.activeSelf || Enemy2Image.activeSelf || Enemy3Image.activeSelf)) {
			Debug.Log ("Victory");
			this.gameObject.GetComponent<AudioManager> ().stopBackground ();
			this.gameObject.GetComponent<AudioManager> ().playBattleSound (7, 0);
			ActivateStandardMode ();
		}
	}

	//
	private void checkDefeat() {
		if (!(Player1Image.activeSelf || Player2Image.activeSelf || Player3Image.activeSelf)) {
			Debug.Log ("Defeat");
			ActivateStandardMode ();
		}
	}

	//sets the button given to it to the correct elemental image based on the battleoption given
	private void UpdateElementalIcon(GameObject button, BattleOption option) {
		if (option.Element == 0) {
			button.GetComponent<Image> ().sprite = BlankButton;
		} else if (option.Element == 1) {
			button.GetComponent<Image> ().sprite = WaterButton;
		} else if (option.Element == 2) {
			button.GetComponent<Image> ().sprite = LightningButton;
		} else if (option.Element == 3) {
			button.GetComponent<Image> ().sprite = EarthButton;
		} else if (option.Element == 4) {
			button.GetComponent<Image> ().sprite = EtherealButton;
		} else if (option.Element == 5) {
			button.GetComponent<Image> ().sprite = ForceButton;
		} else if (option.Element == 6) {
			button.GetComponent<Image> ().sprite = AirButton;
		} else {
			button.GetComponent<Image> ().sprite = FireButton;
		}
	}

	//sets the given characterpanel's color to the element represented by their character's element
	private void UpdateCharacterElementIcon(GameObject characterPanel, Character character) {
		if (character.Element == 1) {
			Color c = Color.blue;
			c.a = 100 / 255f;
			characterPanel.GetComponent<Image> ().color = c;
		} else if (character.Element == 2) {
			Color c = Color.yellow;
			c.a = 100 / 255f;
			characterPanel.GetComponent<Image> ().color = c;
		} else if (character.Element == 3) {
			characterPanel.GetComponent<Image> ().color = new Color (94, 55, 38, 100 / 255f);
		} else if (character.Element == 4) {
			Color c = Color.magenta;
			c.a = 100 / 255f;
			characterPanel.GetComponent<Image> ().color = c;
		} else if (character.Element == 5) {
			Color c = Color.grey;
			c.a = 100 / 255f;
			characterPanel.GetComponent<Image> ().color = c;
		} else if (character.Element == 6) {
			Color c = Color.cyan;
			c.a = 100 / 255f;
			characterPanel.GetComponent<Image> ().color = c;
		} else if (character.Element == 7) {
			Color c = Color.red;
			c.a = 100 / 255f;
			characterPanel.GetComponent<Image> ().color = c;
		}
	}

	//randomizes the placement of the given gameobject and sets it active. Meant to be used for the damage indicators.
	private void setDamageAnimation(GameObject character, int damage) {
		RectTransform rt = character.GetComponent<RectTransform> ();
		rt.localPosition = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50));
		character.GetComponent<Text> ().text = damage + "";
		character.SetActive (true);
	}
}