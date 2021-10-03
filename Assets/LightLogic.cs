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
        if (Input.GetKeyDown(KeyCode.K))
        {
            sprite.color = new Color(30, 30, 70, 130);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            sprite.color = new Color(30, 30, 70, 0);
        }

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
                        sprite.color = new Color(70, 0, 0, 130);
                        isLit = false;
                    }
                    else
                    {
                        sprite.color = new Color(0, 0, 70, 0);
                        isLit = true;
                    }
                }
            }
        }
    }
}
