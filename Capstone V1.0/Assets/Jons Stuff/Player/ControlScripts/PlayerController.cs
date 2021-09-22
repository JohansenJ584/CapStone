using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    [SerializeField]
    CharacterController controller;

    Vector2 fourDirectionInput;


    public void ReceiveInput(Vector2 _fourDirectionInput)
    {
        fourDirectionInput = _fourDirectionInput;

    }

    private void Update()
    {
        Vector3 fourDirectionalVelocity = (transform.right * fourDirectionInput.x + transform.forward * fourDirectionInput.y) * speed;
        controller.Move(fourDirectionalVelocity * Time.deltaTime);
    }
}
