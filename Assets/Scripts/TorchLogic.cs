using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TorchLogic : MonoBehaviour
{
    GameObject ld;
    SpriteRenderer sprite;
    public Animator animator;
    bool isLit = true;
    Cauldron cauldron;
    // Start is called before the first frame update
    void Start()
    {
        ld = GameObject.Find("LightRect");
        sprite = ld.GetComponent<SpriteRenderer>();
        sprite.color = new Color(.1f, .1f, .3f, 0f);
        cauldron = FindObjectOfType<Cauldron>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 origin = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D collisionHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            if (collisionHit)
            {
                if (collisionHit.transform.CompareTag("Torch"))
                {
                    if(isLit == true)
                    {
                        animator.ResetTrigger("burn");
                        animator.SetTrigger("smoke");
                        sprite.color = new Color(.1f, .1f, .3f, .5f);
                        isLit = false;
                        cauldron.Lumi = PotionDB.Luminosity.Dark;
                    }
                    else
                    {
                        animator.ResetTrigger("smoke");
                        animator.SetTrigger("burn");
                        sprite.color = new Color(.1f, .1f, .3f, 0f);
                        isLit = true;
                        cauldron.Lumi = PotionDB.Luminosity.Bright;
                    }
                }
            }
        }
    }
}
