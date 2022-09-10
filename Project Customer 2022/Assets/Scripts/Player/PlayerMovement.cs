using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    Camera cameraPosition;

    [Header("Movement Speed")]
    [Range(0f, 20f)]
    public float speed = 10f;
    public float gravity = -9.81f;
    public static bool canMove = true;
    private float x;
    private float z;

    [Header("Interactable")]
    public Vector3 interactRayPoint = default;
    public float interactDistance = default;
    public LayerMask interactionLayer = default;
    private Interactable curentInteractable;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;

    [Header("Keybings")]
    public KeyCode interactKey = KeyCode.F;

    [Header("Can Use")]
    bool canInteract = true;

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
        {
            HandleInteractionCheck();
            HandleInteractionInput();
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    //Interaction
    void HandleInteractionCheck()
    {
        if (Physics.Raycast(cameraPosition.ViewportPointToRay(interactRayPoint), out RaycastHit hit, interactDistance))
        {
            if (hit.collider.gameObject.layer == 9 && (curentInteractable == null || hit.collider.gameObject.GetInstanceID() != curentInteractable.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out curentInteractable);

                if (curentInteractable)
                    curentInteractable.OnFocus();
            }
            else if (curentInteractable)
            {
                curentInteractable.OnLoseFocus();
                curentInteractable = null;
            }
        }
    }

    void HandleInteractionInput()
    {
        if(Input.GetKeyDown(interactKey) && curentInteractable != null && Physics.Raycast(cameraPosition.ViewportPointToRay(interactRayPoint), out RaycastHit hit, interactDistance, interactionLayer))
        {
            Debug.Log("NIgagagagaga niga");
            curentInteractable.OnInteract();
        }
    }
}
