using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float minSpeed = 10f;        // stick full left
    public float maxSpeed = 40f;        // stick full right
    public float rotationSpeed = 60f;   // degrees per second

    public float verticalInput;         // stick Y, -1 to 1
    public float horizontalInput;       // stick X, -1 to 1

    void Update()
    {
        // Read the left stick straight from the connected controller
        Gamepad pad = Gamepad.current;
        Vector2 stick = pad != null ? pad.leftStick.ReadValue() : Vector2.zero;

        verticalInput = stick.y;
        horizontalInput = stick.x;

        //left slows the plane, right speeds it up
        float speed = Mathf.Lerp(minSpeed, maxSpeed, (horizontalInput + 1f) / 2f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // vertical movemnt on y axis with stick Y sets how level the nose pitches
        transform.Rotate(Vector3.right * rotationSpeed * verticalInput * Time.deltaTime);
    }
}
