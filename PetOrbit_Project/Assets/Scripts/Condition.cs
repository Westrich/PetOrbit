using System;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class Condition 
{
    //stat for each float
    public Stat Hunger = new Stat("hunger");
    public Stat Thirst = new Stat("thirst");
    public Stat Sleepiness = new Stat("sleep");
    public Stat Exhaustion = new Stat("exhaustion");
    
    public Condition(float hunger, float thirst, float sleepiness,float rest)
    {
        Hunger.SetValue(hunger);
        Thirst.SetValue(hunger);
        Sleepiness.SetValue(hunger);
        Exhaustion.SetValue(hunger);
    }
    
    public Condition()
    {
        Hunger.SetValue(0f);
        Thirst.SetValue(0f);
        Sleepiness.SetValue(0f);
        Exhaustion.SetValue(0f);
    }

    
    
    public void ResetCondition()
    {
        Hunger.SetValue(0f);
        Thirst.SetValue(0f);
        Sleepiness.SetValue(0f);
        Exhaustion.SetValue(0f);
    }

    public void BadCondition()
    {
        Hunger.SetValue(100f);
        Thirst.SetValue(100f);
        Sleepiness.SetValue(100f);
        Exhaustion.SetValue(100f);
    }

}
