using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour {

    private float Keyfordoor1 = 0;
    private float Keyfordoor2 = 0;
    int door = 0;
    int door2 = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo,8);

            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Key")
                {
                    Debug.Log("You got the key");

                    Keyfordoor1 = 1;
                    
                }
                else if (hitInfo.transform.gameObject.tag == "Door for Key")
                {
                   
                    Debug.Log("BEFORE CHECKING");
                    if (Keyfordoor1 == 1)
                    {
                        Debug.Log("Door Opens");
                        
                        if (door == 0)
                        {
                            GameObject.FindGameObjectWithTag("Holder1").transform.Rotate(0, 0, 90);
                            GameObject.FindGameObjectWithTag("Holder2").transform.Rotate(0, 0, -90);
                            door = 1;
                            Debug.Log("Change value to 1");
                        }
                        else if (door == 1)
                        {
                            GameObject.FindGameObjectWithTag("Holder1").transform.Rotate(0, 0, -90);
                            GameObject.FindGameObjectWithTag("Holder2").transform.Rotate(0, 0, 90);
                            door = 0;
                            Debug.Log("Change value to 0");
                        }

                    }
                    else
                    {
                        Debug.Log("Door is locked");
                    }


                }
                // FOR DOOR 2
                else if (hitInfo.transform.gameObject.tag == "Key2")
                {
                    Debug.Log("You got the key2");
                    Keyfordoor2 = 1;
                }
                else if (hitInfo.transform.gameObject.tag == "Door for Key2")
                {
                    if (door2 == 0)
                    {
                        GameObject.FindGameObjectWithTag("Holder3").transform.Rotate(0, 0, 90);
                        GameObject.FindGameObjectWithTag("Holder4").transform.Rotate(0, 0, -90);
                        door2 = 1;
                        Debug.Log("Change value to 1");
                    }
                    else if (door2 == 1)
                    {
                        GameObject.FindGameObjectWithTag("Holder3").transform.Rotate(0, 0, -90);
                        GameObject.FindGameObjectWithTag("Holder4").transform.Rotate(0, 0, 90);
                        door2 = 0;
                        Debug.Log("Change value to 0");
                    }
                }


            }
            else
            {
                Debug.Log("No hit");
            }
        }

        //Debug.Log("Mouse is down");

    }
    // PREPEI NA DW PWS DOULEUEI AUTO KAI AN MPORW NA VALW OLA TA PRAGMATA APO THN UPDATE EDW

    public void OnMouseDown()
    {
       
    }
    public void GotKey()
    {
        Keyfordoor1 = 1;
    }
}
