using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] 
    GameObject _leftDialogueCanvas;
    
    [SerializeField] 
    GameObject _RightDialogueCanvas;
    
    Dialogue _dialogue;
    
    GameObject _endDialogueCanvas;
    
    DialogueSide _dialogueSide;
    
    [SerializeField]
    UnityEvent onDialogueEnds;

    float dialogueTimerCounter;

    float dialogueMaxTime;

    InputManager.ControllerSet lastSettings;

    public void OnEnable()
    {
        dialogueMaxTime = 4.0f;

        InputManager.Input.Dialogue.Forward.performed += OnSkipDialogue;
    }

    public void OnDisable()
    {
        InputManager.Input.Dialogue.Forward.performed -= OnSkipDialogue;
    }

    void OnSkipDialogue(InputAction.CallbackContext obj)
    {
        dialogueTimerCounter = Mathf.Infinity;
    }

    public void SetDitalogue (Dialogue dialogue)
    {
        _dialogue = dialogue;
    }

    public void StartDialogue()
    {
        StartCoroutine(RunDialogue());
    }

    IEnumerator RunDialogue()
    {
        lastSettings = InputManager.Instance.ActualSettings;

        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Dialogue);
        do
        {
            if (_dialogue.GetSpeakerSide() == Dialogue.Side.Left)
            {
                if (_endDialogueCanvas != null)
                {
                    _endDialogueCanvas.SetActive(false);
                }

                _endDialogueCanvas = _leftDialogueCanvas;
            }

            else
            {
                if (_endDialogueCanvas != null)
                {
                    _endDialogueCanvas.SetActive(false);
                }
                    
                _endDialogueCanvas = _RightDialogueCanvas;
            }
            
            _dialogueSide = _endDialogueCanvas.GetComponent<DialogueSide>();
            
            _dialogueSide.SetDialogueBox(_dialogue.GetDialogueBox());
            
            _dialogueSide.SetSpeakerPortrait(_dialogue.GetSpeakerPortrait());
            
            _dialogueSide.SetSpeakerText(_dialogue.GetSpeakText());
            
            if (_dialogue.GetNextDialogue() == null)
            {
                _dialogueSide.HasMoreDialogue(false);
            }
                
            else
            {
                _dialogueSide.HasMoreDialogue(true);
            }
            
            _endDialogueCanvas.SetActive(true);

            yield return StartCoroutine("TimeToWaitOrTap");

            SetDitalogue(_dialogue.GetNextDialogue());
        } 
        
        while(_dialogue != null);

        _endDialogueCanvas.SetActive(false);

        onDialogueEnds.Invoke();

        InputManager.Instance.UpdateControllerSet(lastSettings);
    }

    IEnumerator TimeToWaitOrTap()
    {
        dialogueTimerCounter = 0.0f;

        while (dialogueTimerCounter < dialogueMaxTime)
        {
            dialogueTimerCounter += Time.deltaTime;

            yield return null;
        }
    }
}