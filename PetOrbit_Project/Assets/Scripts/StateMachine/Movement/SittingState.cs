using System;
using UnityEditor.Timeline;
using UnityEngine;

public class SittingState : PetState
{
    public SittingState(PetController petController, PetStateMachine.EPetState stateID) : base(petController, stateID)
    {
        PetController = petController;
        
        
    }

    private bool _rested = false;
    private Stat _exhaustion => PetController.Pet.Condition.Exhaustion;
    private PetStateMachine.EPetState NextState;

    #region MustImpliment

        public override void EnterState()
        {
            Debug.Log("Enter Sitting State");
            PetController.Agent.destination = PetController.Pet.GetPosition();
           // PetController.Brain.statsToDeplete.Add(_exhaustion);
            PetController.Brain.StatCleared = new Action<string>(Rested);
            NextState = StateID;
        }

        private void Rested(string statName)
        {
            if (statName == _exhaustion.GetName())
            {
                Debug.Log("rested");
                _rested = true;
                NextState = PetController.Brain._states[PetStateMachine.EPetState.Roaming].StateID;;
                PetController.Brain.TransitionToState(PetController.Brain._states[PetStateMachine.EPetState.Roaming].StateID);
            }
        }

        public override void UpdateState()
        {
           
        }

        public override void ExitState()
        {
            Debug.Log("Exit Sitting State");
        }

        public override PetStateMachine.EPetState GetNextState()
        {
           // if (_rested) return PetStateMachine.EPetState.Roaming;
            return NextState;

        }

        public override void OnTriggerEnter(Collider other)
        {
           
        }

        public override void OnTriggerStay(Collider other)
        {
            
        }

        public override void OnTriggerExit(Collider other)
        {
           
        }
    #endregion

    
}
