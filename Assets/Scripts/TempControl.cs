using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TempControl : MonoBehaviour
{
    private bool userHoldsLever;

    private Cauldron _cauldron;

    // Start is called before the first frame update
    void Start()
    {
        // Find cauldron in scene
        _cauldron = FindObjectOfType<Cauldron>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D ingredientHit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            if (ingredientHit.transform.CompareTag("TempLever"))
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

            Debug.Log(transform.rotation.z);

            if (transform.rotation.z <= -0.33F)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90F));
                if (_cauldron != null) _cauldron.Temperature = PotionDB.Temperature.Hot;
            }
            else if (transform.rotation.z >= 0.33F)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90F));
                if (_cauldron != null) _cauldron.Temperature = PotionDB.Temperature.Cold;
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                if (_cauldron != null) _cauldron.Temperature = PotionDB.Temperature.Moderate;
            }
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
