using UnityEngine;

[CreateAssetMenu(fileName = "Pet_SO", menuName = "Scriptable Objects/Pet_SO")]
public class Pet_SO : ScriptableObject
{

    [SerializeField] private Species_SO SpeciesSo;

    public Species_SO GetSpecies()
    {
        return SpeciesSo;
    }

    [SerializeField] private Color colorA;

    [SerializeField] private Color colorB;
}
