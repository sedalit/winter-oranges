using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryResources : MonoBehaviour
{
    public static InventoryResources Singleton { get; private set; }
    [SerializeField] private List<CellData> cellDatas = new();

    
    private void Awake()
    {
        Singleton = this;
    }

    public Sprite GetSprite(ItemType itemType, int count)
    {
        return cellDatas.Find(c => c.itemType == itemType).spritesByCount[count - 1];
    }
}
