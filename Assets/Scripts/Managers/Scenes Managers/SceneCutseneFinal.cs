using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneCutseneFinal : MonoBehaviour
{
    [SerializeField]
    GameObject _dialogueCanvas;
    
    [SerializeField]
    GameObject _timeLine;

    [SerializeField]
    Dialogue _dialogueBeging;

    [SerializeField]
    Dialogue _dialogueDoorRight;

    [SerializeField]
    Dialogue _dialogueAlienRight;

    [SerializeField]
    Dialogue _dialogueDoorLeft;

    [SerializeField]
    Dialogue _dialogueAlienLeft;

    [SerializeField]
    Dialogue _dialogueNoomCenter1;

    [SerializeField]
    Dialogue _dialogueDoorTop;

    [SerializeField]
    Dialogue _dialogueAlienTop;

    [SerializeField]
    Dialogue _dialogueDoorBottom;

    [SerializeField]
    Dialogue _dialogueAlienBottom;

    [SerializeField]
    Dialogue _dialogueAlienAroundNoon;

    [SerializeField]
    Dialogue _dialogueAlienOnNoon;

    [SerializeField]
    Dialogue _dialogueNoonCallOrlon;

    PlayableDirector _timeLineDirector;

    DialogueManager _dialogueManager;
    
    void Awake()
    {
        _timeLineDirector = _timeLine.GetComponent<PlayableDirector>();

        _dialogueManager = _dialogueCanvas.GetComponent<DialogueManager>();
    }

    void ResumeTimeline()
    {
        _timeLineDirector.time = _timeLineDirector.time;

        _timeLineDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }

    void PauseTimeline()
    {
        _timeLineDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    private void StartTimeline()
    {
        _timeLineDirector.Play();
    }

    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Cinematic);

        _dialogueCanvas.SetActive(true);
    }

    void PlayDialogue()
    {
        PauseTimeline();

        _dialogueManager.StartDialogue();
    }

    public void DialogueBegin()
    {
        _dialogueManager.SetDitalogue(_dialogueBeging);

        PlayDialogue();
    }

    public void DialogueDoorRight()
    {
        _dialogueManager.SetDitalogue(_dialogueDoorRight);
        PlayDialogue();
    }

    public void DialogueAlienRight()
    {
        _dialogueManager.SetDitalogue(_dialogueAlienRight);

        PlayDialogue();
    }

    public void DialogueDoorLeft()
    {
        _dialogueManager.SetDitalogue(_dialogueDoorLeft);

        PlayDialogue();
    }

    public void DialogueAlienLeft()
    {
        _dialogueManager.SetDitalogue(_dialogueAlienLeft);

        PlayDialogue();
    }

    public void DialogueNoomCenter1()
    {
        _dialogueManager.SetDitalogue(_dialogueNoomCenter1);

        PlayDialogue();
    }

    public void DialogueDoorTop()
    {
        _dialogueManager.SetDitalogue(_dialogueDoorTop);

        PlayDialogue();
    }

    public void DialogueAlienTop()
    {
        _dialogueManager.SetDitalogue(_dialogueAlienTop);

        PlayDialogue();
    }

    public void DialogueDoorBottom()
    {
        _dialogueManager.SetDitalogue(_dialogueDoorBottom);

        PlayDialogue();
    }

    public void DialogueAlienBottom()
    {
        _dialogueManager.SetDitalogue(_dialogueAlienBottom);

        PlayDialogue();
    }

    public void DialogueAlienAroundNoon()
    {
        _dialogueManager.SetDitalogue(_dialogueAlienAroundNoon);

        PlayDialogue();
    }

    public void DialogueAlienOnNoon()
    {
        _dialogueManager.SetDitalogue(_dialogueAlienOnNoon);

        PlayDialogue();
    }

    public void DialogueNoonCallOrlon()
    {
        _dialogueManager.SetDitalogue(_dialogueNoonCallOrlon);

        PlayDialogue();
    }

    public void OnDialogueEnds()
    {
        ResumeTimeline();
    }

    public void CutsceneEnd()
    {
        SceneManager.LoadScene("EndScene");
    }
}