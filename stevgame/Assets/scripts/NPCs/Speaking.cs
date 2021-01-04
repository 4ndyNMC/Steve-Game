using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class Speaking : Interactable
{
    public Sprite Talking;
    public Sprite NotTalking;
    public Dialogue Dialogue;

    private SpriteRenderer _spriteRenderer;
    private bool _isTalking;

    public override void Interact(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _isTalking = true;
            // ChangeSprite();
            DialogueManager.Instance.ShowDialogue(Dialogue);
        }
    }

    public void ChangeSprite()
    {
        if(_isTalking)
        {
            _spriteRenderer.sprite = NotTalking;
        }
        else
        {
            _spriteRenderer.sprite = Talking;
        }

        _isTalking = false;
    }

    public void SetTalking(bool isTalking)
    {
        _isTalking = isTalking;
        if(isTalking) _spriteRenderer.sprite = Talking;
        else _spriteRenderer.sprite = NotTalking;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = NotTalking;
    }

    // private IEnumerator Talking()
    // {
    //     ChangeSprite();
    //     yield return new WaitForSeconds(.5f);
    // }

}
