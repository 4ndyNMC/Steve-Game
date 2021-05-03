using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void DialogueClose();
    public static event DialogueClose OnDialogueClose;

    
}
