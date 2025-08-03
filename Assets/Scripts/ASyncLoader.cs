using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ASyncLoader : MonoBehaviour
{
    public string zielSzene = "SpielScene";

    void Start()
    {
        StartCoroutine(LadeSpielSzene());
    }

    IEnumerator LadeSpielSzene()
    {
        yield return new WaitForSeconds(1f); // 1 Sekunde "Ladescreen zeigen"

        AsyncOperation vorgang = SceneManager.LoadSceneAsync(zielSzene);
        vorgang.allowSceneActivation = false;

        // optional: Warten bis 90% geladen (Unity lädt nur bis 90, dann wartet auf Freigabe)
        while (vorgang.progress < 0.9f)
        {
            yield return null;
        }
        // Dann freigeben:
        vorgang.allowSceneActivation = true;
    }
}
