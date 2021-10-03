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

    private Scroll _scrollQuestAndHistory;

    // Start is called before the first frame update
    void Start()
    {
        _scrollQuestAndHistory = FindObjectOfType<Scroll>();

        // 0 is Herb
        // 1 is Liquid
        // 2 is Solid
        ActiveIngredients = new Ingredient[3];

        // Retrieve first Quest
        var quest = GetQuestForCurrentLevel();

        CurrentPotionTask = quest.Item1;

        _scrollQuestAndHistory.SetNewQuest(quest.Item2);

        // Write Quest to Text Box
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

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 origin = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D ingredientHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            if (ingredientHit)
            {
                if (_scrollQuestAndHistory && ingredientHit.transform.CompareTag("Scroll"))
                {
                    _scrollQuestAndHistory.EnableScroll(false);
                }
                else if (ingredientHit.transform.CompareTag("MiniScroll"))
                {
                    _scrollQuestAndHistory.EnableScroll(true);
                }
            }
        }
    }

    (PotionDB.Potion, PotionDB.Quest) GetQuestForCurrentLevel()
    {
        int randomIndex = Random.Range(0, PotionDB.Potions[(int)Level].Count - 1);

        return PotionDB.Potions[(int)Level][randomIndex];
    }
}
