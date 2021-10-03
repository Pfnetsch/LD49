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
        else if (GameManager.State == GameManager.GameState.PotionReady)
        {
            PotionDB.Potion potion = new PotionDB.Potion(IngredientsInside[0].id, IngredientsInside[1].id, IngredientsInside[2].id, Temp, Lumi);

            // Add to History

            if (GameManager.CurrentPotionTask == potion)
            {
                // Write to TextBox "That's it!"

                // The right potion was created - Wuhu
                // Set Animator
            }
            else if (CheckIfPotionIsValidAndUpdateScroll())
            {
                // Potion is valid but was not requested
                // Set Animator

                int correctIngredients = PotionDB.NumberOfCorrectIngredients(GameManager.CurrentPotionTask, potion, out string wrongOrRightIngredient);

                int rndValidText = Random.Range(0, TextDB.PotionTextsValid.Count - 1);

                // TextBox = TextDB.PotionTextsValid[rndValidText];

                if (correctIngredients == 0) ; // Set Text "Oh come on, it's a beginners task..."
                else if (correctIngredients == 1)
                {

                    ; // Set Text "That was close, give it a second thought if you really need ..." + wrongOrRightIngredient
                }
                else if (correctIngredients == 2)
                {

                    ; // Set Text "Well, I mean the … was a good idea. The others…." + wrongOrRightIngredient
                }
            }
            else 
            {
                int rndUnstableText = Random.Range(0, TextDB.PotionTextsUnstable.Count - 1);

                // TextBox = TextDB.PotionTextsUnstable[rndUnstableText];

                // Potion is unstable
                // Set Animator
            }

            spriteRenderer.sprite = idleSprite;
            animator.SetTrigger("idle");
        }
    }

    public bool CheckIfPotionIsValidAndUpdateScroll()
    {
        bool isValid = true;
        bool hintAddedToScroll = false;

        for (int i = 0; i < IngredientsInside.Length; i++)
        {
            if (IngredientsInside[i].RequiredLumi != Lumi)
            {
                isValid = false;

                // Update Scroll here, if not already done
                if (!IngredientsInside[i].HintLuminosity)
                {
                    IngredientsInside[i].HintLuminosity = true;
                    hintAddedToScroll = true;
                }
            }
            if (IngredientsInside[i].RequiredTemp != Temp)
            {
                isValid = false;

                // Update Scroll here, if not already done
                if (!IngredientsInside[i].HintTemperature)
                {
                    IngredientsInside[i].HintTemperature = true;
                    hintAddedToScroll = true;
                }
            }

            if (!isValid && hintAddedToScroll) break;   // Jump out of Loop if Potion is not valid and a hint was already added
        }

        if (!isValid && hintAddedToScroll)
        {
            // Write to TextBox
            // ... Your knowledge over the ingredients have been expanded
            // You learned something new
        }
        else if (!isValid && !hintAddedToScroll)
        {
            // Nothing new ?
        }

        return isValid;
    }
}
