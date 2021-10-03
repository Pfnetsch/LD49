using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLogic : MonoBehaviour
{
    GameObject ld;
    SpriteRenderer sprite;
    bool isLit = true;
    // Start is called before the first frame update
    void Start()
    {
        ld = GameObject.Find("LightRect");
        sprite = ld.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D collisionHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            if (collisionHit)
            {
                if (collisionHit.transform.CompareTag("Light"))
                {
                    if(isLit == true)
                    {
                        sprite.color = new Color(.1f, .1f, .3f, .5f);
                        isLit = false;
                    }
                    else
                    {
                        sprite.color = new Color(.1f, .1f, .3f, 0f);
                        isLit = true;
                    }
                }
            }
        }
    }
}
