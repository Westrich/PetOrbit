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
    private float distance;
    private float _timer = 0f;
    private float _intervall = 1f;
    private bool _timerRunning = false;
    private List<Vector3> _roamingPositions;



    public override void EnterState()
    {
        visualisergoal = PetController.a;
        visualiserFor = PetController.b;
            distance = PetController.RoamingDistance;
            myAction += NewTarget;
            _timer = 0.1f;
            //_timerRunning = true;
            Debug.Log("Entering Roaming State");
        }

        public override void UpdateState()
        {
            if (!_timerRunning)
            {
                Debug.Log("timer started");
                _timer = _intervall;
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
            return this.StateID;
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

    public void ActionAfterTime(UnityAction action)
    {
    
        if (_timer > 0)
        {
            _timerRunning = true;
            _timer -= 1 * Time.deltaTime;
            
            if(_timer%100 == 0 )Debug.Log(_timer);
            
        }
        else
        {
            Debug.Log("Timer Over");
            _timerRunning = false;
            action.Invoke();
        }
    }
   
    
    private void NewTarget()
    {
        Debug.Log("getting new target");
        PetController.Agent.destination = RandomPosition();
    }
    
    
    private Vector3 RandomPosition()
    {
        var curPos = PetController.Pet.GetPosition();
        var facing = PetController.Pet.transform.forward;
        var lookDir = PetController.Pet.transform.forward.z;
        visualiserFor.transform.position = new Vector3(curPos.x,curPos.y,facing.z);
        Vector3 vec = new Vector3(Random.Range(-facing.x,facing.x),0,facing.z);
        visualisergoal.transform.position = vec;
        vec.Normalize();
        
        Debug.Log(vec + "is the new target pos");
        return vec;
    }

}
