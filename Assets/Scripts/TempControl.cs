using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class TempControl : MonoBehaviour
{
    private bool userHoldsLever;

    private Cauldron _cauldron;

    private GameObject _ice;
    private GameObject _fire;

    // Start is called before the first frame update
    void Start()
    {
        // Find cauldron in scene
        _cauldron = FindObjectOfType<Cauldron>();

        foreach (Transform child in _cauldron.transform)
        {
            if (child.name.Contains("Ice")) _ice = child.gameObject;
            else if (child.name.Contains("Fire")) _fire = child.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 origin = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D ingredientHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            if (ingredientHit && ingredientHit.transform.CompareTag("TempLever"))
            {
                userHoldsLever = true;
            }
        }

        if (userHoldsLever && Input.GetMouseButton(0))
        {
            Vector2 leverPosition = Camera.main.WorldToViewportPoint(transform.position);
            Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            float angle = AngleBetweenTwoPoints(leverPosition, mousePosition) - 90F;

            if (angle >= -90 && angle <= 90)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            userHoldsLever = false;

            if (transform.rotation.z <= -0.33F)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90F));
                if (_cauldron != null) _cauldron.Temp = PotionDB.Temperature.Hot;
                _fire.SetActive(true);
                _ice.SetActive(false);
            }
            else if (transform.rotation.z >= 0.33F)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90F));
                if (_cauldron != null) _cauldron.Temp = PotionDB.Temperature.Cold;
                _ice.SetActive(true);
                _fire.SetActive(false);
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                if (_cauldron != null) _cauldron.Temp = PotionDB.Temperature.Neutral;
                _ice.SetActive(false);
                _fire.SetActive(false);
            }
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
