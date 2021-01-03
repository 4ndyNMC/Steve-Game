using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class CanTalk : Interactable
{
    public Sprite Talking;
    public Sprite NotTalking;

    private SpriteRenderer _spriteRenderer;
    private bool _isTalking;

    public override void Interact(InputAction.CallbackContext context)
    {
        if(_isTalking) _spriteRenderer.sprite = NotTalking;
        else _spriteRenderer.sprite = Talking;

        _isTalking = !_isTalking;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = NotTalking;
    }
}
