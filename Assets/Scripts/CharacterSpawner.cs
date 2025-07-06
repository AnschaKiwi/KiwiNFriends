using System.Linq.Expressions;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [Tooltip("Das Prefab des Hundes, das beim Start gespawnt werden soll.")]
    public GameObject characterPrefab;
    [Tooltip("Die Position, an der der Charakter erscheinen soll.")]
    public Transform spawnPoint;
    void Start()
    {
        // Sicherheits-Check: Wenn kein Prefab oder Spawnpunkt zugewiesen wurde, abbrechen
        if (characterPrefab == null || spawnPoint == null)
        {
            Debug.LogError("Character Prefab oder Spawn Point nicht zugewiesen!");
            return;
        }

        // Instanziiere den Charakter an der angegebenen Position und Rotation
        Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Character spawnte bei Position: " + spawnPoint.position);
    }

}
