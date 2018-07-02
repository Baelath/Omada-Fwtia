using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{

    public Transform player;
    public Animator anim;
    private bool isNear;
    private bool canInteract = true;
    public GUIStyle style;
    public PuzzleOne left;
    public PuzzleOne middle;
    public PuzzleOne right;
    public Door door;
    private int pos1;
    private int pos2;
    private int pos3;
    [Header("Puzzle Solution Settings")]
    public int solution1;
    public int solution2;
    public int solution3;

    private void Start()
    {
        //door = GameObject.Find("PuzzleDoor").GetComponent<Door>();
        //left = GameObject.Find("Left").GetComponent<PuzzleOne>();
        //middle = GameObject.Find("Middle").GetComponent <PuzzleOne>();
        //right = GameObject.Find("Right").GetComponent<PuzzleOne>();
    }


    public void Interact()
    {
        anim.Play("ButtonPress", -1, 0f);
        Debug.Log("Animation played!");
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

    public void CheckSolution(int pos1,int pos2,int pos3)
    {

        if (pos1 == solution1 & pos2 == solution2 & pos3 == solution3)
        {
            door.Unlock();
        }
    }


}
