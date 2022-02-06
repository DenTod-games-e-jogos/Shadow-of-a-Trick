using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInteriorOvini : MonoBehaviour
{
    [SerializeField]
    GameObject _dialogueCanvas;

    [SerializeField]
    Dialogue _dialogue;

    DialogueManager _dialogueManager;
    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Dialogue);

        _dialogueManager = _dialogueCanvas.GetComponent<DialogueManager>();

        _dialogueCanvas.SetActive(true);
        _dialogueManager.SetDitalogue(_dialogue);
        _dialogueManager.StartDialogue();

    }

    public void OnDialogueEnds()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Movement);
        _dialogueCanvas.SetActive(false);
    }
}