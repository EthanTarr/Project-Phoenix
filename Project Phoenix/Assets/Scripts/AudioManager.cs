using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance;
	public AudioClip[] battleSounds;
	public AudioClip[] sounds;
	public AudioClip[] backgrounds;
	public AudioSource source;
	public AudioSource backSource;

	void Awake () {
		instance = this;
	}

	public void playSound(AudioClip A, float pitch) {
		source.pitch = 1 + pitch;
		source.PlayOneShot (A);
	}

	public void playSound(int i, float pitch) {
		source.pitch = 1 + pitch;
		source.PlayOneShot (sounds[i]);
	}

	public void playBattleSound(int i, float pitch) {
		source.pitch = 1 + pitch;
		source.PlayOneShot (battleSounds[i]);
	}

	public void playBackground(int i) {
		backSource.PlayOneShot (backgrounds[i]);
	}

	public void stopBackground() {
		backSource.Stop ();
	}
}
