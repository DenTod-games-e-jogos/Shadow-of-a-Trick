using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] 
    GameObject _leftDialogueCanvas;
    
    [SerializeField] 
    GameObject _RightDialogueCanvas;
    
    Dialogue _dialogue;
    
    GameObject _endDialogueCanvas;
    
    DialogueSide _dialogueSide;

    Sprite _dialoguePortrait;
    
    Sprite _dialogueBox;
    
    string _dialogueText;

    public void OnEnable()
    {
        InputManager.Input.Dialogue.Forward.performed += OnSkipDialogue;
        InputManager.Input.Dialogue.Forward.canceled += OnSkipDialogue;
    }

    public void OnDisable()
    {
        InputManager.Input.Dialogue.Forward.performed -= OnSkipDialogue;
        InputManager.Input.Dialogue.Forward.canceled -= OnSkipDialogue;
    }

    private void OnSkipDialogue(InputAction.CallbackContext obj)
    {
    }

    public void SetDitalogue (Dialogue dialogue)
    {
        _dialogue = dialogue;
    }

    public void StartDialogue()
    {
        StartCoroutine(RunDialogue());
    }

    private IEnumerator RunDialogue()
    {
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

            yield return new WaitForSeconds(4.0f);

            SetDitalogue(_dialogue.GetNextDialogue());
        } 
        
        while(_dialogue != null);

        _endDialogueCanvas.SetActive(false);

        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Movement);

    }
}
