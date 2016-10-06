using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = GameObject.Find ("MainCharacter").transform.position + new Vector3 (0, 0, -10);
	}
}
