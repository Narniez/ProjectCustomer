using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovementControls2 : MonoBehaviour
{
    public CharacterController controller;

    public Camera mainCamera;

    [Header("Variables")]
    [Range(0f, 20f)]
    public float speed = 10f;
    public float gravity = -9.81f;
    public static bool canMove = true;

    private float x;
    private float z;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Interactable")]
    public Vector3 interactionRaypoint = default;
    public float interactionDistance = default;
    public LayerMask interactionLayer = default;
    private Interactable currentInteractable;


    private Vector3 velocity;
    private bool isGrounded;

    public bool canInteract = true;

    [Header("KeyBinds")]
    public KeyCode interactKey = KeyCode.F;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (canMove)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        else
        {
            x = 0f;
            z = 0f;
        }

        if (canInteract)
            HandleInteractionCheck();
        HandleInteractionInput();

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    //interactions

    void HandleInteractionCheck()
    {
        if (Physics.Raycast(mainCamera.ViewportPointToRay(interactionRaypoint), out RaycastHit hit, interactionDistance))
        {
            if (hit.collider.gameObject.layer == 9 && (currentInteractable == null || hit.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out currentInteractable);

                if (currentInteractable)
                {
                    currentInteractable.OnFocus();
                }               
            }
            else if (currentInteractable)
            {
                currentInteractable.OnLoseFocus();
                currentInteractable = null;
            }
        }
    }
    private void HandleInteractionInput()
    {
        if (Input.GetKeyDown(interactKey) && currentInteractable != null && Physics.Raycast(mainCamera.ViewportPointToRay(interactionRaypoint), out RaycastHit hit, interactionLayer))
        {
            Debug.Log("INTERACTION");
            currentInteractable.OnInteract();
        }
    }
}