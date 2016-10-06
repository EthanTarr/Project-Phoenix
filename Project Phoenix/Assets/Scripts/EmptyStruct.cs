using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace AssemblyCSharp {

	public class Character {
		public string Name;
		public int Health;
		public int MagicPoints;
		public int Speed;
		public int Element;
		public Sprite Picture;
		public string AI;
		private ArrayList Skills;
		private ArrayList Magic;
		private ArrayList Items;
		private ArrayList Specials;
		private Skill SkNull;
		private Magic MagNull;
		private Item ItNull;
		private Special SpecNull;

		public Character (string name, int health, int magicpoints, int speed, int element, Sprite picture, ArrayList skills, ArrayList magic, ArrayList items, ArrayList specials, string ai) {
			if (speed > 100) {
				throw new Exception ("speed is too large");
			}
			this.Name = name;
			this.Health = health;
			this.MagicPoints = magicpoints;
			this.Speed = speed;
			this.Element = element;
			this.Picture = picture;
			this.Skills = skills;
			this.Magic = magic;
			this.Items = items;
			this.Specials = specials;
			this.AI = ai;
			addNullables ();
		}

		public Character (string name, int health, int magicpoints, int speed, int element, Sprite picture, ArrayList skills, ArrayList magic, ArrayList items, ArrayList specials) {
			if (speed > 100) {
				throw new Exception ("speed is too large");
			}
			this.Name = name;
			this.Health = health;
			this.MagicPoints = magicpoints;
			this.Speed = speed;
			this.Element = element;
			this.Picture = picture;
			this.Skills = skills;
			this.Magic = magic;
			this.Items = items;
			this.Specials = specials;
			this.AI = "test";
			addNullables ();
		}

		public Character (string name, int health, int magicpoints, int speed, int element) {
			if (speed > 100) {
				throw new Exception ("speed is too large");
			}
			this.Name = name;
			this.Health = health;
			this.MagicPoints = magicpoints;
			this.Speed = speed;
			this.Element = element;
			this.Picture = null;
			this.Skills = new ArrayList ();
			this.Magic = new ArrayList ();
			this.Items = new ArrayList ();
			this.Specials = new ArrayList ();
			this.AI = "test";
			addNullables ();
		}

		//Adds a nullable battleoption to each list
		private void addNullables() {
			SkNull = (Skill)GameObject.Find ("GameManager").GetComponent<GameManager> ().Abilities ["SkNull"];
			MagNull = (Magic)GameObject.Find ("GameManager").GetComponent<GameManager> ().Abilities ["MagNull"];
			ItNull = (Item)GameObject.Find ("GameManager").GetComponent<GameManager> ().Abilities ["ItNull"];
			SpecNull = (Special)GameObject.Find ("GameManager").GetComponent<GameManager> ().Abilities ["SpecNull"];
		}

		//sets the objects skills to the given arraylist of skills
		public void setSkills(ArrayList skills) {
			this.Skills = skills;
		}

		//gets the objects skills as an Arraylist
		public ArrayList getSkills() {
			return this.Skills;
		}

		//Checks if character's got skills, son!
		//returns true if character has more than zero skills and false otherwise
		public bool hasSkills() {
			if (Skills.Count > 0) {
				return true;
			}
			return false;
		}

		//gets the skill represented by the given string name from the skills of the object. throws an exception if the object does not have the given skill.
		public Skill getSkill(string name) {
			foreach (Skill skill in Skills) {
				if (skill.Name.Equals (name)) {
					return skill;
				}
			}
			return SkNull;
		}

		//gets a random skill from the skills arraylist and returns it
		public Skill getRandomSkill() {
			int random = UnityEngine.Random.Range (1, Skills.Count);
			int count = 0;
			foreach (Skill skill in Skills) {
				count++;
				if (count == random) {
					return skill;
				}
			} 
			throw new Exception ();
		}

		//sets the objects magics to the given arraylist of magics
		public void setMagic(ArrayList magic) {
			this.Magic = magic;
		}

		//gets the objects magics as an Arraylist
		public ArrayList getMagics() {
			return this.Magic;
		}

		//returns true if character has more than zero magic and false otherwise
		public bool hasMagic() {
			if (Magic.Count > 0) {
				return true;
			}
			return false;
		}

		//gets the magic represented by the given string name from the magics of the object. throws an exception if the object does not have the given magic.
		public Magic getMagic(string name) {
			foreach (Magic magic in Magic) {
				if (magic.Name.Equals (name)) {
					return magic;
				}
			}
			return MagNull;
		}

		//gets a random magic from the magics arraylist and returns it
		public Magic getRandomMagic() {
			int random = UnityEngine.Random.Range (1, Magic.Count);
			int count = 0;
			foreach (Magic magic in Magic) {
				count++;
				if (count == random) {
					return magic;
				}
			} 
			throw new Exception ();
		}

		//sets the objects items to the given arraylist of skills
		public void setItems(ArrayList items) {
			this.Items = items;
		}

		//gets the objects items as an Arraylist
		public ArrayList getItems() {
			return this.Items;
		}

		//returns true if character has more than zero items and false otherwise
		public bool hasItems() {
			if (Items.Count > 0) {
				return true;
			}
			return false;
		}

		//gets the item represented by the given string name from the items of the object. throws an exception if the object does not have the given item.
		public Item getItem(string name) {
			foreach (Item item in Items) {
				if (item.Name.Equals (name)) {
					return item;
				}
			}
			return ItNull;
		}

		//gets a random item from the items arraylist and returns it
		public Item getRandomItem() {
			int random = UnityEngine.Random.Range (1, Items.Count);
			int count = 0;
			foreach (Item item in Items) {
				count++;
				if (count == random) {
					return item;
				}
			} 
			throw new Exception ();
		}

		//sets the objects specials to the given arraylist of specials
		public void setSpecials(ArrayList specials) {
			this.Specials = specials;
		}

		//gets the objects specials as an Arraylist
		public ArrayList getSpecials() {
			return this.Specials;
		}

		//returns true if character has more than zero specials and false otherwise
		public bool hasSpecials() {
			if (Items.Count > 0) {
				return true;
			}
			return false;
		}

		//gets the special represented by the given string name from the specials of the object. throws an exception if the object does not have the given special.
		public Special getSpecial(string name) {
			foreach (Special special in Specials) {
				if (special.Name.Equals (name)) {
					return special;
				}
			}
			return SpecNull;
		}

		//gets a random special from the skills arraylist and returns it
		public Special getRandomSpecial() {
			int random = UnityEngine.Random.Range (1, Items.Count);
			int count = 0;
			foreach (Special special in Specials) {
				count++;
				if (count == random) {
					return special;
				}
			} 
			throw new Exception ();
		}

		//returns the bool of if the given element is dominate over the character's element
		public bool isWeakAgainst(int element) {
			if (this.Element == 0) {
				return false;
			} else if ((this.Element == 7 && element == 1) || (this.Element + 1) == element) {
				return true;
			} else {
				return false;
			}
		}
	}
}

namespace AssemblyCSharp {

	public class BattleOption {
		public string Name;
		public int Damage;
		public int Speed;
		public int Element;
		public string Trigger;
		public Sprite Sprite;
		public AudioClip Sound;
		/*
		 * N/A = 0
		 * Water = 1
		 * Lightning = 2
		 * Earth = 3
		 * Ethereal = 4
		 * Force = 5
		 * Air = 6
		 * Fire = 7
		 */
	}
}

namespace AssemblyCSharp {

	public class Skill : BattleOption {

		public Skill(string name, int damage, int speed, int element, string trigger, Sprite sprite, AudioClip sound) {
			this.Name = name;
			this.Damage = damage;
			this.Speed = speed;
			this.Element = element;
			if (trigger == null) {
				trigger = "Attack";
			}
			this.Trigger = trigger;
			this.Sprite = sprite;
			this.Sound = sound;
		}

		public Skill(string name, int damage, int speed, int element) {
			this.Name = name;
			this.Damage = damage;
			this.Speed = speed;
			this.Element = element;
			this.Trigger = "Attack";
			this.Sprite = null;
		}
	}
}

namespace AssemblyCSharp {

	public class Item : BattleOption {
		public int Quantity;

		public Item(string name, int quantity, int damage, int speed, int element, string trigger, Sprite sprite, AudioClip sound) {
			this.Name = name;
			this.Quantity = quantity;
			this.Damage = damage;
			this.Speed = speed;
			this.Element = element;
			if (trigger == null) {
				trigger = "Attack";
			}
			this.Trigger = trigger;
			this.Sprite = sprite;
			this.Sound = sound;
		}

		public Item(string name, int quantity, int damage, int speed, int element) {
			this.Name = name;
			this.Quantity = quantity;
			this.Damage = damage;
			this.Speed = speed;
			this.Element = element;
			this.Trigger = "Attack";
			this.Sprite = null;
		}
	}
}

namespace AssemblyCSharp {

	public class Magic : BattleOption {
		public int Cost;

		public Magic(string name, int cost, int damage, int speed, int element, string trigger, Sprite sprite, AudioClip sound) {
			this.Name = name;
			this.Cost = cost;
			this.Damage = damage;
			this.Speed = speed;
			this.Element = element;
			if (trigger == null) {
				trigger = "Attack";
			}
			this.Trigger = trigger;
			this.Sprite = sprite;
			this.Sound = sound;
		}

		public Magic(string name, int cost, int damage, int speed, int element) {
			this.Name = name;
			this.Cost = cost;
			this.Damage = damage;
			this.Speed = speed;
			this.Element = element;
			this.Trigger = "Attack";
			this.Sprite = null;
		}
	}
}

namespace AssemblyCSharp {

	public class Special : BattleOption {
		public bool Used;

		public Special(string name, int damage, int speed, int element, string trigger, Sprite sprite, AudioClip sound) {
			this.Name = name;
			this.Used = false;
			this.Damage = damage;
			this.Speed = speed;
			this.Element = element;
			if (trigger == null) {
				trigger = "Attack";
			}
			this.Trigger = trigger;
			this.Sprite = sprite;
			this.Sound = sound;
		}

		public Special(string name, int damage, int speed, int element) {
			this.Name = name;
			this.Used = false;
			this.Damage = damage;
			this.Speed = speed;
			this.Element = element;
			this.Trigger = "Attack";
			this.Sprite = null;
		}
	}
}
