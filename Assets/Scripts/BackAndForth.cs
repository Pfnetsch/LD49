using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{

    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        HandleIngredients hit =  this.GetComponent<HandleIngredients>();
        GameObject foo = this.gameObject;
        Cauldron caul = this.GetComponent<Cauldron>();
        Loeffel loeff = this.GetComponent<Loeffel>();
        if(caul.Status == Cauldron.CraftingStatus.Crafting)
        {
            Vector3 v = startPos;   
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;

            //Vector3 vec = new Vector3(2* Mathf.Sin(Time.time *3) +1, 4 * Mathf.Sin(Time.time *3) +1, Mathf.Sin(Time.time *3));
            //transform.localScale = vec;
        }
    }
}
