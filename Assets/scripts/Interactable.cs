using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    
    public abstract void Interact(InputAction.CallbackContext context);

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
}
