using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{

    public Transform player;                                                                    // player to check distance from...
    public Animator anim;                                                                       // animator that plays the button animations...
    private bool isNear;
    private bool canInteract = true;
    public GUIStyle style;
    public PuzzleOne left;                                                                      // First puzzle piece...
    public PuzzleOne middle;                                                                    // Middle puzzle piece...
    public PuzzleOne right;                                                                     // Last puzzle piece...
    public Door door;                                                                           // Door controlled by the puzzle...
    private int pos1;                                                                           // First puzzle piece current position...
    private int pos2;                                                                           // Middle puzzle piece current position...
    private int pos3;                                                                           // Last puzzle piece current position...
    [Header("Puzzle Solution Settings")]                                                        
    public int solution1;                                                                       // First piece solution... 
    public int solution2;                                                                       // Middle piece solution...
    public int solution3;                                                                       // Last piece solution... 

    private void Start()
    {
        //door = GameObject.Find("PuzzleDoor").GetComponent<Door>();
        //left = GameObject.Find("Left").GetComponent<PuzzleOne>();
        //middle = GameObject.Find("Middle").GetComponent <PuzzleOne>();
        //right = GameObject.Find("Right").GetComponent<PuzzleOne>();
    }


    public void Interact()
    {
        anim.Play("ButtonPress", -1, 0f);                                                       // Play the button animation and reset (so it can be played again)...
        //Debug.Log("Animation played!");
    }

    void OnGUI()                                                                                // Text to appear when player is in animation range...
    {
        if (isNear == true)
        {
            style.normal.textColor = Color.green;
            GUI.Label(new Rect(900, 650, 200, 40), "Press E to press the button!", style);
        }
    }

    IEnumerator WaitTime()                                                                      // Wait 1 second between interactions (for the animations to play correctly)...                                    
    {
        canInteract = false;
        yield return new WaitForSeconds(1);
        canInteract = true;
    }

    private void Update()
    {
        pos1 = left.GetPosition();
        pos2 = middle.GetPosition();
        pos3 = right.GetPosition();

        if (Vector3.Distance(transform.position, player.position) < 1.4f)
        {
            isNear = true;
            if (Input.GetKeyDown(KeyCode.E) & canInteract == true)
            {
                StartCoroutine(WaitTime());
                Interact();
                Debug.Log("Interacted!");
                CheckSolution(pos1,pos2,pos3);
            }
        }
        else
        {
            isNear = false;
        }
    }

    public void CheckSolution(int pos1,int pos2,int pos3)                                       // Check current puzzle positions against solution... Unlock door if solution is correct...
    {

        if (pos1 == solution1 & pos2 == solution2 & pos3 == solution3)
        {
            door.Unlock();
        }
    }


}
