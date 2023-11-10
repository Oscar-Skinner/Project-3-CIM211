using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerModel : MonoBehaviour
{
    #region Variables

    private PlayerInputs playerInputs;
    
    public Rigidbody rb;
    
    public Vector3 movementVector;
    public Vector2 aimVector;
    public float moveSpeed;
    public bool moveBool;
    public float maxSpeed;

    //player rotation and transforms
    public Transform playerTransform;
    public Transform cameraTransform;
    private float maxPitch = 90f;
    public float mouseSensitivity;
    private float minPitch = -40f;
    private float playerRotationY = 0f;
    private float yaw = 0f; 
    private float pitch = 0f; 

    //blinking stuff
    public float blinkInterval;
    private float blinkCountdown;
    private bool blinkBool;
    public event Action blinkEvent;

    #endregion
    
    
    void Start()
    {
        ResetTimer();
        
        playerInputs = new PlayerInputs();

        playerInputs.Player.movement.performed += MovementOnperformed;
        playerInputs.Player.movement.canceled += MovementOncanceled;
        
        playerInputs.Player.blink.performed += BlinkOnperformed;
        
        playerInputs.Player.mouse.performed += MouseOnperformed;
        playerInputs.Player.mouse.canceled += MouseOncanceled;
        
        playerInputs.Enable();
    }

    #region MovementAndLooking

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

    #endregion
    
    void Update()
    {
        blinkCountdown -= Time.deltaTime;

        if (blinkCountdown <= 0)
        {
            blinkFunction();
        }
        if (moveBool)
        {
            rb.AddRelativeForce(movementVector * moveSpeed, ForceMode.Force);
        }
        
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    #region BlinkingStuff

    private void BlinkOnperformed(InputAction.CallbackContext obj)
    {
        blinkFunction();
    }
    
    void blinkFunction()
    {
        if (!blinkBool)
        {
            StartCoroutine(blinkcoroutine());
            blinkEvent?.Invoke();
        }
    }

    IEnumerator blinkcoroutine()
    {
        blinkBool = true;
        yield return new WaitForSeconds(.1f);
        
        ManualResetTimer();
        
        GameManager.instance.Forget();
        
        yield return new WaitForSeconds(.1f);
        blinkBool = false;
    }
    
    private void ResetTimer()
    {
        blinkCountdown = blinkInterval;
    }

    private void ManualResetTimer()
    {
        ResetTimer();
    }

    #endregion
    
}
