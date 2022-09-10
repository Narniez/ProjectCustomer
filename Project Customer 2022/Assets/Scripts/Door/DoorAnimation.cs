using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour, IInteractable
{
    public Animator Door;

    private int p = 0;

    [SerializeField] private string message;

    public string InteractionMessage => message;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Open Door!");
        return true;
    }
    public void Interact()
    {   
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (p == 0)
                {
                    Door.Play("DoorOpen");
                }
                else if (p == 1)
                {
                    Door.Play("DoorClose");
                }
                p = (p + 1) % 2;
            }        
    }
}
