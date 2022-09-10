using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    public Camera cameraObject;

    void Update()
    {
        RaycastHit hit;
        Ray ray = cameraObject.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag("Laptop")) // if looking at laptop
            {
                if (Input.GetKeyDown(KeyCode.E)) // if E has been pressed
                {
                    
                }
                    /*
                    look at laptop
                    press e
                    disable movement
                    enable laptop UI
                
                    wait x seconds
                
                    disable laptop UI
                    enable movement
                    */
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        // before
        PlayerMovement.canMove = false; // turn off player movement
                                        //enable ui

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        // after
        //disbale ui
        PlayerMovement.canMove = true; // turn off player movement
    }
}