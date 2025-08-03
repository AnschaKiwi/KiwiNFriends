using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LadeScene : MonoBehaviour
{
    public string zielSzene = "SpielScene";
    void Start()
    {
        StartCoroutine(SzeneLaden());
    }

    IEnumerator SzeneLaden()
    {
        AsyncOperation vorgang = SceneManager.LoadSceneAsync(zielSzene);
        vorgang.allowSceneActivation = false; 
        while (vorgang.progress < 0.9f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        vorgang.allowSceneActivation = true;
    }
}

