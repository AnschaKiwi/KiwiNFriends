using UnityEngine;

public class Taschenlampe : MonoBehaviour
{
    public Light taschenlampenLicht;
    public KeyCode schaltTaste = KeyCode.F;
    public bool zufälligesFlackern = false;
    private bool istAn = true;
    private bool flackertGerade = false;

    private float flackerTimer = 0f;
    public float flackerPruefIntervall = 0.20f; // Wie oft pro Sekunde geprüft wird
    public float flackerChance = 0.20f;        // Wahrscheinlichkeit pro Prüfung

    void Update()
    {
        if (Input.GetKeyDown(schaltTaste))
        {
            istAn = !istAn;
            taschenlampenLicht.enabled = istAn;
        }

        // Optionales Flackern der Taschenlampe
        if (istAn && zufälligesFlackern && !flackertGerade)
        {
            flackerTimer -= Time.deltaTime;
            if (flackerTimer <= 0f)
            {
                flackerTimer = flackerPruefIntervall;
                if (Random.value < flackerChance)
                {
                    StartCoroutine(Flackern());
                }
            }
        }
    }

    private System.Collections.IEnumerator Flackern()
    {
        flackertGerade = true;
        taschenlampenLicht.enabled = false;
        yield return new WaitForSeconds(Random.Range(0.03f, 0.12f));
        if (istAn) taschenlampenLicht.enabled = true;
        flackertGerade = false;
    }
}
