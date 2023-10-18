using UnityEngine;
using UnityEngine.Playables;

public class DirectorController : MonoBehaviour
{
    PlayableDirector director;
    
    void Awake()
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