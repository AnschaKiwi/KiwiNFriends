using UnityEngine;
using UnityEngine.UI;      // für UI-Elemente
using TMPro;               // für TextMeshPro
using UnityEngine.SceneManagement; // später für Szenenwechsel

public class DoorInteraction : MonoBehaviour
{
    public Transform player;         // Referenz zum Spieler (Anscha)
    public Image circleIcon;         // UI-Kreis
    public TextMeshProUGUI interactText; // UI-Text "E öffnen"

    public float circleDistance = 8f; // ab dieser Distanz Kreis anzeigen
    public float textDistance = 4f;    // ab dieser Distanz Text anzeigen
    public string zielSzene = "StartHaus"; // Name der Zielszene

    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(player.position, transform.position);

        if (circleIcon != null)
            circleIcon.gameObject.SetActive(dist <= circleDistance);

        if (interactText != null)
            interactText.gameObject.SetActive(dist <= textDistance);

        if (dist <= textDistance && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(zielSzene);
        }
    }
}

