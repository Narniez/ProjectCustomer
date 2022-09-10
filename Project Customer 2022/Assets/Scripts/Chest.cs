using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable 
{
    [SerializeField] private string message;

    public string InteractionMessage => message;

    public bool Interact (Interactor interactor)
    {
        Debug.Log("Opening chest!");
        return true;
    }
                
}
