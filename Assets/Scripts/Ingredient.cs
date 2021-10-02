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
    public List<string> unlocks;

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
}
