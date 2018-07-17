using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonTwo : MonoBehaviour, IInteractable {

    public Transform player;                                                        // player to check distance from...
    public Animator anim;                                                           // animator that plays the button animations...
    private bool isNear;
    private bool canInteract = true;
    public GUIStyle style;
    public PuzzleTwo[] puzzleObj;                                                   // array of puzzle objects...
    public Door door;                                                               // Door controlled by the puzzle...
    [Header("Puzzle Solution Settings")]
    public int[] solution;                                                          // Intended solution in array form... 0 for inactive, 1 for active puzzle objects...
    private int[] puzzlePosition = new int[5];                                      // Array of current puzzle positions... 9 for inactive, 1 for active...

    public void Interact()
    {
        anim.Play("ButtonPressed", -1, 0f);                                         // Play button animation and reset so it can be played again...

    }

    void OnGUI()                                                                    // Text to be displayed when player is in interaction range...
    {
        if (isNear == true)
        {
            style.normal.textColor = Color.green;
            GUI.Label(new Rect(900, 650, 200, 40), "Press E to press the button!", style);
        }
    }

    IEnumerator WaitTime()                                                          // Wait 1 second between interactions (for the animations to play correctly)...                                    
    {
        canInteract = false;
        yield return new WaitForSeconds(1);
        canInteract = true;
    }

    private void Update()                                                           
    {
        for (int i=0; puzzleObj.Length > i; i++)                                    // Make an array of the puzzle objects... 0 if inactive, 1 if active...
        {
            puzzlePosition[i] = puzzleObj[i].GetActive();
        }


        if (Vector3.Distance(transform.position, player.position) < 1.7f)           // Allow interaction if player is in range...
        {
            isNear = true;
            if (Input.GetKeyDown(KeyCode.E) & canInteract == true)
            {
                StartCoroutine(WaitTime());
                Interact();
                Debug.Log("Interacted!");
                CheckSolution(puzzlePosition);
            }
        }
        else
        {
            isNear = false;
        }
    }

    public void CheckSolution(int[] puzzle)                                         // Check current positions against solution... Unlock door if solution is correct...
    {
        if (solution.SequenceEqual(puzzle))
        {
            door.Unlock();
        }
    }
}
