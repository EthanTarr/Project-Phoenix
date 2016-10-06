using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	private GameObject player;
	private bool isMoving = false;
	private float t = 0;
	private float Xdistance = 0;
	private float Ydistance = 0;
	private float playerPositionX = 0;
	private float playerPositionY = 0;
	private Vector2 startPosition;
	private int playerDirection = 0;
	private Sprite right;
	private Sprite left;
	private Sprite up;
	private Sprite down;
	public float speed = 1;
	public float distance = 5;
	public Sprite test;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("MainCharacter");
		Sprite[] tst = Resources.LoadAll<Sprite> ("8DKnight");
		right = tst[0];
		left = tst[42];
		up = tst[6];
		down = tst[24];
		SetCharacterDirection (GameManager.startDirection);
	}

	void Update() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		//checks what direction the controls are pressing and if there is a valid space in that direction
		if (!isMoving && GameManager.isPlayable()) {
			if (moveHorizontal > 0) {
				player.GetComponent<SpriteRenderer> ().sprite = right;
				playerDirection = 0;
				if (GameObject.Find ((playerPositionX + 1) + "," + playerPositionY) != null) {
					isMoving = true;
					Xdistance = distance;
					playerPositionX += 1;
				}
			} else if (moveHorizontal < 0) {
				player.GetComponent<SpriteRenderer> ().sprite = left;
				playerDirection = 2;
				if (GameObject.Find ((playerPositionX - 1) + "," + playerPositionY) != null) {
					isMoving = true;
					Xdistance = -distance;
					playerPositionX -= 1;
				}
			} else if (moveVertical > 0) {
				player.GetComponent<SpriteRenderer> ().sprite = up;
				playerDirection = 1;
				if (GameObject.Find (playerPositionX + "," + (playerPositionY + 1)) != null) {
					isMoving = true;
					Ydistance = distance;
					playerPositionY += 1;
				}
			} else if (moveVertical < 0) {
				player.GetComponent<SpriteRenderer> ().sprite = down;
				playerDirection = 3;
				if (GameObject.Find (playerPositionX + "," + (playerPositionY - 1)) != null) {
					isMoving = true;
					Ydistance = -distance;
					playerPositionY -= 1;
				}
			}
			startPosition = player.transform.position;

			//checks for avaliable interactions when the action key is hit
			if (Input.GetAxis("Action") > 0) {
				foreach (GameObject character in GameObject.FindGameObjectsWithTag("Character")) {
					int X = (1 - (playerDirection % 2)) * (int)Mathf.Pow(-1, (playerDirection / 2) + 2);
					int Y = playerDirection % 2 * (int)Mathf.Pow(-1, (playerDirection % 3) + 1);
					if (character.transform.position.Equals(player.transform.position + new Vector3(X * 5, (Y * 5) + 1, 0))) {
						GameObject.Find("GameManager").GetComponent<GameManager>().interact ();
					}
				}
			}
		} 

		//moves the player in the indicated direction
		if (isMoving && t <= 1) {
			t += (t + Time.deltaTime) * speed;
			player.transform.position = Vector2.Lerp (startPosition, startPosition + new Vector2 (Xdistance, Ydistance), t);
		} else {
			//gets ready to move again
			t = 0;
			Xdistance = 0;
			Ydistance = 0;
			isMoving = false;
			//if player is on a entrance than it uses the EnterRoom method of LoadRoom script
			if (GameObject.Find (playerPositionX + "," + playerPositionY).GetComponent<LoadRoom> () != null) {
				GameObject.Find (playerPositionX + "," + playerPositionY).GetComponent<LoadRoom> ().EnterRoom ();
				playerPositionX = 0;
				playerPositionY = 0;
			}
		}
	}

	//sets the maincharacter's direction sprite depending on the int direction given
	public void SetCharacterDirection(int direction) {
		if (direction == 0) {
			player.GetComponent<SpriteRenderer> ().sprite = right;
		} else if (direction == 1) {
			player.GetComponent<SpriteRenderer> ().sprite = up;
		} else if (direction == 2) {
			player.GetComponent<SpriteRenderer> ().sprite = left;
		} else {
			player.GetComponent<SpriteRenderer> ().sprite = down;
		}
	}

	//gets character position when level is loaded
	void OnLevelWasLoaded (int level) {
		player = GameObject.Find ("MainCharacter");
		if (GameManager.startPoint.Substring (0, 1).Equals ("-")) {
			playerPositionX = int.Parse (GameManager.startPoint.Substring (0, 2));
		} else {
			playerPositionX = int.Parse (GameManager.startPoint.Substring (0, 1));
		}
		if (GameManager.startPoint.Substring (2, 1).Equals ("-")) {
			playerPositionY = int.Parse (GameManager.startPoint.Substring (2, 2));
		} else {
			playerPositionY = int.Parse (GameManager.startPoint.Substring (2, 1));
		}
		SetCharacterDirection (GameManager.startDirection);
	}
}
