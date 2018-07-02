using System;
using UnityEngine;
using System.Collections;

/**
 * AudioManager
 * 
 * Manages (initialization, configuration, reproduction,
 * etc.) all game audio according to game logic in a
 * centralized, concern-specific fashion.
 */

public class AudioManager : MonoBehaviour {

	
	public AudioSource backgroundMusic;

	private static AudioManager inst = null;

	public static AudioManager GetAudioManager() {
		return inst;
	}

	public void Awake() {
		inst = this;
	}

	public void Start() {

		AudioSource[] audioSources = GetComponents<AudioSource>();


        

		backgroundMusic.loop = true;
		backgroundMusic.volume = 1f;

		StartBackgroundMusic();
	}

	

	public void StartBackgroundMusic() {
		backgroundMusic.Play();
	}
}

