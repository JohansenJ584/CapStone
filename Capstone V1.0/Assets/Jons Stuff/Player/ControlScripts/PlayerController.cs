using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    [SerializeField]
    CharacterController controller;

    Vector2 fourDirectionInput;

    [SerializeField]
    float jumpPower;


    public void ReceiveInput(Vector2 _fourDirectionInput)
    {
        fourDirectionInput = _fourDirectionInput;
    }

    private void Update()
    {
        Vector3 fourDirectionalVelocity = (transform.right * fourDirectionInput.x + transform.forward * fourDirectionInput.y) * speed;
        controller.SimpleMove(fourDirectionalVelocity * Time.deltaTime);
        controller.Move(fourDirectionalVelocity * Time.deltaTime);

    }

    public void DoJump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);

    }
}
