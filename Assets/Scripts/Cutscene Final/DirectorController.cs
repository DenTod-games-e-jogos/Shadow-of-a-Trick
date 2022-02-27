using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DirectorController : MonoBehaviour
{
    private PlayableDirector director;
private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }
    public void ResumeTimeline()
    {
        director.time = director.time;
        director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
    public void PauseTimeline()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }
    public void StartTimeline()
    {
        director.Play();
    }
}
