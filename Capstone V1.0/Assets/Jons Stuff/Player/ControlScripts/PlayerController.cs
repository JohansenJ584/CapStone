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
        if (controller.isGrounded)
        {
            controller.Move(fourDirectionalVelocity * Time.deltaTime);
        }
        else
        {
            controller.Move((fourDirectionalVelocity + Vector3.down) * Time.deltaTime);
        }
    }

    public void DoJump()
    {
        print("grounded :" + controller.isGrounded);
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);

    }
}
