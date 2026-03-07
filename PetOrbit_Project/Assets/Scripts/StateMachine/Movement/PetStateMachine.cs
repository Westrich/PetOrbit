using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public Dictionary<EPetState, BaseState<EPetState>> _states =>States;

    public Action<string> StatCleared;
    public Action<string> StatFull;
    public List<Stat> statsToLower = new List<Stat>();
    public List<Stat> clearedStats= new List<Stat>();
    public List<Stat> statsToIncrease = new List<Stat>();
    private EPetState _previousState;
    public EPetState PreviousState => _previousState;

    public float counter;

    private PetController _petController;

    private void Awake()
    {
        
        _petController = GetComponent<PetController>(); 
        InitializeStates();
        _previousState = CurrentState.StateID;
    }

    
    protected override void OnUpdate()
    {
        counter += Time.deltaTime;
        Debug.Log(counter);
        LowerStats();
        FillStats();
    }

    private void LowerStats()
    {
        
        //Debug.Log("decrease" + statsToDeplete.Count);
        foreach (var stat in statsToLower)
        { 
            var changedStat = stat.StatValue;
            changedStat -= stat.DepletionRate * Time.deltaTime;
            stat.SetValue(changedStat);
            Debug.Log("stat " +stat.GetName() +" decrease d" +stat.StatValue);
            //Debug.Log("decrease stat" +stat + stat.StatValue);
            if ((stat.StatValue <= 1.0f))
            { 
                Debug.Log("stat" +stat +"fully decreased");
               

                clearedStats.Add(stat);
                statsToLower.Remove(stat);
              StatCleared.Invoke(stat.GetName());
            }
           

        }
    }

    

    private void FillStats()
    {
       
       // Debug.Log("increase" + statsToIncrease.Count);
        foreach (var stat in statsToIncrease)
        { 
           
            var changedStat = stat.StatValue;
            changedStat += stat.ReplenishRate * (Time.deltaTime*100);
            stat.SetValue(changedStat);
            Debug.Log("stat " +stat.GetName() +" increased" +stat.StatValue);
           // Debug.Log("increase stat  " +stat.GetName() + + stat.StatValue);
            if (stat.StatValue >= 30.0f)
            { 
                stat.SetValue(30.0f);
                Debug.Log("stat" +stat +"fully increased");
               
                statsToLower.Add(stat);
                statsToIncrease.Remove(stat); StatFull.Invoke(stat.GetName());
            }
            
        }
    }

    protected override void OnTransition()
    {
        _previousState = CurrentState.StateID;
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
