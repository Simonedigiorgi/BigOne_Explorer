using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{

    public Transform targetTransform;

    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = transform.parent.GetComponent<NavMeshAgent>();
        animator = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            agent.SetDestination(targetTransform.position);
            animator.SetBool("Move", true);





        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            agent.transform.GetChild(2).gameObject.SetActive(true);

            if (agent.hasPath)
            {
                agent.isStopped = true;
                animator.SetBool("Move", false);
            }
        }
    }

    /*private void OnCollisionStay(Collision collision)
    {
        print("Stay");
        if (collision.gameObject.tag == "Player")
        {
            if (agent.hasPath)
            {
                agent.isStopped = true;
                animator.SetBool("Move", false);
            }
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (agent.hasPath)
        {
            agent.isStopped = false;
            animator.SetBool("Move", true);

        }
        agent.transform.GetChild(2).gameObject.SetActive(false);

    }

}
