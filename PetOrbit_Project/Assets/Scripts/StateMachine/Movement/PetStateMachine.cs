using UnityEngine;

public class PetStateMachine : StateMachine<PetStateMachine.EPetState>
{
    public enum EPetState
    {
        Sitting,
        Roaming,
        Eating,
        Sleeping,
        Cuddling,
        Fetching
    }

    private PetController _petController;

    private void Awake()
    {
        _petController = GetComponent<PetController>(); 
        InitializeStates();
    }

    protected override void InitializeStates()
    {
        States.Add(EPetState.Sitting, new SittingState(_petController,EPetState.Sitting));
        States.Add(EPetState.Roaming, new RoamingState(_petController,EPetState.Roaming));
        States.Add(EPetState.Eating, new EatingState(_petController,EPetState.Eating));
        States.Add(EPetState.Sleeping, new SleepingState(_petController,EPetState.Sleeping));
        States.Add(EPetState.Cuddling, new CuddlingState(_petController,EPetState.Cuddling));
        States.Add(EPetState.Fetching, new FetchingState(_petController,EPetState.Fetching));
        CurrentState = States[EPetState.Roaming];
    }
}
