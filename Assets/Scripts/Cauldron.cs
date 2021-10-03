using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Animator animator;
    public Sprite combinginSprite;
    public Sprite craftingSprite;
    public enum CauldronStatus
    {
        Idle,
        Bubbling
    }

    public CauldronStatus Status;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.State);
        if (GameManager.State == GameManager.GameState.Combining)
        {
            //spriteRenderer.sprite = combinginSprite;
            animator.SetTrigger("combining");
        }
        else if(GameManager.State == GameManager.GameState.Crafting)
        {
            Debug.Log("I am crafting right now ");
            animator.SetTrigger("crafting");
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
            animator.SetTrigger("idle");
        }
    }
}
