using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();

    protected BaseState<EState> CurrentState;

    protected EState nextStateID;

    protected bool isTransitioningState = false;
    void Awake()
    {
        
    }

    void Start()
    {
        CurrentState.EnterState();
        nextStateID = CurrentState.StateID;
    }
    
    public void Update()
    {

        if (!isTransitioningState)
        {
            if (nextStateID.Equals(CurrentState.StateID))
            {
                CurrentState.UpdateState();
            }
            else
            {
                TransitionToState(nextStateID);
            }
        }
        OnUpdate();
       
    }

    public void Transition()
    {
        EState nextStateID = CurrentState.GetNextState();
        
        if (!isTransitioningState)
        {
            if (nextStateID.Equals(CurrentState.StateID))
            {
                CurrentState.UpdateState();
            }
            else
            {
                TransitionToState(nextStateID);
            }
        }
    }

    public void TransitionToState(EState stateID)
    {
        nextStateID = stateID;
        if (nextStateID.Equals(CurrentState.StateID)) return;
        isTransitioningState = true;
        //Debug.Log("transitioning state to " + stateID);
        CurrentState.ExitState();
        CurrentState = States[stateID];
        CurrentState.EnterState();
        isTransitioningState = false;
    }

    protected virtual void OnUpdate()
    {
        Debug.Log("CallingfakeUpdtae");
    }
    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        
    }

    private void OnCollisionExit(Collision other)
    {
        
    }
}
