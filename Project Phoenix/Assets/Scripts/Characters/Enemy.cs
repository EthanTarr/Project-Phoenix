using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public abstract class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	//
	public virtual BattleOption EnemyAI(Character enemy) {
		Debug.Log ("!!!");
		return new BattleOption ();
	}

	//
	public virtual float getChance() {
		return 0;
	}

	//
	public virtual int getPace() {
		return 0;
	}
}
