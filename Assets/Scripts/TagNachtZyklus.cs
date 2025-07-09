using UnityEngine;

public class TagNachtZyklus : MonoBehaviour
{
    public Light sonnenLicht;
    public float zyklusDauerInSekunden = 2400f;
    public TMPro.TextMeshProUGUI uhrzeitText;

    private float zeit;

    void Update()
    {
        // Zeit hochzählen
        zeit += Time.deltaTime;
        float t = zeit / zyklusDauerInSekunden;

        if (zeit > zyklusDauerInSekunden)
            zeit = 0f;

        // Sonne rotiert um X und leicht um Y (z.B. 30°)
        float xRot = (t * 360f) % 360f;
        float yRot = 30f; // z.B. 30 Grad schräg
        sonnenLicht.transform.rotation = Quaternion.Euler(xRot, yRot, 0f);

        // Intensität je nach Sonnenstand (sinusförmig)
        float versatz = -0.15f; // verschiebt den Sinus nach links (mehr Tageslicht)
        float intensität = Mathf.Clamp01(Mathf.Sin((t + versatz) * Mathf.PI * 2f));
        sonnenLicht.intensity = Mathf.Lerp(0.1f, 1.2f, intensität);

        // Farbverlauf: Tag -> Abend -> Nacht -> Morgen -> Tag
        Color tag = new Color(1f, 0.956f, 0.839f); // warmes Tageslicht
        Color nacht = new Color(0.2f, 0.3f, 0.4f); // kühle Nachtfarbe
        sonnenLicht.color = Color.Lerp(nacht, tag, intensität);

        // Uhrzeit
        float uhrzeit = (zeit / zyklusDauerInSekunden) * 24f; // 0-24 Stunden
        int stunde = Mathf.FloorToInt(uhrzeit);
        int minute = Mathf.FloorToInt((uhrzeit - stunde) * 60f);
        uhrzeitText.text = stunde.ToString("00") + ":" + minute.ToString("00");
    }
}
