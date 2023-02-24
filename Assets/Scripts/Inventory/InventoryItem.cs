using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : Interactable
{
    [SerializeField] private ItemType itemType;

    public override void OnPointerDown(PointerEventData eventData)
    {
        InventoryManager.Singleton.AddItem(itemType);
        Disable();
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}
