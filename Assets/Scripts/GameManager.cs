using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameLevel
    {
        Apprentice,
        Initiate,
        Master
    }

    public enum GameState
    {
        Idle,
        Combining,
        Crafting,
        PotionReady
    }

    public static GameLevel Level = GameLevel.Apprentice;
    public static GameState State = GameState.Idle;

    public static PotionDB.Potion CurrentPotionTask;

    public static Ingredient[] ActiveIngredients;

    // Start is called before the first frame update
    void Start()
    {
        // 0 is Herb
        // 1 is Liquid
        // 2 is Solid
        ActiveIngredients = new Ingredient[3];

        // Retrieve first Quest
        var quest = GetQuestForCurrentLevel();

        CurrentPotionTask = quest.Item1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<string> unlocks = new List<string>();
            Debug.Log("Space has been pressed");
            //PopUpSystem pop = GameObject
            PopUpSystem pop = GetComponent<PopUpSystem>();
            pop.PopUp("busen", "busen sin schon ziemlich nice!", unlocks);
        }
    }

    (PotionDB.Potion, PotionDB.Quest) GetQuestForCurrentLevel()
    {
        int randomIndex = Random.Range(0, PotionDB.Potions[(int)Level].Count - 1);

        return PotionDB.Potions[(int)Level][randomIndex];
    }
}
