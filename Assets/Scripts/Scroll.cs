using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    private List<string> _history;
    private string _questText;

    private ScrollRect _scrollRect;
    private int _scrollActive = 0;

    private TMPro.TextMeshProUGUI _uiText;

    private Canvas _canvas;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _canvas = GetComponentInChildren<Canvas>(true);
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>(true);

        _scrollRect = this.GetComponentInChildren<ScrollRect>();
        _uiText = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        _history = new List<string>();
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

    public void EnableScroll(bool enable)
    {
        _canvas.gameObject.SetActive(enable);
        _spriteRenderer.gameObject.SetActive(enable);

        UpdateScrollText();
    }

    public void AddHistoryItem(string item)
    {
        _history.Add(item);

        if (_history.Count >= 10) _history.RemoveAt(0);
    }

    public void SetNewQuest(PotionDB.Quest quest)
    {
        _questText = quest.Name;
        _questText += "\n";
        _questText = quest.Riddle;
    }

    public void UpdateScrollText()
    {
        _uiText.text = _questText + "\n\n";

        for (int i = 0; i < _history.Count; i++)
        {
            _uiText.text += "* " + _history[_history.Count - 1 - i];
        }
    }
}
