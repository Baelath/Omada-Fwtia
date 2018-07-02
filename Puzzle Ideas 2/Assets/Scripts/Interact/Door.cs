using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable {

    public Transform player;
    public Animator anim;
    public bool locked;
    //public int numOfKeys = 0;
    private bool doorOpen = false;
    private bool IsNear;
    private GUIManagerold guimanager;
    private bool canInteract = true;
    private bool Instantiated = false;
    public GUIStyle style;

    private void Start()
    {
        guimanager = GUIManagerold.getGUIManager();
    }

    public void Interact()
    {
        if (doorOpen & !locked)                                                             // if door is open, close it...
        {
            anim.Play("DoorClose");
            doorOpen = false;
        }
        else if (!locked)                                                                   // if door is closed, open it...
        {
            anim.Play("DoorOpen");
            doorOpen = true;
        }
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position,player.position) < 2f & doorOpen == false)
        {
            IsNear = true;
            if (Input.GetKeyDown(KeyCode.E) & canInteract == true)
            {
                StartCoroutine(WaitTime());
                Interact();
            }
        }
        else if (Vector3.Distance(transform.position,player.position) < 2f & doorOpen == true)
        {
            IsNear = true;
            if (Input.GetKeyDown(KeyCode.E) & canInteract == true)
            {
                StartCoroutine(WaitTime());
                Interact();
            }
        }
        else
        {
            IsNear = false;
        }
    }

    void OnGUI()
    {
        if (IsNear == true & doorOpen == true & locked == false)                                      // player nearby and door OPEN...
        {
            style.normal.textColor = Color.green;
            GUI.Label(new Rect(900, 650, 200, 40), "Press E to Close!",style);
        }
        else if (IsNear == true & doorOpen == false & locked == false)                                // player nearby and door CLOSED...
        {
            style.normal.textColor = Color.green;
            GUI.Label(new Rect(900, 650, 200, 40), "Press E to Open!",style);
        }
        if (IsNear == true & locked == true)
        {
            style.normal.textColor = Color.red;
            GUI.Label(new Rect(900, 650, 200, 40), "Door is locked!", style);
        }
    }

    IEnumerator WaitTime()                                                          // Wait 1 second between interactions (for the animations to play correctly)...                                    
    {
        canInteract = false;
        yield return new WaitForSeconds(1);
        canInteract = true;
    }

    public void Lock()
    {
        locked = true;
    }

    public void Unlock()
    {
        locked = false;
    }
}
