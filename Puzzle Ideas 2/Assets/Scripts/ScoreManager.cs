using System;
using UnityEngine;
using System.Collections;



public class ScoreManager : MonoBehaviour {

	private static ScoreManager inst = null;

	public static ScoreManager GetScoreManager() {
		if (inst == null) {
			inst = new ScoreManager();
		}
		return inst;
	}

	private ScoreManager() {
	}

	private const float COLLISION_D = -1f;

	// TODO
	private const float PICKUP_D = 10f;

	private float score = 100f;

	public void DecreaseScoreOnCollision() {
		score += COLLISION_D;
		if (score < 0) {
			score = 0;
			StateMachineManager.GetStateMachineManager().MakeTransition("defeat");
			GUIManager.GetGUIManager().ArrangeGUI();
		}
	}

	public void ResetScore() {
		score = 100f;
	}

	public void IncreaseScoreOnPickup() {
		score += PICKUP_D;
		if (score > 100) {
			score = 100;
		}
	}

	public float GetScore() {
		return score;
	}
}
