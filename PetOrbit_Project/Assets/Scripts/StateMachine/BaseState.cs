using UnityEngine;
using System;
using UnityEngine.Events;

public abstract class BaseState<EState> where EState : Enum
{ 
    public BaseState(EState stateID)
    {
        StateID = stateID;
    }
 
    public EState StateID { get; private set; }
    public abstract void EnterState();
    public abstract void UpdateState();
   
    
    public abstract void ExitState();
    public abstract EState GetNextState();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void OnTriggerStay(Collider other);
    public abstract void OnTriggerExit(Collider other);
}
