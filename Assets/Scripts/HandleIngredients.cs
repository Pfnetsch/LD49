using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleIngredients : MonoBehaviour
{
    public List<Ingredient> AllIngredients;

    private GameObject _ingredientUnderMouse;

    private Vector3 _dragOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (_ingredientUnderMouse == null)
            {             
                Vector2 origin = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D ingredientHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

                if (ingredientHit)
                {
                    Ingredient ingredientCode = ingredientHit.transform.gameObject.GetComponent<Ingredient>();

                    if (ingredientCode != null)
                    {
                        _ingredientUnderMouse = ingredientHit.transform.gameObject;
                        _dragOffset = ingredientCode.transform.position - mousePos;
                        print("Click on Intredient with type: " + ingredientCode.Type);
                    }         
                }
            }
            else
            {
                _ingredientUnderMouse.transform.position = mousePos + _dragOffset;
                print(_ingredientUnderMouse.transform.position);
            }
        }
        else
        {
            _ingredientUnderMouse = null;
        }
    }
}
