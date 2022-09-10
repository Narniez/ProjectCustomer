using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string message;
    [SerializeField] string keyType;
    public Inventory inventory;
    public string InteractionMessage => message;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("A key!");
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Colliding");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Colliding");
            inventory.hasLivingRoomKey = true;
            Debug.Log(inventory.hasLivingRoomKey);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
