using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pathfinding))]
public class AlienMovement : MonoBehaviour
{
    [SerializeField] float _Speed = 100;
    [SerializeField] Vector3 _Movement;
    Rigidbody2D _Rigidbody;
    Animator _Anim;
    Pathfinding _pathfinding;
    Vector3 _destination;
    bool _needToMove;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        _Anim = GetComponent<Animator>();
        _pathfinding = GetComponent<Pathfinding>();
        
    }

    private void Start()
    {
        _destination = _pathfinding.GetDestination();
        _needToMove = true;
    }

    private void AnimationUpdate()
    {
        //_Anim.SetFloat("Horizontal", _Movement.x);
        //_Anim.SetFloat("Vertical", _Movement.y);
        _Anim.SetFloat("Speed", _Movement.magnitude);
        if (_Movement.x != 0)
        {
            _Anim.SetFloat("Horizontal", _Movement.x);
            _Anim.SetFloat("Vertical", 0);
        }
        if (_Movement.y != 0)
        {
            _Anim.SetFloat("Horizontal", 0);
            _Anim.SetFloat("Vertical", _Movement.y);
        }
    }
    private void FixedUpdate()
    {
        if (_needToMove)
        {
            if (KeepMovingToActualDestination())
            {
                _Movement = (_destination - transform.position);
                _Movement.z = 0;
                _Movement = _Movement.normalized;
            }
            else
            {
                _destination = _pathfinding.GetDestination();
                _Movement = (_destination - transform.position);
                _Movement.z = 0;
                _Movement = _Movement.normalized;
            }
            _Rigidbody.velocity = _Movement * _Speed * Time.deltaTime;
        }
        else
        {
            _Rigidbody.velocity = new Vector3(0,0,0);
        }
        AnimationUpdate();
    }

    private bool KeepMovingToActualDestination()
    {
        Vector3 _check = _pathfinding.CheckDestination();
        _check.z = 0;
        if ((transform.position - _check).magnitude < 1.4f)
            return false;
        else
            return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _needToMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _needToMove = true;
        }
    }
}