using UnityEngine;

public class FeuerFlackern : MonoBehaviour
{
    public Light zielLicht;
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    public float flackerSpeed = 0.1f;

    private float zielWert;
    private float timer;

    void Start()
    {
        if (zielLicht == null)
            zielLicht = GetComponent<Light>();

        zielWert = zielLicht.intensity;
        timer = Random.Range(0.07f, 0.15f);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            zielWert = Random.Range(minIntensity, maxIntensity);
            timer = flackerSpeed;
        }

        // Sanft interpolieren
        zielLicht.intensity = Mathf.Lerp(zielLicht.intensity, zielWert, Time.deltaTime * 5f);
    } 
}
