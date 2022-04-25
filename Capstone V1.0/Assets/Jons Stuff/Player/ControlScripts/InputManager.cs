using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    MouseLook mouseLook;


    PlayerControls controls;
    PlayerControls.MovementActions movement;

    Vector2 fourDirectionInput;
    Vector2 mouseInput;
    private void Awake()
    {
        controls = new PlayerControls();
        movement = controls.Movement;

        movement.FourDirectionMovement.performed += ctx => fourDirectionInput = ctx.ReadValue<Vector2>();


        movement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        movement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        // movement.Jump.performed += _ => playerController.DoJump();


    }

    private void OnEnable()
    {
        controls.Enable();  
    }

    private void FixedUpdate()
    {
        playerController.ReceiveInput(fourDirectionInput);
        mouseLook.ReceiveInput(mouseInput);
    }
}
