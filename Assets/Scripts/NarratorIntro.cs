using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NarratorIntro : MonoBehaviour
{
    public GameObject NarratorBox;
    public TMP_Text Description;

    private Coroutine _coroutine;
    private int _idxText;


    // Start is called before the first frame update
    void Start()
    {
        _idxText = 0;
        _coroutine = StartCoroutine(waiter());
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StopCoroutine(_coroutine);
            _idxText++;
            
            if (_idxText == 4) SceneManager.LoadScene(2);
            else _coroutine = StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        bool stop = false;

        switch (_idxText)
        {
            case 0:
                Description.text = "ME: Ah … u-uh … my head … hurts. And I feel sick … uh, where am I? And what happened?";
                yield return new WaitForSecondsRealtime(5);
                break;

            case 1:
                Description.text = "ME:… What’s that on my hand?";
                yield return new WaitForSecondsRealtime(5);
                break;

            case 2:
                Description.fontStyle = FontStyles.Italic;
                Description.text = "Hey Buddy, the witch party was pretty crazy yesterday, huh? You seemed kinda wasted. We brought you to the alchemy room so you won’t be late for your exam. Good luck with it!!!";
                yield return new WaitForSecondsRealtime(8);
                break;
            case 3:
                Description.fontStyle = FontStyles.Normal;
                Description.text = "ME:What … party? What exam?!";
                yield return new WaitForSecondsRealtime(5);
                break;

            default:
                stop = true;
                FindObjectOfType<AudioScript>().SwitchToGameMode();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }

        _idxText++;
        if (!stop) _coroutine = StartCoroutine(waiter());
    }
}
