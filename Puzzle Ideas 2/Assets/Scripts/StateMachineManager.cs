using System.Collections.Generic;
using UnityEngine;
using System.Collections;
/**
 * 
 */
public class StateMachineManager : MonoBehaviour
{

    /*-- Game manager API ------------------------------------------------------*/

    /**
	 * 
	 */
    private static StateMachineManager inst = null;

    /**
	 * 
	 */
    private StateMachineManager()
    {

    }

    /**
	 * 
	 */
    public static StateMachineManager GetStateMachineManager()
    {
        if (inst == null)
        {
            inst = new StateMachineManager();
        }
        return inst;
    }

    /*-- State machine management API -------------------------------------------*/

    private string currentState = "gameplay";

    private Dictionary<string, List<string>> stateMachine = new Dictionary<string, List<string>>() {
        {"intro", new List<string>() {"main_menu"}},
        {"main_menu", new List<string>() {"gameplay"}},
        {"gameplay", new List<string>() {"victory", "defeat", "main_menu", "alert"}},
        {"alert", new List<string>() {"victory", "defeat", "main_menu", "gameplay"}},
        {"victory", new List<string>() {"main_menu"}},
		// TODO: remove transition to gameplay after testing...
		{"defeat", new List<string>() {"main_menu", "gameplay"}}
    };

    public string GetCurrentState()
    {
        return currentState;
    }

    public void MakeTransition(string to)
    {
        if (stateMachine[currentState].Contains(to))
        {
            currentState = to;
        }
    }
}
