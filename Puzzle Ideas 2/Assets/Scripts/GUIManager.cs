using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public Text mainText;
	public Text secondaryText;
	public Text hpText;
    public Text puzzle1;

    private static GUIManager inst;

	public static GUIManager GetGUIManager() {
		return inst;
	}

	public void Awake() {
		inst = this;
	}
    public void Enable_Puzzle1()
    {
        puzzle1.enabled = true;
    }
    public void Disable_Puzzle1()
    {
        puzzle1.enabled = false;
    }

    public void Update() {
		string currentState = StateMachineManager.GetStateMachineManager().GetCurrentState();
		if (currentState == "gameplay" || currentState == "alert") {
			//hpText.text = "Score: " + ((int)ScoreManager.GetScoreManager().GetScore()).ToString();
		}
	}

	public void EnemyTouch() {
		// mainText.enabled = true;
		mainText.text = "AAAARRGGHHHH!!!";
	}

	public void EnemyUntouch() {
		// mainText.enabled = false;
		mainText.text = "";
	}

	public void ArrangeGUI() {
		switch (StateMachineManager.GetStateMachineManager().GetCurrentState()) {
		case "gameplay":
		case "alert":
			mainText.text = "";
			secondaryText.text = "";
			hpText.enabled = true;
			break;
		case "defeat":
			mainText.text = "You lost!";
			secondaryText.text = "Press SPACE to continue";
			hpText.enabled = false;
			break;
		}
	}

	/*
	public void StartGame() {
		mainText.text = "";
		secondaryText.text = "";
		hpText.enabled = true;
	}

	public void Defeat() {
		mainText.text = "You lost!";
		secondaryText.text = "Press any key";
		hpText.enabled = false;
	}
	*/
}
