using UnityEngine;
using System.Collections;

public class MusikAusblender : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MusikLangsamAusblenden(float dauer = 2f)
    {
        StartCoroutine(FadeOut(dauer));
    }

    IEnumerator FadeOut(float dauer)
    {
        float startLautstärke = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startLautstärke * Time.deltaTime / dauer;
            yield return null;
        }

        audioSource.Stop();
    }
}
