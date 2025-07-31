using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Ein einzelner Inventar-Slot, der ein Icon anzeigen oder verstecken kann.
/// </summary>
public class InventarSlot : MonoBehaviour
{
    // Referenz auf das Image-Element, das das Item-Icon zeigt
    public Image iconImage;

    // Gibt zurück, ob der Slot aktuell ein Item enthält
    public bool Belegt => iconImage.enabled;

    /// <summary>
    /// Füllt den Slot mit einem Item-Icon.
    /// </summary>
    /// <param name="itemSprite">Das Sprite des Items (z.B. Axt-Icon).</param>
    public void BelegeSlot(Sprite itemSprite)
    {
        Debug.Log("BelegeSlot aufgerufen mit: " + (itemSprite != null ? itemSprite.name : "null"));
        iconImage.sprite = itemSprite;
        iconImage.enabled = true;
    }

    /// <summary>
    /// Entfernt das Icon aus dem Slot.
    /// </summary>
    public void LeereSlot()
    {
        iconImage.sprite = null;
        iconImage.enabled = false;
    }
}
