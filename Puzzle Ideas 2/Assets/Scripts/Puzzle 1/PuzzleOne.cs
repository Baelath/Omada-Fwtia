using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOne : MonoBehaviour, IInteractable {

    public Transform player;
    public Animator anim;
    private bool isNear;
    private bool canInteract = true;
    public GUIStyle style;
    private int position = 1;

    public void Interact()
    {
        if (position == 1)
        {
            anim.Play("Pos2");
            position++;
        }
        else if (position == 2)
        {
            anim.Play("Pos3");
            position++;
        }
        else if (position == 3)
        {
            anim.Play("Pos3to1");
            position = 1;
        }
    }

    void OnGUI()
    {
        if (isNear == true)
        {
            style.normal.textColor = Color.green;
            GUI.Label(new Rect(900, 650, 200, 40), "Press E to rotate!", style);
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
        if (Vector3.Distance(transform.position,player.position) < 1.4f)
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

    public int GetPosition()
    {
        return position;
    }
}
