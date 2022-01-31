using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class AlienNavMeshAgent : MonoBehaviour
{
    NavMeshAgent agent;
    Rigidbody2D rb;
    GameObject player;
    Animator anim;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

    }

    void OnEnable()
    {
        InputManager.OnControllerSettingChange += InputManagerOnControllerSettingChange;
    }


    void OnDisable()
    {
        InputManager.OnControllerSettingChange -= InputManagerOnControllerSettingChange;
    }

    private void InputManagerOnControllerSettingChange(InputManager.ControllerSet state)
    {
        if (state != InputManager.ControllerSet.Movement)
        {
            agent.isStopped = true;
            //            agent.SetDestination(transform.position);
        }
        else
        {
            agent.isStopped = false;
        }
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        agent.SetDestination(player.transform.position);

        anim.SetFloat("Speed", agent.velocity.magnitude);
        anim.SetFloat("Horizontal", agent.velocity.x);
        anim.SetFloat("Vertical", agent.velocity.y);

    }
}
