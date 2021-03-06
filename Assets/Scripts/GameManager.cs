using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameLevel
    {
        Nobody = -1,
        Apprentice,
        Initiate,
        Master
    }

    public enum GameState
    {
        Idle,
        Combining,
        Crafting,
        PotionReady,
        CleanUp
    }

    public static GameLevel Level = GameLevel.Nobody;
    public static GameState State = GameState.Idle;

    public static PotionDB.Potion CurrentPotion;
    public static PotionDB.Quest CurrentQuest;

    public static Ingredient[] ActiveIngredients;

    public Texture2D MousePointerDefault;
    public Texture2D MousePointerActive;

    public static NarratorGame Narrator;
    private static Scroll ScrollQuestAndHistory;

    private Collider2D[] _allColliders;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(MousePointerDefault, new Vector2(0, 0), CursorMode.Auto);

        ScrollQuestAndHistory = FindObjectOfType<Scroll>();

        Narrator = FindObjectOfType<NarratorGame>();

        _allColliders = FindObjectsOfType<Collider2D>();

        // 0 is Herb
        // 1 is Liquid
        // 2 is Solid
        ActiveIngredients = new Ingredient[3];

        // Retrieve first Quest
        SetQuestForNextLevel(false);

        ScrollQuestAndHistory.SetNewQuest(CurrentQuest);

        // Write Quest to Text Box
        if (Narrator != null)
        {
            Narrator.ShowIntroFromProf();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    List<string> unlocks = new List<string>();
        //    Debug.Log("Space has been pressed");
        //    //PopUpSystem pop = GameObject
        //    PopUpSystem pop = GetComponent<PopUpSystem>();
        //    pop.PopUp("busen", "busen sin schon ziemlich nice!", unlocks);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 origin = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D ingredientHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            if (ingredientHit)
            {
                if (ingredientHit.transform.CompareTag("MiniScroll"))
                {
                    ScrollQuestAndHistory.EnableScroll(true);
                }
            }
        }

        bool inCollider = false;

        foreach (var coll in _allColliders)
        {
            if (coll.OverlapPoint(mousePos))
            {
                inCollider = true;
                break;
            }
        }

        if (inCollider) Cursor.SetCursor(MousePointerActive, new Vector2(0, 0), CursorMode.Auto);
        else Cursor.SetCursor(MousePointerDefault, new Vector2(0, 0), CursorMode.Auto);
    }

    public static void SetQuestForNextLevel(bool showQuestTextBox)
    {
        if (Level == GameLevel.Master)
        {
            Narrator.ShowEndScreen("Exam finished! Congratulations!");
            return;
        }

        Level += 1; // Go to next Level

        int randomIndex = Random.Range(0, PotionDB.Potions[(int)Level].Count - 1);

        var poQu = PotionDB.Potions[(int)Level][randomIndex];

        CurrentPotion = poQu.Item1;
        CurrentQuest = poQu.Item2;

        if (ScrollQuestAndHistory != null) ScrollQuestAndHistory.SetNewQuest(CurrentQuest);

        if (Narrator != null)
        {
            Narrator.SetCurrentQuest(CurrentQuest);
            if (showQuestTextBox) Narrator.ShowCurrentQuest();
        }
    }
}
