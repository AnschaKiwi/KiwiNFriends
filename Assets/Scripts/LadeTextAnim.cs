using UnityEngine;
using TMPro;
using System.Collections;

public class LadeTextAnim : MonoBehaviour
{
    public TextMeshProUGUI ladeText;
    public string grundText = "Spiel wird geladen";
    public float interval = 0.5f;

    void Start()
    {
        StartCoroutine(PunkteAnimation());
    }

    IEnumerator PunkteAnimation()
    {
        int punktanzahl = 0;

        while (true)
        {
            punktanzahl = (punktanzahl + 1) % 4; // 0-> 1-> 2-> 3-> 0
            ladeText.text = grundText + new string('.', punktanzahl);
            yield return new WaitForSeconds(interval);
        }
    }
}
