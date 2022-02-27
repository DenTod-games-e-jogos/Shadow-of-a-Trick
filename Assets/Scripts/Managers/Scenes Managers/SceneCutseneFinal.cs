using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
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

    [SerializeField]
    SignalAsset _dialogueEnd;

    PlayableDirector _timeLineDirector;


    DialogueManager _dialogueManager;
    
    private void Awake()
    {
        _timeLineDirector = _timeLine.GetComponent<PlayableDirector>();
        _dialogueManager = _dialogueCanvas.GetComponent<DialogueManager>();
    }
    public void ResumeTimeline()
    {
        _timeLineDirector.time = _timeLineDirector.time;
        _timeLineDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
    public void PauseTimeline()
    {
        _timeLineDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }
    public void StartTimeline()
    {
        _timeLineDirector.Play();
    }

    void Start()
    {
        InputManager.Instance.UpdateControllerSet(InputManager.ControllerSet.Cinematic);

        _dialogueCanvas.SetActive(true);
        _dialogueManager.SetDitalogue(_dialogueBeging);
        _dialogueManager.StartDialogue();

    }
}
