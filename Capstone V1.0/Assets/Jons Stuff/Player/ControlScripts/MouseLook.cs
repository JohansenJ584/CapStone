using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    float xScrollFactor;

    [SerializeField]
    [Range(0, 10)]
    float yScrollFactor;

    float mouseX, mouseY;

    float xRotation = 0f;

    float xClamp = 85f;

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * xScrollFactor;
        mouseY = mouseInput.y * yScrollFactor;
    }

    private void Update()
    {
        print(new Vector2(mouseX, mouseY));

        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        transform.eulerAngles = targetRotation;
    }
}
