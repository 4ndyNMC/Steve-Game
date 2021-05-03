using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class Speaking : Interactable
{
    public Dialogue Dialogue;

    public override void Interact(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            DialogueManager.Instance.ShowDialogue(Dialogue);
        }
    }

}
/*
started -> performed -> canceled
*/