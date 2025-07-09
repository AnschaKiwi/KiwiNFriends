using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform startPoint;     // Dein unsichtbares Start-Marker-Objekt
    public GameObject player;        // Dein Held (bereits in der Szene)

    void Start()
    {
        if (startPoint != null && player != null)
        {
            player.transform.position = startPoint.position;
            player.transform.rotation = startPoint.rotation;
        }
        else
        {
            Debug.LogWarning("SpawnManager: StartPoint oder Player nicht zugewiesen.");
        }
    }
}

