using UnityEngine;
using UnityEngine.UI;

public class UIPulsator : MonoBehaviour
{
    public float pulsGeschwindigkeit = 3f;
    public float minAlpha = 0.2f;
    public float maxAlpha = 0.4f;

    private Image img;
    private Color startFarbe;

    void Start()
    {
        img = GetComponent<Image>();
        startFarbe = img.color;
    }

    void Update()
    {
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(Time.time * pulsGeschwindigkeit) + 1f) / 2f);
        img.color = new Color(startFarbe.r, startFarbe.g, startFarbe.b, alpha);
    }
}

