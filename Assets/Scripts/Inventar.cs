using UnityEngine;

/// <summary>
/// Verwalter aller Slots im Inventar - sorgt dafür, dass Items hinzugefügt werden.
/// </summary>
public class Inventar : MonoBehaviour
{
    // Singleton Instanz, damit man von überall darauf zugreifen kann
    public static Inventar Instance;

    [Header("Alle Slots im Inventar - im Inspector zuweisen")]
    public InventarSlot[] slots;

    private void Awake()
    {
        // Singleton-Setup
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    /// <summary>
    /// Fügt ein neues Item ins Inventar ein.
    /// </summary>
    /// <param name="itemSprite">Das Sprite, das angezeigt werden soll</param>
    /// <returns>True, wenn erfolgreich hinzugeügt - false, wenn Inventar voll</returns>
    public bool FügeItemHinzu(Sprite itemSprite)
    {
        Debug.Log("FügeItemHinzu aufgerufen mit: " + (itemSprite != null ? itemSprite.name : "null"));
        // Durchsuche alle Slot
        foreach (InventarSlot slot in slots)
        {
            // Wenn ein Slot noch frei ist, fügen das Item hinzu
            if (!slot.Belegt)
            {
                slot.BelegeSlot(itemSprite);
                return true;
            }
        }

        // Wenn kein freier Slot gefunden wurde
        Debug.Log("Inventar ist voll");
        return false;
    } 
}

