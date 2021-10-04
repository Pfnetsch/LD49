using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleIngredients : MonoBehaviour
{
    public GameObject PrepArea;
    public List<GameObject> PrepPositions;

    private Ingredient _ingredientUnderMouse;
    private PopUpSystem _pop;

    private Vector3 _dragOffset;

    private bool _startMixing = false;
    private float _curveAnimationStep = 0f;

    public float AnimationSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _pop = GetComponent<PopUpSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //check if crafting has finished and reset everythign back to idle states
        if (_curveAnimationStep >= 1)
        {
            GameManager.State = GameManager.GameState.PotionReady;
            _curveAnimationStep = 0;
            //ingredientsOnPrepPositions[0] = null;
            //ingredientsOnPrepPositions[1] = null;
            //ingredientsOnPrepPositions[2] = null;
            _startMixing = false;
        }

        //update game state when on of the ingredients is in the cauldron
        if(GameManager.ActiveIngredients != null && GameManager.State == GameManager.GameState.Idle && GameManager.ActiveIngredients[0] != null && GameManager.ActiveIngredients[1] != null && GameManager.ActiveIngredients[2] != null)
        {
            GameManager.State = GameManager.GameState.Combining;
        }

        if (_startMixing && _curveAnimationStep <= 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Transform[] pathPoints = PrepPositions[i].GetComponentsInChildren<Transform>(); // One Entry not needed - Parent

                Vector2 _positionOnRoute = Mathf.Pow(1 - _curveAnimationStep, 3) * pathPoints[1].position + 3 * Mathf.Pow(1 - _curveAnimationStep, 2) * _curveAnimationStep * pathPoints[2].position + 3 * (1 - _curveAnimationStep) * Mathf.Pow(_curveAnimationStep, 2) * pathPoints[3].position + Mathf.Pow(_curveAnimationStep, 3) * pathPoints[4].position;

                GameManager.ActiveIngredients[i].transform.position = _positionOnRoute; // new Vector3(_positionOnRoute.x, _positionOnRoute.y, _herbOnPrep.transform.position.y);
            }

            _curveAnimationStep += Time.deltaTime * AnimationSpeed;
        }

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 origin = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D ingredientHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            if (ingredientHit)
            {
                if (ingredientHit.transform.CompareTag("Loeffel"))
                {
                    if (GameManager.ActiveIngredients[0] != null && GameManager.ActiveIngredients[1] != null && GameManager.ActiveIngredients[2] != null)
                    {
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

        // Ingredient moved by Mouse
        if (Input.GetMouseButton(0))
        {
            if (_ingredientUnderMouse != null)
            {
                _ingredientUnderMouse.transform.position = mousePos + _dragOffset;
            }
        }

        if (Input.GetMouseButtonUp(0)) // Releasing the MouseButton
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

                            if (GameManager.ActiveIngredients[0] != null) GameManager.ActiveIngredients[0].BackToDefaultPosition();

                            GameManager.ActiveIngredients[0] = _ingredientUnderMouse;
                            break;

                        case Ingredient.IngredientType.Liquid:
                            _ingredientUnderMouse.transform.position = PrepPositions[1].transform.position;

                            if (GameManager.ActiveIngredients[1] != null) GameManager.ActiveIngredients[1].BackToDefaultPosition();

                            GameManager.ActiveIngredients[1] = _ingredientUnderMouse;
                            break;

                        case Ingredient.IngredientType.Solid:
                            _ingredientUnderMouse.transform.position = PrepPositions[2].transform.position;

                            if (GameManager.ActiveIngredients[2] != null) GameManager.ActiveIngredients[2].BackToDefaultPosition();

                            GameManager.ActiveIngredients[2] = _ingredientUnderMouse;
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    _ingredientUnderMouse.BackToDefaultPosition();
                }

                _ingredientUnderMouse = null;
            }
        }
    }

}
