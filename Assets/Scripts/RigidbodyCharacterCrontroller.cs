using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacterCrontroller : MonoBehaviour
{
    [SerializeField]
    private float accelecForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

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
        var inputDirection = new Vector3(input.x, 0, input.y);

        if(inputDirection.magnitude > 0)
        {
            collider.material = movingPhyMaterial;

        }
        else
        {
            collider.material = stoppingPhyMaterial;
        }
        if(rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(inputDirection * accelecForce, ForceMode.Acceleration);
        }
        
    }
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
