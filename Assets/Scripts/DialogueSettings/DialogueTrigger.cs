using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] 
    GameObject _dialogueCanvas;
    
    [SerializeField] 
    Dialogue _dialogue;
    
    DialogueManager _dialogueManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _dialogueCanvas.SetActive(true);
            
            _dialogueManager = _dialogueCanvas.GetComponent<DialogueManager>();
            
            _dialogueManager.SetDitalogue(_dialogue);
            
            _dialogueManager.StartDialogue();
        }
    }
}