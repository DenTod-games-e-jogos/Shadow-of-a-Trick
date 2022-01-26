using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager2 : MonoBehaviour
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
            
            if (_dialogue == null)
            {
                _endDialogueCanvas.SetActive(false);
            }
            
            else
            {
                SetDitalogue(_dialogue.GetNextDialogue());
            }
        } 
        
        while(_dialogue != null);
    }
}
