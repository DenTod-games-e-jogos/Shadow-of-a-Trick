using UnityEngine;
using Cinemachine;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerPrefab;

    [SerializeField]
    CinemachineVirtualCamera _camera;

    void Start()
    {
        GameObject Player = Instantiate(PlayerPrefab, new Vector2(-14.5f, 5.5f), Quaternion.identity);

        _camera.Follow = Player.transform;
    }
}