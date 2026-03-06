using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Animator animator;
    public Animator Animator => animator;
    [SerializeField] private Pet _pet;
    public Pet Pet => _pet;
    [SerializeField] private float _roamingDistance = 100f;
    public float RoamingDistance => _roamingDistance;
    public GameObject a;
    public GameObject b;
    
    void Start()
    {
        _pet = GetComponent<Pet>();
        agent = GetComponent<NavMeshAgent>();
        if (GetComponent<Animator>()!=null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( targetPosition && agent.transform.position != targetPosition.position)
        {
             agent.destination = targetPosition.position;
        }
    }
}
