using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwo : MonoBehaviour, IInteractable {

    public Transform player;
    public Animator anim;
    private bool isNear;
    private bool canInteract = true;
    public GUIStyle style;
    private bool active = false;

    public void Interact()
    {
        if (active)
        {
            Debug.Log("Retracting!");
            anim.Play("ExtensionRetract");
            active = false;
        }
        else
        {
            Debug.Log("Extending!");
            anim.Play("ExtensionExtend");
            active = true;
        }
    }

    void OnGUI()
    {
        if (isNear == true & active == true)
        {
            GUI.Label(new Rect(900, 650, 200, 40), "Press E to deactivate!", style);
        }
        else if (isNear == true & active == false)
        {
            GUI.Label(new Rect(900, 650, 200, 40), "Press E to activate!", style);
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
        if (Vector3.Distance(transform.position, player.position) < 1.2f)
        {
            isNear = true;
            if (Input.GetKeyDown(KeyCode.E) & canInteract == true)
            {
                StartCoroutine(WaitTime());
                Interact();
            }
        }
        else
        {
            isNear = false;
        }
    }

    public int GetActive()
    {
        if (active)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
