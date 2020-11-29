using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyCharacterCrontroller : MonoBehaviour
{
    [SerializeField]
    private float accelecForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    [Tooltip("How fast the player turns. 0 = no turning, 1 instant snap turning")]
    [Range(0, 1)]
    private float turnSpeed = 0.1f;
     
    [SerializeField]
    private PhysicMaterial stoppingPhyMaterial, movingPhyMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        Vector3 cameraRelativeInputDirection = GetCameraRelativeInputDirection();
        UpdatePhysicsMaterial();
        Move(cameraRelativeInputDirection);
        RotateToFaceInputDirection(cameraRelativeInputDirection);
    }

    /// <summary>
    /// Turning the character to face the direction it wants to move in. 
    /// </summary>
    /// <param name="movementDirection">The direction the character is trying to move in.</param>
    private void RotateToFaceInputDirection(Vector3 movementDirection)
    {
        if (movementDirection.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed);
        }
    }

    /// <summary>
    /// Movesthe player in a direction based on its max speed and acceleration.
    /// </summary>
    /// <param name="moveDirection">The direction to move in.</param>
    private void Move(Vector3 moveDirection)
    {
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(moveDirection * accelecForce, ForceMode.Acceleration);
        }
    }

    /// <summary>
    /// Updates the phy material to a low friction option if the player is trying to move,
    /// or higher friction option if they are trying to stop.
    /// </summary>
    private void UpdatePhysicsMaterial()
    {
        collider.material = input.magnitude > 0 ? movingPhyMaterial : stoppingPhyMaterial;
    }

    /// <summary>
    /// Uses the input vector to create camera relative version
    /// so the player can move basd on the camera's forward.
    /// </summary>
    /// <returns>returns the camera relative input direction</returns>

    private Vector3 GetCameraRelativeInputDirection()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);
        Vector3 cameraFlattenedForward = Camera.main.transform.forward;
        cameraFlattenedForward.y = 0;
        var cameraRotation = Quaternion.LookRotation(cameraFlattenedForward);

        Vector3 cameraRelativeInputDirection = cameraRotation * inputDirection;
        return cameraRelativeInputDirection;
       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>(); 
    }

   /* private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }*/
}
