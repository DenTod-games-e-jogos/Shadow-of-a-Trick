using UnityEngine;

public class MazeStartPoint : MonoBehaviour
{
    [SerializeField] 
    GameObject _playerPrefab;

    void Start()
    {
        GameObject _player = Instantiate(_playerPrefab, gameObject.transform.position, Quaternion.identity);
    }
}