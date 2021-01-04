using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject InteractableIcon;
    public Rigidbody2D Rigidbody;
    public float PlayerSpeed;
        
    private Vector2 _inputVector;
    private Vector2 _boxSize = new Vector2(1.0f,1.0f);

    void Start()
    {
        PlayerSpeed = 10.0f;
    }

    void Update()
    {
        Rigidbody.velocity = _inputVector * PlayerSpeed;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,_boxSize,0,Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if(rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact(context);
                    return;
                }
            }
        }
    }
    
    public void ReadMovement(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
    }

    // void OnEnable()
    // {
    //     Input.Enable();
    // }

    // void OnDisable()
    // {
    //     Input.Disable();
    // }
}
