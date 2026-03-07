using System;
using System.Collections.Generic;
using System.Collections;
using System.Timers;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore;
using Random = UnityEngine.Random;


public class RoamingState : PetState
{
    public RoamingState(PetController petController, PetStateMachine.EPetState stateID) : base(petController, stateID)
    {
        PetController = petController;
        
    }

    public GameObject visualiserFor;
    public GameObject visualisergoal;
    public UnityAction myAction;
    private float distance => PetController.RoamingDistance;
    private float _timer = 0f;
    private float _intervall => PetController.PosIntervall;
    private bool _timerRunning = false;
    private float turnamount = 2;
    private float strength => PetController.AnchorStrength;
    private PetStateMachine.EPetState NextState;
    
    private Condition cond => PetController.Pet.Condition;
    private Stat _exhaustion => PetController.Pet.Condition.Exhaustion;
    



        public override void EnterState()
        {
            NextState = StateID;
            
            _exhaustion.SetReplenishRate(200f);
            _exhaustion.SetDepletionRate(200f);
            PetController.Brain.statsToIncrease.Add(_exhaustion);
            myAction += NewTarget;
            PetController.Brain.StatFull = new Action<string>(StatFilled);
            PetController.Brain.StatCleared =new Action<string>(StatCleared);
            _timer = 0.1f;
           
            //_timerRunning = true;
            Debug.Log("Entering Roaming State");
        }

        public override void UpdateState()
        {
            if (!_timerRunning)
            {
               // Debug.Log("timer started");
                _timer = Random.Range(_intervall*0.8f,_intervall*1.2f);
            }
            ActionAfterTime(myAction);
        }

        public override void ExitState()
        {
            myAction -= NewTarget;
            Debug.Log("Exit Roaming State");
        }

        public override PetStateMachine.EPetState GetNextState()
        {
            return NextState;
        }
    #region NotImplimented
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

    public void StatCleared(string name)
    {
        Debug.Log("stat Cleared function");
        if (name == _exhaustion.GetName())
        {
            NextState = PetController.Brain._states[PetStateMachine.EPetState.Roaming].StateID;
            PetController.Brain.TransitionToState(PetController.Brain._states[PetStateMachine.EPetState.Roaming].StateID);
        }
    }
    public void StatFilled(string name)
    {
        Debug.Log("stat Filled function");
        if (name == _exhaustion.GetName())
        {
            NextState = PetController.Brain._states[PetStateMachine.EPetState.Sitting].StateID;
            PetController.Brain.TransitionToState(PetController.Brain._states[PetStateMachine.EPetState.Sitting].StateID);
        }
    }

    public void ActionAfterTime(UnityAction action)
    {
    
        if (_timer > 0)
        {
            _timerRunning = true;
            _timer -= 1 * Time.deltaTime;
            
            
            
        }
        else
        {
            //Debug.Log("Timer Over");
            _timerRunning = false;
            action.Invoke();
        }
    }
   
    
    private void NewTarget()
    {
        
        PetController.Agent.destination = RandomPosition(PetController.AnchorPosition,distance);
        
    }
    
    //get random position within a certain area
    private Vector3 RandomPosition(Vector3 anchorPosition, float radius)
    {
        var trans = PetController.Pet.transform;
        
        var curPos = PetController.Pet.GetPosition();
      
        var facing = trans.forward *distance/2;
        var sides = trans.right * Random.Range(-distance/2, distance/2);
        var goal = curPos + facing + sides;
        var mag = (anchorPosition - goal).magnitude/distance;
        var anchor = (anchorPosition - goal);
        
        anchor = anchor.normalized;
        
        goal = (goal + anchor*(strength*mag));
        
        return goal;
    }

    
    // check if something is within the range of something else
    private bool WithinRadius(Vector3 checkPos, Vector3 newPos, float radius)
    {
        var dist = (newPos - checkPos).magnitude;
        return dist <= radius;
    }

}
