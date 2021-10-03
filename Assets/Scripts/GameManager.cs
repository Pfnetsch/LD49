using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Idle,
        Combining,
        Ready,
        Crafting
    }

    public static GameState State = GameState.Idle;

    // Start is called before the first frame update
    void Start()
    {
       
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
}
