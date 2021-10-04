using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NarratorGame : MonoBehaviour
{
    public GameObject NarratorBox;
    public TMP_Text Description;

    private Coroutine _introCoroutine;
    private Coroutine _questCoroutine;
    private int _idxText;

    private PotionDB.Quest _currentQuest;

    private bool _switchToQuest = false;

    // Start is called before the first frame update
    void Start()
    {
        //NarratorBox.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (_introCoroutine != null)
            {
                StopCoroutine(_introCoroutine);
                _idxText++;

                if (_idxText == 7)
                {
                    NarratorBox.SetActive(false);
                    _introCoroutine = null;
                    _switchToQuest = true;
                }
                else _introCoroutine = StartCoroutine(ProfIntroRoutine());
            }

            if (_questCoroutine != null)
            {
                StopCoroutine(_questCoroutine);
                NarratorBox.SetActive(false);
            }
        }

        if (_switchToQuest)
        {
            _switchToQuest = false;
            ShowCurrentQuest();
        }
    }

    public void ShowIntroFromProf()
    {
        NarratorBox.SetActive(true);
        _introCoroutine = StartCoroutine(ProfIntroRoutine());
    }

    public void ShowEndScreen(string text)
    {
        Description.text = text;
        NarratorBox.SetActive(true);

        StartCoroutine(EndGameRoutine());
    }

    public void ShowCustomText(string text)
    {
        Description.text = text;
        _questCoroutine = StartCoroutine(QuestRoutine());
    }

    public void SetCurrentQuest(PotionDB.Quest quest)
    {
        _currentQuest = quest;
    }

    public void ShowCurrentQuest()
    {
        Description.text = "Your ";

        switch (GameManager.Level)
        {
            case GameManager.GameLevel.Nobody:
                break;
            case GameManager.GameLevel.Apprentice:
                Description.text += "first ";
                break;
            case GameManager.GameLevel.Initiate:
                Description.text += "second ";
                break;
            case GameManager.GameLevel.Master:
                Description.text += "third ";
                break;
            default:
                break;
        }
        Description.text += "potion:\n";
        Description.text += _currentQuest.Name + "\n\n";
        Description.text += _currentQuest.Description + "\n\n";
        Description.text += _currentQuest.Riddle;

        _questCoroutine = StartCoroutine(QuestRoutine());
    }

    IEnumerator EndGameRoutine()
    {
        yield return new WaitForSecondsRealtime(10);

        SceneManager.LoadScene(0);
    }

    IEnumerator QuestRoutine()
    {
        yield return new WaitForSecondsRealtime(1);
        NarratorBox.SetActive(true);
        yield return new WaitForSecondsRealtime(30);
        NarratorBox.SetActive(false);
    }

    IEnumerator ProfIntroRoutine()
    {
        bool stop = false;

        switch (_idxText)
        {
            case 0:
                Description.text = "Unknown voice: YOU ARE LATE! I SHOULD LET YOU FAIL IMMEDIATELY! … Lucky for you I have high hopes for your future. As my apprentice, I expect more from you. So let’s begin.";
                yield return new WaitForSecondsRealtime(9);
                break;

            case 1:
                Description.text = "PROF: What are you waiting for?! Have you forgotten what your exam is about? YOU FOOL!!!";
                yield return new WaitForSecondsRealtime(7);
                break;

            case 2:
                Description.text = "Whisper: the youth nowadays…";
                yield return new WaitForSecondsRealtime(5);
                break;

            case 3:
                Description.text = "PROF: Fine, I will explain it ONE more time to you!";
                yield return new WaitForSecondsRealtime(5);
                break;

            case 4:
                Description.text = "PROF: Your exam consists of mixing three potions in total. Because we want to minimize the risk of possible explosions or poisonous potions, you will find a guide for the requested potion on the wall. So be sure to mix the right ingredients together to get the perfect outcome. If you make too many mistakes, you will fail the exam. Also you will get some basic information about the ingredients if you hold them."; // Hover over ingredients
                yield return new WaitForSecondsRealtime(15);
                break;

            //case 5:
            //    Description.text = "PROF: So, let’s do a test run. Put three ingredients from the shelf in the cauldron and choose if you want to freeze or heat it. (SUNSHINE DROPS + BLUE BAYLEAF + HAIR OF GUNTHER -> VERDORBEN!)";
            //    yield return new WaitForSecondsRealtime(5);
            //    break;

            case 5:
                Description.text = "PROF: … Well, that was for being late to my exam. Now let's start - without teasing. Pay attention that the combination of ingredients isn’t unstable - and use your guide!";
                yield return new WaitForSecondsRealtime(9);
                break;

            case 6:
                Description.text = "Whisper: the youth nowadays…";
                yield return new WaitForSecondsRealtime(5);
                break;

            default:
                NarratorBox.SetActive(false);
                stop = true;
                _switchToQuest = true;
                break;
        }

        _idxText++;
        if (!stop) _introCoroutine = StartCoroutine(ProfIntroRoutine());
    }
}