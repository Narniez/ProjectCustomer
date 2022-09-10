using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] public string message;
    public string InteractionMessage => message;
    public Inventory inventory;
    public Camera cameraObject;

    void Update()
    {
        
        RaycastHit hit;
        Ray ray = cameraObject.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag("Door") && inventory.hasKey == true)
            {
                    Debug.Log("Can open door");
                    DoorAnimation Door = objectHit.GetComponentInParent<DoorAnimation>();
                    Door.Interact();            
            }

            if (objectHit.CompareTag("Door") && inventory.hasKey == false)
            {
                Debug.Log("You need a key");
            }

            if (objectHit.CompareTag("LivingRoomDoor") && inventory.hasLivingRoomKey == true)
            {   
                Debug.Log("Living Rooom");
                DoorAnimation Door = objectHit.GetComponentInParent<DoorAnimation>();
                Door.Interact();
            }
        }
    }
}
