using UnityEngine;

public class Recorder : MonoBehaviour
{
    AudioSource VoiceOrlom;

    void Awake()
    {
        VoiceOrlom = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D recorder)
    {
        VoiceOrlom.Play();

        print("Orlom voice played");
    }
}