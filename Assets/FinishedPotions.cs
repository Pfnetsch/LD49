using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedPotions : MonoBehaviour
{
    public List<Texture2D> potionTextures;

    public float AnimationSpeed = 0.5f;

    private Transform _potionToReveal;
    private float _revealAnimation = 0;

    // Start is called before the first frame update
    void Start()
    {
        RevealFinishedPotion(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_potionToReveal != null && _revealAnimation <= 1f)
        {
            _revealAnimation += Time.deltaTime * AnimationSpeed;
            _potionToReveal.localScale = new Vector3(_revealAnimation, _revealAnimation);
        }

        if (_revealAnimation >= 1) // Reveal finished
        {

        }
    }

    public void RevealFinishedPotion(int potionTextureIndex)
    {
        _potionToReveal = transform.GetChild((int)GameManager.Level);

        _potionToReveal.localScale = new Vector3(0f, 0f);

        _potionToReveal.gameObject.SetActive(true);
    }
}
