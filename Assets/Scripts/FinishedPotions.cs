using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedPotions : MonoBehaviour
{
    public enum FinishedPotionAnimation
    {
        Idle,
        Reveal,
        Waiting,
        CurveMovement
    }

    public List<Sprite> potionTextures;

    public float AnimationSpeed = 0.4f;

    private SpriteRenderer _potionToReveal;
    private float _animationStep = 0;

    private FinishedPotionAnimation _animationPart = FinishedPotionAnimation.Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reveal
        if (_animationPart == FinishedPotionAnimation.Reveal && _potionToReveal != null && _animationStep <= 1f)
        {
            _animationStep += Time.deltaTime * AnimationSpeed;
            _potionToReveal.transform.localScale = new Vector3(_animationStep, _animationStep);
        }

        // Reveal finished
        if (_animationPart == FinishedPotionAnimation.Reveal && _animationStep >= 1)        
        {
            _animationPart = FinishedPotionAnimation.Waiting; // Waiting for the user
            _animationStep = 0f;
        }

        if (Input.anyKeyDown && _animationPart == FinishedPotionAnimation.Waiting) _animationPart = FinishedPotionAnimation.CurveMovement;

        // Curve Movement
        if (_animationPart == FinishedPotionAnimation.CurveMovement && _potionToReveal != null && _animationStep <= 1f)
        {
            Transform[] pathPoints = _potionToReveal.transform.parent.GetComponentsInChildren<Transform>();    // 2 entries not needed - Parent and PotionSprite

            Vector2 _positionOnRoute = Mathf.Pow(1 - _animationStep, 3) * pathPoints[2].position + 3 * Mathf.Pow(1 - _animationStep, 2) * _animationStep * pathPoints[3].position + 3 * (1 - _animationStep) * Mathf.Pow(_animationStep, 2) * pathPoints[4].position + Mathf.Pow(_animationStep, 3) * pathPoints[5].position;

            _potionToReveal.transform.position = _positionOnRoute;

            _animationStep += Time.deltaTime * AnimationSpeed;
        }

        // Curve Movement finished
        if (_animationPart == FinishedPotionAnimation.CurveMovement && _animationStep >= 1)
        {
            _animationPart = FinishedPotionAnimation.Idle; // Waiting for the user
            _animationStep = 0f;

            _potionToReveal = null;

            GameManager.SetQuestForNextLevel();
        }
    }

    public void RevealFinishedPotion(int potionTextureIndex)
    {
        _potionToReveal = GetComponentsInChildren<SpriteRenderer>(true)[(int)GameManager.Level];

        _potionToReveal.transform.localScale = new Vector3(0f, 0f);

        _potionToReveal.sprite = potionTextures[potionTextureIndex];

        _potionToReveal.transform.parent.gameObject.SetActive(true);

        _animationPart = FinishedPotionAnimation.Reveal;
    }
}
