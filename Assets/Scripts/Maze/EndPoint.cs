using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour 
{
    [SerializeField]
    string NextScene;

    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}