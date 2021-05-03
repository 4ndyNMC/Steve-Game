using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float PlayerSpeed;
        
    private Vector2 _inputVector;
    private Vector2 _boxSize;

    void Start()
    {
        PlayerSpeed = 10.0f;
        _boxSize = new Vector2(1.0f,1.0f);
    }

    void Update()
    {
        Rigidbody.velocity = _inputVector * PlayerSpeed;
    }
    
    public void ReadMovement(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        RaycastHit2D[] objectsHit = Physics2D.BoxCastAll(transform.position,_boxSize,0,Vector2.zero);

        if(objectsHit.Length > 0)
        {
            foreach(RaycastHit2D hitObject in objectsHit)
            {
                if(hitObject.transform.GetComponent<Interactable>())
                {
                    hitObject.transform.GetComponent<Interactable>().Interact(context);
                    return;
                }
            }
        }
    }
}
