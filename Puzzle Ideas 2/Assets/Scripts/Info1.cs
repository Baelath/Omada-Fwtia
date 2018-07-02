using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info1 : MonoBehaviour {

    private GUIManagerold guiManager;

    private void Start()
    {
        guiManager = GUIManagerold.getGUIManager();
    }

    private void OnTriggerEnter(Collider other)
    {
        guiManager.Enable_Puzzle1();
        //Debug.Log("Puzzle 1 infocube entered!");
    }

    private void OnTriggerExit(Collider other)
    {

        guiManager.Disable_Puzzle1();
        //Debug.Log("Puzzle 1 infocube exited!");
    }
}
