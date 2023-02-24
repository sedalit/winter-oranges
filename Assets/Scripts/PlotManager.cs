using System;
using UnityEngine;

internal class PlotManager : MonoBehaviour
{
    public static PlotManager Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    public void UseItem(ItemType itemType)
    {
        
    }
}
