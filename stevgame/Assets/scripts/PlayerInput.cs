using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float PlayerSpeed;
    public InputAction Input; // no need to initialize..why?
    
    private Vector2 _inputVector;

    void Start()
    {
        PlayerSpeed = 10.0f;
    }

    void Update()
    {
        _inputVector = Input.ReadValue<Vector2>();
        Rigidbody.velocity = _inputVector * PlayerSpeed;
    }

    void OnEnable()
    {
        Input.Enable();
    }

    void OnDisable()
    {
        Input.Disable();
    }
}
