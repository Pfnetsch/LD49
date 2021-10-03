using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public PotionDB.Temperature Temp;
    public PotionDB.Luminosity Lumi;

    public SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Animator animator;
    public Sprite combinginSprite;
    public Sprite craftingSprite;

    public Ingredient[] IngredientsInside;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.State);
        if (GameManager.State == GameManager.GameState.Combining)
        {
            //spriteRenderer.sprite = combinginSprite;
            animator.SetTrigger("combining");
        }
        else if(GameManager.State == GameManager.GameState.Crafting)
        {
            //Debug.Log("I am crafting right now ");
            animator.SetTrigger("crafting");
        }
        else
        {
            PotionDB.Potion potion = new PotionDB.Potion(IngredientsInside[0].id, IngredientsInside[1].id, IngredientsInside[2].id, Temp, Lumi);


            if (GameManager.CurrentPotionTask == potion)
            {
                // The right potion was created - Wuhu
            }
            else if (CheckIfPotionIsValidAndUpdateScroll(potion))
            {
                // Potion is valid but was not requested
            }
            else 
            {
                // Potion is unstable
            }

            spriteRenderer.sprite = idleSprite;
            animator.SetTrigger("idle");
        }
    }

    public bool CheckIfPotionIsValidAndUpdateScroll(PotionDB.Potion potion)
    {


        // Update Logbook here

        return true;
    }
}
