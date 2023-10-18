using UnityEngine;

public class SceneStage3 : MonoBehaviour
{
    [SerializeField]
    GameObject _dialogueCanvas;

    [SerializeField]
    Dialogue _dialogue;

    DialogueManager _dialogueManager;

    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Movement);

        _dialogueManager = _dialogueCanvas.GetComponent<DialogueManager>();

        _dialogueCanvas.SetActive(true);

        _dialogueManager.SetDitalogue(_dialogue);
        
        _dialogueManager.StartDialogue();
    }
}