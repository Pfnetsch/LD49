using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    private ScrollRect _scrollRect;

    private int _scrollActive = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scrollRect = this.GetComponentInChildren<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_scrollActive > 0)
            _scrollRect.verticalNormalizedPosition = _scrollRect.verticalNormalizedPosition + Time.deltaTime * 0.5f * (_scrollActive == 1 ? 1 : -1);
    }

    public void ButtonOnDown(bool scrollUp)
    {
        _scrollActive = scrollUp ? 1 : 2;
    }

    public void ButtonOnUp()
    {
        _scrollActive = 0;
    }
}
