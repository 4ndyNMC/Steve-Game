using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text DialogueText;
    public PlayerInput Input;

    [SerializeField] private float _lettersPerSecond;
    private Dialogue dialogue;
    private int _currentLine = 0;
    private bool _isTyping;

    public static DialogueManager Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;

        Input.SwitchCurrentActionMap("UI");
        DialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialogue.Lines[0]));
    }

    public void SkipDialogue(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(_isTyping)
            {
                DialogueText.text = dialogue.Lines[_currentLine];
                _isTyping = false;
            }
            else
            {
                _currentLine++;
                if(_currentLine < dialogue.Lines.Count)
                {
                    StartCoroutine(TypeDialogue(dialogue.Lines[_currentLine]));
                }
                else
                {
                    _currentLine = 0;
                    CloseDialogue();
                }
            }
        }
    }

    private void CloseDialogue()
    {
        Input.SwitchCurrentActionMap("Gameplay");
        DialogueBox.SetActive(false);
    }

    private IEnumerator TypeDialogue(string line)
    {
        _isTyping = true;
        DialogueText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            if(_isTyping)
            {
                DialogueText.text += letter;
                yield return new WaitForSeconds(1f/_lettersPerSecond);
            }
            else
            {
                break;
            }
        }
        _isTyping = false;
    }
}
