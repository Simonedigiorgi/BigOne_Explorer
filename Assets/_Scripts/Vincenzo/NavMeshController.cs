using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour {

    public Transform targetTransform;

    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            agent.SetDestination(targetTransform.position);
            animator.SetBool("Move", true);

        }
        
    }
}
