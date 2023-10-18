using UnityEngine;

[RequireComponent(typeof(Pathfinding))]
public class AlienMovement : MonoBehaviour
{
    [SerializeField]
    float Speed = 5.0f;

    [SerializeField]
    Vector3 Movement;

    Rigidbody2D rb;

    Animator anim;

    Pathfinding path;

    Vector3 Destination;

    bool NeedToMove;

    public Transform pl;

    void Awake()
    {
        anim = GetComponent<Animator>();

        path = GetComponent<Pathfinding>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destination = path.GetDestination();

        NeedToMove = true;
    }

    void AnimationUpdate()
    {
        anim.SetFloat("Speed", Movement.magnitude);

        if (Movement.x != 0)
        {
            anim.SetFloat("Horizontal", Movement.x);

            anim.SetFloat("Vertical", 0);
        }

        if (Movement.y != 0)
        {
            anim.SetFloat("Horizontal", 0);

            anim.SetFloat("Vertical", Movement.y);
        }
    }

    void FixedUpdate()
    {
        if (NeedToMove)
        {
            if(GoToDestination())
            {
                Movement = (Destination - transform.position);

                Movement.z = 0;

                Movement = Movement.normalized;
            }

            else
            {
                Destination = path.GetDestination();

                Movement = (Destination - transform.position);

                Movement.z = 0;

                Movement = Movement.normalized;
            }

            rb.velocity = Movement * Speed * Time.deltaTime;
        }

        else
        {
            rb.velocity = new Vector3(10, 5, 0);
        }

        AnimationUpdate();
    }

    bool GoToDestination()
    {
        Vector3 check = path.CheckDestination();

        check.z = 0;

        if ((transform.position - check).magnitude < 1.5f)
        {
            return false;
        }
            
        else
        {
            return true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            NeedToMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            NeedToMove = true;
        }
    }
}