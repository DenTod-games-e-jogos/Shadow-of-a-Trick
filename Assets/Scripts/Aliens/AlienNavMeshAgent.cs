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

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Start()
    {
        agent.updateRotation = false;

        agent.updateUpAxis = false;

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

    void InputManagerOnControllerSettingChange(InputManager.ControllerSet state)
    {
        if (state != InputManager.ControllerSet.Movement)
        {
            agent.isStopped = true;
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