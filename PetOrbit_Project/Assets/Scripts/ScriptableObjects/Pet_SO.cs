using UnityEngine;

[CreateAssetMenu(fileName = "Pet_SO", menuName = "Scriptable Objects/Pet_SO")]
public class Pet_SO : ScriptableObject
{

    [SerializeField] private Species_SO SpeciesSo;
    [SerializeField] private string petName = "no name assigned";

    public Species_SO GetSpecies()
    {
        return SpeciesSo;
    }

    public string GetName()
    {
        return petName;
    }
    
    public void SetName(string newName)
    {
        petName = newName;
    }

    [SerializeField] private Color colorA=new Color(); 

    [SerializeField] private Color colorB=new Color();

    public void SetColor(string name, Color color)
    {
        if (name == "colorA")
        {
            colorA = color;
        }else if (name == "colorB")
        {
            colorB = color;
        }
        else Debug.Log("no property found called " + name);
    }

    public Color GetColor(string name)
    {
        if (name == "colorA")
        {
            return colorA ;
        }else if (name == "colorB")
        {
            return colorB ;
        }
        else
        {
            Debug.Log("no property found called " + name);
            return Color.magenta;
        }

        
    }
}
