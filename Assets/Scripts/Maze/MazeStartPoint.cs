using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MazeStartPoint : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    //[SerializeField] private CinemachineVirtualCamera _camera;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _player = Instantiate(_playerPrefab, gameObject.transform.position, Quaternion.identity);
        //_camera.Follow = _player.transform;
    }
}
