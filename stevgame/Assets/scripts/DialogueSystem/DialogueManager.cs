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
    private Dialogue _dialogue;
    private int _currentLine;
    private bool _isTyping;

    public static DialogueManager Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
        _currentLine = 0;
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        _dialogue = dialogue;

        Input.SwitchCurrentActionMap("UI");
        DialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(_dialogue.Lines[0]));
    }

    public void SkipDialogue(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(_isTyping)
            {
                DialogueText.text = _dialogue.Lines[_currentLine];
                _isTyping = false;
            }
            else
            {
                _currentLine++;
                if(_currentLine < _dialogue.Lines.Count)
                {
                    StartCoroutine(TypeDialogue(_dialogue.Lines[_currentLine]));
                }
                else
                {
                    _currentLine = 0;
                    CloseDialogue();
                }
            }
        }
    }

    private IEnumerator TypeDialogue(string line)
    {
        DialogueText.text = "";
        _isTyping = true;
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

    private void CloseDialogue()
    {
        Input.SwitchCurrentActionMap("Gameplay");
        DialogueBox.SetActive(false);
    }
}
