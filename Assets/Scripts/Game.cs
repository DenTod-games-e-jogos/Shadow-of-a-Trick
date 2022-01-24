using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

public class Game : MonoBehaviour
{
    public Text Intro;

    void Start()
    {
        StartCoroutine(ShowQuest());
    }

    IEnumerator ShowQuest()
    {
        Intro.text = "a shadow is following your memories...";

        yield return new WaitForSeconds(2.0f);

        Intro.enabled = false;
    }
}