using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    //
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Animator _animator;
    [SerializeField] private Pet _pet;
    [SerializeField] private float _roamingDistance = 4f;
    [SerializeField] private Stat slepiness = new Stat("sleep", 0f);
    [SerializeField] private PetStateMachine _brain;
    [SerializeField] private Vector3 _anchorPosition= new Vector3(0,0,0);
    [SerializeField] private float _anchorStrength = 1f;
    [SerializeField] private float _posIntervall = 1f;

    [SerializeField] public Condition condi = new Condition();
     
    //Getters
    public Pet Pet => _pet;
    public Animator Animator => _animator;
    public NavMeshAgent Agent => _agent;
    public float RoamingDistance => _roamingDistance;
    public PetStateMachine Brain => _brain;
    public Vector3 AnchorPosition => _anchorPosition;
    public float AnchorStrength => _anchorStrength;
    public float PosIntervall => _posIntervall;
    
    void Start()
    {
        _pet = GetComponent<Pet>();
        condi = _pet.Condition;
        _agent = GetComponent<NavMeshAgent>();
        _brain = GetComponent<PetStateMachine>();
        if (GetComponent<Animator>()!=null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if ( targetPosition && _agent.transform.position != targetPosition.position)
        {
             _agent.destination = targetPosition.position;
        }*/
    }
}
