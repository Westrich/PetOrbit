using UnityEditor.Timeline;
using UnityEngine;

public class RoamingState : MovementState
{
    public RoamingState(MovementContext context, MovementMachine.EMoveState stateID) : base(context, stateID)
    {
        Context = context;
    }

    #region MustImpliment

        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override MovementMachine.EMoveState GetNextState()
        {
            throw new System.NotImplementedException();
        }

        public override void OnTriggerEnter(Collider other)
        {
            throw new System.NotImplementedException();
        }

        public override void OnTriggerStay(Collider other)
        {
            throw new System.NotImplementedException();
        }

        public override void OnTriggerExit(Collider other)
        {
            throw new System.NotImplementedException();
        }
    #endregion
}
