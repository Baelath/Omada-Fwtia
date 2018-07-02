using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManagerold : MonoBehaviour {

    public Text puzzle1;
    public Text puzzle2;
    public Text puzzle3;
    public Text puzzle4;
    public Text interact;

    private static GUIManagerold inst;
    public static GUIManagerold getGUIManager()
    {
        return inst;
    }

    public void Awake()
    {
        inst = this;
    }

    #region GUI Puzzle Info <<<Placeholder>>> GUI
    public void Enable_Puzzle1()
    {
        puzzle1.enabled = true;
    }
    public void Disable_Puzzle1()
    {
        puzzle1.enabled = false;
    }

    public void Enable_Puzzle2()
    {
        puzzle2.enabled = true;
    }
    public void Disable_Puzzle2()
    {
        puzzle2.enabled = false;
    }

    public void Enable_Puzzle3()
    {
        puzzle3.enabled = true;
    }
    public void Disable_Puzzle3()
    {
        puzzle3.enabled = false;
    }

    public void Enable_Puzzle4()
    {
        puzzle4.enabled = true;
    }
    public void Disable_Puzzle4()
    {
        puzzle4.enabled = false;
    }

    #endregion

    public void InteractPromptEnable()
    {
        interact.enabled = true;
    }
    public void InteractPromptDisable()
    {
        interact.enabled = false;
    }


    #region GUI Door Interaction Prompt GUI

    public void DoorOpen()
    {
        interact.text = "Press E to open!";
    }

    public void DoorClose()
    {
        interact.text = "Press E to close!";
    }
    #endregion
}
