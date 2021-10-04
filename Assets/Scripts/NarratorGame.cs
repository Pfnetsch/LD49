using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarratorGame : MonoBehaviour
{
    public GameObject NarratorBox;
    public TMP_Text Description;


    // Start is called before the first frame update
    void Start()
    {
        NarratorBox.SetActive(true);
        StartCoroutine(waiter2());
    }
    IEnumerator waiter2()
    {
        Description.text = "Unknown voice: YOU ARE LATE! I SHOULD LET YOU FAIL IMMEDIATELY! � Lucky for you I have high hopes for your future. As my apprentice, I expect more from you. So let�s begin.";
        yield return new WaitForSecondsRealtime(5);
        NarratorBox.SetActive(false);
    }
    IEnumerator waiter()
    {
        Description.text = "Unknown voice: YOU ARE LATE! I SHOULD LET YOU FAIL IMMEDIATELY! � Lucky for you I have high hopes for your future. As my apprentice, I expect more from you. So let�s begin.";

        yield return new WaitForSecondsRealtime(5);

        Description.text = "� (To explain: Logbuch, Zutaten-Selection (1 von jeweils), Drag-drop in Kessel?, Hei�/Kalt/neutral, Light/Dark)";

        yield return new WaitForSecondsRealtime(5);

        Description.text = "PROF:What are you waiting for?! Have you forgotten what your exam is about? YOU FOOL!!!";

        yield return new WaitForSecondsRealtime(8);

        Description.text = "whisper: the youth nowadays�";

        yield return new WaitForSecondsRealtime(5);

        Description.text = "PROF:Fine, I will explain it ONE more time to you!";

        yield return new WaitForSecondsRealtime(5);

        Description.text = "PROF:Your exam consists of mixing three potions in total. Because we want to minimize the risk of possible explosions or poisonous potions, you will find a guide for them (WHERE). So be sure to mix the right ingredients together to get the perfect outcome. If you make too many mistakes, you will fail the exam.  Also you will get some basic information about the potions if you hover over them.";

        yield return new WaitForSecondsRealtime(5);

        Description.text = "PROF:So, let�s do a test run. Put three ingredients from the shelf in the kettle and choose if you want to freeze or heat it. (SUNSHINE DROPS + BLUE BAYLEAF + HAIR OF GUNTHER -> VERDORBEN!)";

        yield return new WaitForSecondsRealtime(5);

        Description.text = "PROF:� Well, that was for being late to my exam. Now let's start for real - without teasing. Pay attention that the combination of ingredients isn�t unstable - and use your guide!";

        yield return new WaitForSecondsRealtime(5);

        Description.text = "whisper: the youth nowadays�";

        yield return new WaitForSecondsRealtime(5);

        NarratorBox.SetActive(false);


    }
}