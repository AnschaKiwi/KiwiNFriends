using System.Linq.Expressions;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [Tooltip("Das Prefab des Hundes, das beim Start gespawnt werden soll.")]
    public GameObject characterPrefab;
    [Tooltip("Die Position, an der der Charakter erscheinen soll.")]
    public Transform spawnPoint;
    public CameraTargetSetter cameraSetter;
    public Transform pivotParent; // <-- neues Feld im Inspector
    void Start()
    {
        // Sicherheits-Check: Wenn kein Prefab oder Spawnpunkt zugewiesen wurde, abbrechen
        if (characterPrefab == null || spawnPoint == null)
        {
            Debug.LogError("Character Prefab oder Spawn Point nicht zugewiesen!");
            return;
        }

        // ❗ Jetzt wird das gespawnte GameObject in einer Variable gespeichert:
        GameObject spawnedCharacter = Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Character spawnte bei Position: " + spawnPoint.position);

        // Hänge Snoopy unter das Pivot-Objekt
        if (pivotParent != null)
        {
            spawnedCharacter.transform.SetParent(pivotParent);
        }

        // ✅ Das richtige Transform übergeben:
            cameraSetter.SetFollowTarget(pivotParent);
        Debug.Log("Kamera-Ziel gesetzt auf: " + spawnedCharacter.name);
    }
}
