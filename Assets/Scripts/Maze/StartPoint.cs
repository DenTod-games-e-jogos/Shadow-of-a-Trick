using UnityEngine;
using Cinemachine;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerPrefab;

    [SerializeField]
    CinemachineVirtualCamera camera;

    void Start()
    {
        GameObject Player = Instantiate(PlayerPrefab, new Vector2(-14.5f, 5.5f), Quaternion.identity);

        camera.Follow = Player.transform;
    }
}