using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleIngredients : MonoBehaviour
{
    public List<Ingredient> AllIngredients;
    public GameObject PrepArea;
    public List<GameObject> PrepPositions;

    private Ingredient _ingredientUnderMouse;

    private Vector3 _dragOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0)) //clicking the button
        {
            if (_ingredientUnderMouse == null)
            {             
                Vector2 origin = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D ingredientHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

                if (ingredientHit)
                {
                    _ingredientUnderMouse = ingredientHit.transform.gameObject.GetComponent<Ingredient>();
                    showInfo(_ingredientUnderMouse.id, _ingredientUnderMouse.description);

                    if (_ingredientUnderMouse != null)
                    {
                        _dragOffset = _ingredientUnderMouse.transform.position - mousePos;
                        print("Click on Intredient with type: " + _ingredientUnderMouse.Type);
                    }         
                }
            }
            else
            { 
                _ingredientUnderMouse.transform.position = mousePos + _dragOffset;
                print(_ingredientUnderMouse.transform.position);
            }
        }
        else if (Input.GetMouseButtonUp(0)) //releasing the button
        {
            if (_ingredientUnderMouse != null)
            {
                if (PrepArea.GetComponent<Collider2D>().OverlapPoint(mousePos))
                {
                    switch (_ingredientUnderMouse.Type)
                    {
                        case Ingredient.IngredientType.Herb:
                            _ingredientUnderMouse.transform.position = PrepPositions[0].transform.position;
                            break;
                        case Ingredient.IngredientType.Liquid:
                            _ingredientUnderMouse.transform.position = PrepPositions[1].transform.position;
                            break;
                        case Ingredient.IngredientType.Solid:
                            _ingredientUnderMouse.transform.position = PrepPositions[2].transform.position;
                            break;
                        default:
                            break;
                    }
                }

                _ingredientUnderMouse = null;
            }
        }
    }

    void showInfo(string name, string description)
    {
        PopUpSystem pop = GetComponent<PopUpSystem>();
        pop.PopUp(name, description);
    }
}
