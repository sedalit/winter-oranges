using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// Cell id is first parameter
    /// </summary>
    public event Action<int> Clicked;

    [SerializeField] private int cellID;
    

    #region Components

    [SerializeField] private Image mImage;

    [SerializeField] private Outline outline;
    public ItemType itemType;

    #endregion

    public bool IsFree { get; private set; } = true;
    public int Count { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked?.Invoke(cellID);
    }

    public void SetItem(ItemType itemType)
    {
        Count = 1;
        mImage.sprite = InventoryResources.Singleton.GetSprite(itemType, Count);
        IsFree = false;
        this.itemType = itemType;
    }

    public void IncreaseCount()
    {
        Count++;
        mImage.sprite = InventoryResources.Singleton.GetSprite(itemType, Count);
    }

    public void Clear()
    {
        mImage.sprite = null;
        IsFree = true;
    }

    public void SetUniqueAppearance(bool p0)
    {
        outline.enabled = p0;
    }
}
