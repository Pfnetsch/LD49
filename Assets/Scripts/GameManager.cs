using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
            unlocks.Add("foo");
            unlocks.Add("bar");
            Debug.Log("Space has been pressed");
            //PopUpSystem pop = GameObject
            PopUpSystem pop = GetComponent<PopUpSystem>();
            pop.PopUp("busen", "busen sin schon ziemlich nice!", unlocks);
        }



    }
}
