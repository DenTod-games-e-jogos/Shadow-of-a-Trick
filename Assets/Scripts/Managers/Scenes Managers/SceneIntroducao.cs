using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class SceneIntroducao : MonoBehaviour
{
    [SerializeField]
    GameObject _dialogueCanvas;

    [SerializeField]
    Dialogue _dialogue;

    [SerializeField]
    GameObject _timeLine;

    [SerializeField]
    SignalAsset _dialogueEnd;

    PlayableDirector _timeLineDirector;

    DialogueManager _dialogueManager;

    void Awake()
    {
        Cursor.visible = false;
    }

    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Cinematic);

        _timeLineDirector = _timeLine.GetComponent<PlayableDirector>();

        _dialogueManager = _dialogueCanvas.GetComponent<DialogueManager>();
    }

    public void StartDialogue()
    {
        _dialogueCanvas.SetActive(true);

        _dialogueManager.SetDitalogue(_dialogue);
        
        _dialogueManager.StartDialogue();
    }
    
    public void OnDialogueEnds()
    {
        _timeLineDirector?.Resume();
        
        _dialogueCanvas.SetActive(false);
    }

    public void OnCinematicEnds()
    {
        SceneManager.LoadScene("InteriorOvni");
    }
}