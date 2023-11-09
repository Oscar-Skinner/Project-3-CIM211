using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerModel : MonoBehaviour
{
    private PlayerInputs playerInputs;

    public Transform playerTransform;
    public Transform cameraTransform;
    public Rigidbody rb;
    
    public Vector3 movementVector;
    public Vector2 aimVector;

    public float moveSpeed;
    public bool moveBool;
    public float maxSpeed;

    private float maxPitch = 90f;
    public float mouseSensitivity;
    private float minPitch = -40f;
    
    private float playerRotationY = 0f;
    
    private float yaw = 0f; // For player rotation (side to side)
    private float pitch = 0f; // For camera rotation (up and down)

    private bool blinkBool;
    private float blinkInteraval;
    public event Action blinkEvent;
    
    void Start()
    {
        playerInputs = new PlayerInputs();

        playerInputs.Player.movement.performed += MovementOnperformed;
        playerInputs.Player.movement.canceled += MovementOncanceled;
        
        playerInputs.Player.blink.performed += BlinkOnperformed;
        
        playerInputs.Player.mouse.performed += MouseOnperformed;
        playerInputs.Player.mouse.canceled += MouseOncanceled;
        
        playerInputs.Enable();
    }

    private void BlinkOnperformed(InputAction.CallbackContext obj)
    {
        if (!blinkBool)
        {
            blinkFunction();
        }
    }

    private void MouseOnperformed(InputAction.CallbackContext obj)
    {        
        aimVector = obj.ReadValue<Vector2>();
        
        yaw += aimVector.x * mouseSensitivity;   // Adjust the yaw based on horizontal mouse movement.
        pitch -= aimVector.y * mouseSensitivity; // Adjust the pitch based on vertical mouse movement.

        // Limit the pitch to prevent the camera from flipping.
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Apply rotations to the player and camera.
        playerTransform.rotation = Quaternion.Euler(0, yaw, 0); // Player's rotation (yaw).
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0); // Camera's rotation (pitch).
    }
    
    private void MouseOncanceled(InputAction.CallbackContext obj)
    {
        //aimVector = Vector3.zero;
    }
    
    private void MovementOnperformed(InputAction.CallbackContext obj)
    {        
        moveBool = true;
        movementVector = new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y);
    }
    
    private void MovementOncanceled(InputAction.CallbackContext obj)
    {
        moveBool = false;
        //movementVector = Vector3.zero;
    }

    void blinkFunction()
    {
        StartCoroutine(blinkcoroutine());
        blinkEvent?.Invoke();
    }

    IEnumerator blinkcoroutine()
    {
        blinkBool = true;
        yield return new WaitForSeconds(.5f);
        blinkBool = false;
    }
    
    void Update()
    {
        if (moveBool)
        {
            rb.AddRelativeForce(movementVector * moveSpeed, ForceMode.Force);
        }
        
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
