using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public PotionDB.Temperature Temp;
    public PotionDB.Luminosity Lumi;

    public Animator animator;

    private Scroll _scrollQuestAndHistory;
    private FinishedPotions _finishedPotions;

    private float _cleanUpStep = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Temp = PotionDB.Temperature.Moderate;
        Lumi = PotionDB.Luminosity.Bright;

        _scrollQuestAndHistory = FindObjectOfType<Scroll>();
        _finishedPotions = FindObjectOfType<FinishedPotions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.State == GameManager.GameState.Combining)
        {
            animator.SetTrigger("combining");
        }
        else if(GameManager.State == GameManager.GameState.Crafting)
        {
            animator.SetTrigger("crafting");
        }
        else if (GameManager.State == GameManager.GameState.PotionReady)
        {
            PotionDB.Potion potion = new PotionDB.Potion(GameManager.ActiveIngredients[0].id, GameManager.ActiveIngredients[1].id, GameManager.ActiveIngredients[2].id, Temp, Lumi);

            if (PotionDB.CheckIfCorrectPotion(GameManager.CurrentPotion, potion))
            {
                // Write to TextBox "That's it!"

                // Add to History
                _scrollQuestAndHistory.AddHistoryItem("Success: " + potion.ToString());

                _finishedPotions.RevealFinishedPotion(GameManager.CurrentQuest.PotionTextureIndex);

                GameManager.Narrator.ShowCustomText("That's it!");

                // The right potion was created - Wuhu
                // Set Animator
                GameManager.State = GameManager.GameState.CleanUp;
                animator.SetTrigger("idle");
            }
            else if (CheckIfPotionIsValidAndUpdateScroll())
            {
                // Potion is valid but was not requested
                // Set Animator

                int correctIngredients = PotionDB.NumberOfCorrectIngredients(GameManager.CurrentPotion, potion, out string wrongOrRightIngredient);

                int rndValidText = Random.Range(0, TextDB.PotionTextsValid.Count - 1);

                string validPotionText = TextDB.PotionTextsValid[rndValidText];

                if (correctIngredients == 0) validPotionText += "\n\n" + "Oh come on, it's a beginners task..."; 
                else if (correctIngredients == 1)
                {
                    validPotionText += "\n\n" + "That was close, give it a second thought if you really need " + wrongOrRightIngredient;
                }
                else if (correctIngredients == 2)
                {
                    validPotionText += "\n\n" + "Well, I mean the " + wrongOrRightIngredient + " was a good idea. The others….";
                }

                GameManager.Narrator.ShowCustomText(validPotionText);

                // Add to History
                _scrollQuestAndHistory.AddHistoryItem("Stable: " + potion.ToString());

                GameManager.State = GameManager.GameState.CleanUp;
                animator.SetTrigger("idle");
            }
            else 
            {
                int rndUnstableText = Random.Range(0, TextDB.PotionTextsUnstable.Count - 1);

                GameManager.Narrator.ShowCustomText(TextDB.PotionTextsUnstable[rndUnstableText]);

                // Add to History
                _scrollQuestAndHistory.AddHistoryItem("Unstable: " + potion.ToString());

                // Potion is unstable
                // Set Animator
                GameManager.State = GameManager.GameState.CleanUp;
                animator.SetTrigger("unstable");
            }
        }
        else if (GameManager.State == GameManager.GameState.CleanUp)
        {
            _cleanUpStep += Time.deltaTime * 0.6f;

            if (_cleanUpStep >= 1f)
            {
                GameManager.State = GameManager.GameState.Idle;

                animator.SetTrigger("idle");

                GameManager.ActiveIngredients[0].BackToDefaultPosition();
                GameManager.ActiveIngredients[1].BackToDefaultPosition();
                GameManager.ActiveIngredients[2].BackToDefaultPosition();

                _cleanUpStep = 0f;
            }
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
