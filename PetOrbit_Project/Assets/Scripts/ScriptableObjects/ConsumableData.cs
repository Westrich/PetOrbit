using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableData", menuName = "Scriptable Objects/ConsumableData")]
public class ConsumableData : ScriptableObject
{
    [SerializeField] private string itemName = "no name assigned";
    [SerializeField] private float maxAmount = 10f;

    public string GetName()
    {
        string copiedName = new string(itemName);
        return copiedName;
    }
    public float GetMaxAmt()
    {
        
        return maxAmount;
    }
    

}
