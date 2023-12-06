using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerModel : MonoBehaviour
{
    #region Variables

    private PlayerInputs playerInputs;
    
    public Rigidbody rb;
    
    private Vector3 movementVector;
    private Vector2 aimVector;
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
    public float blinkCountdown;
    private bool blinkBool;
    
    //interaction stuff
    public float sphereRadius;
    public float maxDistance;
    public LayerMask interactionLayer;

    private bool canMove;
    public event Action blinkEvent;

    #endregion
    
    void Start()
    {
        ResetTimer();
        GameManager.instance.TaskMenuEvent += InstanceTaskMenuEvent;
        GameManager.instance.PhaseChangerEvent += InstanceOnPhaseChangerEvent;
        
        playerInputs = new PlayerInputs();

        playerInputs.Player.TaskMenu.performed += TaskMenuOnperformed;
        
        playerInputs.Player.movement.performed += MovementOnperformed;
        playerInputs.Player.movement.canceled += MovementOncanceled;
        
        playerInputs.Player.mouse.performed += MouseOnperformed;
        
        playerInputs.Player.blink.performed += BlinkOnperformed;
        
        playerInputs.Player.Interact.performed += InteractOnperformed;
        
        
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }

    private void InstanceTaskMenuEvent(bool obj)
    {
        canMove = obj;
    }

    private void TaskMenuOnperformed(InputAction.CallbackContext obj)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.instance.TaskMenuOpen();
    }

    private void InteractOnperformed(InputAction.CallbackContext obj)
    {
        if (canMove)
        {
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;

            // Perform the spherecast and get all hits
            RaycastHit[] hits = Physics.SphereCastAll(origin, sphereRadius, direction, maxDistance, interactionLayer);

            // Loop through all hits
            foreach (var hit in hits)
            {
                // Check if the hit object has a TaskObject script
                TaskObject taskObject = hit.collider.GetComponent<TaskObject>();
                if (taskObject != null)
                {
                    // Do something with the TaskObject
                    taskObject.TickOffTask();
                }
            }
        }
    }


    #region MovementAndLooking

    private void MouseOnperformed(InputAction.CallbackContext obj)
    {
        if (canMove)
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
    }
    
    private void MovementOnperformed(InputAction.CallbackContext obj)
    {
        if (canMove)
        {
            moveBool = true;
            movementVector = new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y);
        }
    }
    
    private void MovementOncanceled(InputAction.CallbackContext obj)
    {
        moveBool = false;
        //movementVector = Vector3.zero;
    }

    #endregion
    
    void Update()
    {
        if (canMove)
        {
            blinkCountdown -= Time.deltaTime;
        }

        if (blinkCountdown <= 0)
        {
            blinkFunction();
        }
        if (moveBool)
        {
            rb.AddRelativeForce(movementVector * moveSpeed, ForceMode.Acceleration);
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
    
    public void blinkFunction()
    {
        if (canMove)
        {
            if (!blinkBool)
            {
                StartCoroutine(blinkcoroutine());
                blinkEvent?.Invoke();
            }
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
    
    private void InstanceOnPhaseChangerEvent(int phase)
    {
        blinkEvent?.Invoke();
        ManualResetTimer();
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
