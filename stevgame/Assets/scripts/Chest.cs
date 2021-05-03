using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : Interactable
{
    public Animator Animate;
    public Dialogue Dialogue;

    public override void Interact(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Animate.SetBool("IsOpen", true);
            // EventManager.OnDialogueClose += Animate.SetBool("IsOpen",false);
            DialogueManager.Instance.ShowDialogue(Dialogue);
        }
    }

    // private void SetIsOpen(bool isOpen)
    // {
    //     Animate.SetBool("IsOpen", isOpen);
    // }

}
