using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientType
    {
        Herb,
        Liquid,
        Solid
    }

    public string id;
    public string description;

    public PotionDB.Luminosity RequiredLumi;
    public PotionDB.Temperature RequiredTemp;

    public bool HintLuminosity;
    public bool HintTemperature;

    public IngredientType Type;

    private Vector3 _defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        _defaultPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToDefaultPosition()
    {
        transform.position = _defaultPosition;
    }

    public string PotionDescriptionAndRequirements()
    {
        string desc = description;

        if (HintTemperature) desc += "\n\n" + "Likes it " + RequiredTemp.ToString();
        if (HintLuminosity) desc += "\n\n" + "Likes it " + RequiredLumi.ToString();

        return desc;
    }
}
