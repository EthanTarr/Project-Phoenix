using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Test : Enemy {

	private int skillChance;
	private int magicChance;
	private int itemChance;

	// Use this for initialization
	void Start () {
		skillChance = 60;
		magicChance = 80;
		itemChance = 100;
	}

	//
	public override BattleOption EnemyAI(Character enemy) {
		BattleOption check = checkParamaters (enemy);
		if (check.Name.Equals("Null")) {
			int rand = Random.Range (1, 100);
			if (rand <= skillChance) {
				return selfSkill (enemy);
			} else if (rand <= magicChance) {
				return selfMagic (enemy);
			} else if (rand <= itemChance) {
				return selfItem (enemy, "Harm");
			} else {
				return selfSpecial (enemy);
			}
		}
		return check;
	}

	//
	public override float getChance() {
		float counterChance = Random.value;
		while(counterChance < .4f || counterChance >.75f) {
			counterChance = Random.value;
		}
		return counterChance;
	}

	//
	public override int getPace() {
		return Random.Range (5, 7);
	}

	//returns a random skill
	private Skill selfSkill(Character enemy) {
		return enemy.getRandomSkill ();
	}

	//returns the skill specified by the given string
	private Skill selfSkill(Character enemy, string skill) {
		return enemy.getSkill (skill);
	}

	//returns a random magic
	private Magic selfMagic(Character enemy) {
		Magic mag = enemy.getRandomMagic ();
		enemy.MagicPoints -= mag.Cost;
		return mag;
	}

	//returns the given magic specified by the given string
	private Magic selfMagic(Character enemy, string magic) {
		Magic mag = enemy.getMagic (magic);
		enemy.MagicPoints -= mag.Cost;
		return mag;
	}

	//returns a random item
	private Item selfItem(Character enemy) {
		Item it = enemy.getRandomItem ();
		it.Quantity -= 1;
		return it;
	}

	//returns the given item specified by the given string
	private Item selfItem(Character enemy, string item) {
		Item it = enemy.getItem (item);
		it.Quantity -= 1;
		return it;
	}

	//returns a random special
	private Special selfSpecial(Character enemy) {
		Special spec = enemy.getRandomSpecial ();
		spec.Used = true;
		return spec;
	}

	//returns the given special specified by the given string
	private Special selfSpecial(Character enemy, string special) {
		Special spec = enemy.getSpecial (special);
		spec.Used = true;
		return spec;
	}

	//
	private BattleOption checkParamaters(Character enemy) {
		if (enemy.Health <= 50) {
			if (enemy.getItem ("Potion").Quantity > 0) {
				GameObject.Find ("GameManager").GetComponent<BattleManager> ().victim = "self";
				return selfItem (enemy, "Potion");
			} else {
				skillChance = 80;
				magicChance = 100;
				itemChance = 100;
			}
		}
		return enemy.getSkill ("SkNull");
	}
}
