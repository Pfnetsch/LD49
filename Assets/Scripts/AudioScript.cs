using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private static AudioScript instance = null;

    public AudioSource musicGame;
    public AudioSource musicIntro;

    public static AudioScript Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(((this.gameObject)));
    }

    public void SwitchToIntroMode()
    {
        StartCoroutine(FadeOut(musicGame, 0.7f));

        StartCoroutine(FadeIn(musicIntro, 5f));
    }

    public void SwitchToGameMode()
    {
        StartCoroutine(FadeOut(musicIntro, 0.7f));

        StartCoroutine(FadeIn(musicGame, 5f));
    }

    public static IEnumerator FadeOut(AudioSource source, float fadeTime)
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        source.Stop();
        source.volume = startVolume;
    }


    public static IEnumerator FadeIn(AudioSource source, float fadeTime)
    {
        float startVolume = source.volume;

        source.volume = 0;
        source.Play();

        while (source.volume < 1.0f)
        {
            source.volume += startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        source.volume = 1f;
    }
}
