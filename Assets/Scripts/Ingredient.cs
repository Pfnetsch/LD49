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

    public Sprite nonHoveredSprite;
    public Sprite hoveredSprite;


    public string id;
    public string description;

    public PotionDB.Luminosity RequiredLumi;
    public PotionDB.Temperature RequiredTemp;

    public bool HintLuminosity;
    public bool HintTemperature;

    public IngredientType Type;

    private Vector3 _defaultPosition;
    private Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        _defaultPosition = this.transform.position;
        _anim = GetComponent<Animator>();
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


    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        SpriteRenderer ingredientRenderer = GetComponent<SpriteRenderer>();
        ingredientRenderer.sprite = hoveredSprite;

        
        if (_anim != null)
        {
            _anim.ResetTrigger("animated");
            _anim.SetTrigger("hover");
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        SpriteRenderer ingredientRenderer = GetComponent<SpriteRenderer>();
        ingredientRenderer.sprite = nonHoveredSprite;

        _anim = GetComponent<Animator>();
        if (_anim != null)
        {
            _anim.ResetTrigger("hover");
            _anim.SetTrigger("animated");
        }
    }
}
