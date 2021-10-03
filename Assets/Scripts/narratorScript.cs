using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class narratorScript : MonoBehaviour
{
    public GameObject popUpBox;
    public TMP_Text pupupDescription;

   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        pupupDescription.text = "ME: Ah … u-uh … my head … hurts. And I feel sick … uh, where am I? And what happened?";

        yield return new WaitForSecondsRealtime(5);

        pupupDescription.text = "ME:… What’s that on my hand?";

        yield return new WaitForSecondsRealtime(5);
        pupupDescription.fontStyle = FontStyles.Italic;
        pupupDescription.text = "Hey Buddy, the witch party was pretty crazy yesterday, huh? You seemed kinda wasted. We brought you to the alchemy room so you won’t be late for your exam. Good luck with it!!!";

        yield return new WaitForSecondsRealtime(8);

        pupupDescription.fontStyle = FontStyles.Normal;
        pupupDescription.text = "ME:What … party? What exam?!";

        yield return new WaitForSecondsRealtime(5);

        SceneManager.LoadScene(2);
    }
}
