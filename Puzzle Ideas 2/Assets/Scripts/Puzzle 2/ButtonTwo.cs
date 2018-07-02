using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonTwo : MonoBehaviour, IInteractable {

    public Transform player;
    public Animator anim;
    private bool isNear;
    private bool canInteract = true;
    public GUIStyle style;
    public PuzzleTwo[] puzzleObj;
    public Door door;
    [Header("Puzzle Solution Settings")]
    public int[] solution;
    private int[] puzzlePosition = new int[5];

    public void Interact()
    {
        anim.Play("ButtonPressed", -1, 0f);

    }

    void OnGUI()
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
        for (int i=0; puzzleObj.Length > i; i++)
        {
            puzzlePosition[i] = puzzleObj[i].GetActive();
        }


        if (Vector3.Distance(transform.position, player.position) < 1.7f)
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

    public void CheckSolution(int[] puzzle)
    {
        if (solution.SequenceEqual(puzzle))
        {
            door.Unlock();
        }
    }
}
