using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerModel : MonoBehaviour
{
    private PlayerInputs playerInputs;

    public Rigidbody rb;
    public Vector3 movementVector;

    public float moveSpeed;
    public bool moveBool;
    public float maxSpeed;
    
    void Start()
    {
        playerInputs = new PlayerInputs();

        playerInputs.Player.movement.performed += MovementOnperformed;
        playerInputs.Player.movement.canceled += MovementOncanceled;
        
        playerInputs.Enable();
    }

    private void MovementOnperformed(InputAction.CallbackContext obj)
    {
        movementVector = new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y);

        moveBool = true;
    }
    
    private void MovementOncanceled(InputAction.CallbackContext obj)
    {
        moveBool = false;
        movementVector = Vector3.zero;
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
