using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class AnimalRigitbodyMovement : MonoBehaviour
{    
    [SerializeField] private float _acceleration = 3;
    [SerializeField] private float _movementSpeed = 4;

    private Rigidbody _rigidbody;
    private Vector3 _movementVector;    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {        
        _movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
    }  

    private void FixedUpdate()
    {
        bool isAccelerate = false;

        if (Input.GetKey(KeyCode.LeftShift))
            isAccelerate = true;

        _rigidbody.MovePosition(transform.position + _movementVector * (_movementSpeed + _acceleration * Convert.ToInt32(isAccelerate)) * Time.fixedDeltaTime);
    }
}
