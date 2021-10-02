using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleIngredients : MonoBehaviour
{
    public List<Ingredient> AllIngredients;
    public GameObject PrepArea;
    public List<GameObject> PrepPositions;

    private Ingredient _ingredientUnderMouse;
    private PopUpSystem _pop;

    private Vector3 _dragOffset;

    private Ingredient herpOnPrep;
    private Ingredient fluidOnPrep;
    private Ingredient solidOnPrep;

    private bool _startMixing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_startMixing)
        {

        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D ingredientHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            if (ingredientHit)
            {
                if (ingredientHit.transform.CompareTag("Loeffel"))
                {
                    //Debug.Log("Loeffel");

                    if (herpOnPrep != null && fluidOnPrep != null && solidOnPrep != null)
                    {
                        Debug.Log("Loeffel");
                        _startMixing = true;
                    }
                }

                _pop = GetComponent<PopUpSystem>();

                if (ingredientHit)
                {
                    _ingredientUnderMouse = ingredientHit.transform.gameObject.GetComponent<Ingredient>();

                    if (_ingredientUnderMouse != null)
                    {
                        _dragOffset = _ingredientUnderMouse.transform.position - mousePos;

                        //popup handling
                        _pop.PopUp(_ingredientUnderMouse.name, _ingredientUnderMouse.description, _ingredientUnderMouse.unlocks);

                        print("Click on Intredient with type: " + _ingredientUnderMouse.Type);
                    }
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (_ingredientUnderMouse != null)
            {
                _ingredientUnderMouse.transform.position = mousePos + _dragOffset;
                print(_ingredientUnderMouse.transform.position);
                _pop.transform.position = mousePos + _dragOffset;
            }
        }

        if (Input.GetMouseButtonUp(0)) //releasing the button
        {
            _pop.PopDown();

            if (_ingredientUnderMouse != null)
            {
                if (PrepArea.GetComponent<Collider2D>().OverlapPoint(mousePos))
                {
                    switch (_ingredientUnderMouse.Type)
                    {
                        case Ingredient.IngredientType.Herb:
                            _ingredientUnderMouse.transform.position = PrepPositions[0].transform.position;
                            herpOnPrep = _ingredientUnderMouse;
                            break;
                        case Ingredient.IngredientType.Liquid:
                            _ingredientUnderMouse.transform.position = PrepPositions[1].transform.position;
                            fluidOnPrep = _ingredientUnderMouse;
                            break;
                        case Ingredient.IngredientType.Solid:
                            _ingredientUnderMouse.transform.position = PrepPositions[2].transform.position;
                            solidOnPrep = _ingredientUnderMouse;
                            break;
                        default:
                            break;
                    }
                }

                _ingredientUnderMouse = null;
            }
        }
    }
}
