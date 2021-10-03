using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public PotionDB.Temperature Temp;
    public PotionDB.Luminosity Lumi;

    public Animator animator;

    private SpriteRenderer _spriteRenderer;
    public Scroll ScrollQuestAndHistory;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
            PotionDB.Potion potion = new PotionDB.Potion(GameManager.ActiveIngredients[0].id, GameManager.ActiveIngredients[1].id, GameManager.ActiveIngredients[2].id, Temp, Lumi);

            if (PotionDB.CheckIfCorrectPotion(GameManager.CurrentPotionTask, potion))
            {
                // Write to TextBox "That's it!"

                // Add to History
                ScrollQuestAndHistory.AddHistoryItem("Succes: " + potion.ToString());

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

                // Add to History
                ScrollQuestAndHistory.AddHistoryItem("Stable: " + potion.ToString());
            }
            else 
            {
                int rndUnstableText = Random.Range(0, TextDB.PotionTextsUnstable.Count - 1);

                // TextBox = TextDB.PotionTextsUnstable[rndUnstableText];

                // Add to History
                ScrollQuestAndHistory.AddHistoryItem("Unstable: " + potion.ToString());

                // Potion is unstable
                // Set Animator
            }

            animator.SetTrigger("idle");
        }
    }

    public bool CheckIfPotionIsValidAndUpdateScroll()
    {
        bool isValid = true;
        bool hintAddedToScroll = false;

        for (int i = 0; i < GameManager.ActiveIngredients.Length; i++)
        {
            if (GameManager.ActiveIngredients[i].RequiredLumi != Lumi)
            {
                isValid = false;

                // Update Scroll here, if not already done
                if (!GameManager.ActiveIngredients[i].HintLuminosity)
                {
                    GameManager.ActiveIngredients[i].HintLuminosity = true;
                    hintAddedToScroll = true;
                }
            }
            if (GameManager.ActiveIngredients[i].RequiredTemp != Temp)
            {
                isValid = false;

                // Update Scroll here, if not already done
                if (!GameManager.ActiveIngredients[i].HintTemperature)
                {
                    GameManager.ActiveIngredients[i].HintTemperature = true;
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
