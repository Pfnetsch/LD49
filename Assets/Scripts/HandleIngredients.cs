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

    private Ingredient[] ingredientsOnPrepPositions;

    private bool _startMixing = false;
    private float _routeIteration = 0f;

    public float AnimationSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // 0 is Herb
        // 1 is Liquid
        // 2 is Solid
        ingredientsOnPrepPositions = new Ingredient[3];
        _pop = GetComponent<PopUpSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //update game state when on of the ingredients is in the cauldron
        if((ingredientsOnPrepPositions[0] != null || ingredientsOnPrepPositions[1] != null || ingredientsOnPrepPositions[2] != null) && GameManager.State == GameManager.GameState.Idle)
        {
            GameManager.State = GameManager.GameState.Combining;
        }

        if (_startMixing && _routeIteration <= 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Transform[] pathPoints = PrepPositions[i].GetComponentsInChildren<Transform>();

                Vector2 _positionOnRoute = Mathf.Pow(1 - _routeIteration, 3) * pathPoints[1].position + 3 * Mathf.Pow(1 - _routeIteration, 2) * _routeIteration * pathPoints[2].position + 3 * (1 - _routeIteration) * Mathf.Pow(_routeIteration, 2) * pathPoints[3].position + Mathf.Pow(_routeIteration, 3) * pathPoints[4].position;

                ingredientsOnPrepPositions[i].transform.position = _positionOnRoute; // new Vector3(_positionOnRoute.x, _positionOnRoute.y, _herbOnPrep.transform.position.y);
            }

            _routeIteration += Time.deltaTime * AnimationSpeed;
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
                    if (ingredientsOnPrepPositions[0] != null && ingredientsOnPrepPositions[1] != null && ingredientsOnPrepPositions[2] != null)
                    {
                        Debug.Log("Loeffel");
                        _startMixing = true;
                        GameManager.State = GameManager.GameState.Crafting;
                    }
                }



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
                            ingredientsOnPrepPositions[0] = _ingredientUnderMouse;
                            break;
                        case Ingredient.IngredientType.Liquid:
                            _ingredientUnderMouse.transform.position = PrepPositions[1].transform.position;
                            ingredientsOnPrepPositions[1] = _ingredientUnderMouse;
                            break;
                        case Ingredient.IngredientType.Solid:
                            _ingredientUnderMouse.transform.position = PrepPositions[2].transform.position;
                            ingredientsOnPrepPositions[2] = _ingredientUnderMouse;
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
