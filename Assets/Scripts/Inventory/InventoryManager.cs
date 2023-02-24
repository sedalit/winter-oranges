using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Singleton { get; private set; }

    [SerializeField] private List<InventoryCell> cells;
    [SerializeField] private InventoryInput inventoryInput;

    private InventoryCell selectedCell;

    private void Awake()
    {
        Singleton = this;

        //Subscribing to cells events
        foreach (var cell in cells)
            cell.Clicked += CellOnClicked;

        foreach (var t in cells)
            t.SetUniqueAppearance(false);
        cells[0].SetUniqueAppearance(true);
        selectedCell = cells[0];
        inventoryInput.UseItem += InventoryInputOnUseItem;
    }

    private void InventoryInputOnUseItem()
    {
        print("Use item");
        //Can I use?
        if (!selectedCell.IsFree)
        {
            PlotManager.Singleton.UseItem(selectedCell.itemType);
            selectedCell.Clear();
        }
    }

    private void OnDestroy()
    {
        foreach (var cell in cells)
        {
            if (cell != null)
                cell.Clicked -= CellOnClicked;
        }

        inventoryInput.UseItem -= InventoryInputOnUseItem;
    }

    private void CellOnClicked(int cellId)
    {
        if (selectedCell != null)
            selectedCell.SetUniqueAppearance(false);

        selectedCell = cells[cellId];
        selectedCell.SetUniqueAppearance(true);
    }

    public void AddItem(ItemType itemType)
    {
        if (itemType == ItemType.Leaves)
        {
            var leavesCell = cells.Find(c => c.itemType == ItemType.Leaves);
            if (leavesCell)
            {
                leavesCell.IncreaseCount();
                return;
            }
        }

        var freeCell = cells.Find(c => c.IsFree);

        freeCell.SetItem(itemType);
    }
}
