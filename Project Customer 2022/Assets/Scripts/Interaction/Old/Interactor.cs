using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionMessageUI interactionMessageUI;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private IInteractable interactable;
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if(numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null )
            {
                //if ((!interactionMessageUI.isDisplayed)) interactionMessageUI.SetUp(interactable.InteractionMessage);

                if (Keyboard.current.eKey.wasPressedThisFrame) interactable.Interact(this);
                
            }
        }

        else
        {
            if (interactable != null) interactable = null;
            //if (interactionMessageUI.isDisplayed) interactionMessageUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
