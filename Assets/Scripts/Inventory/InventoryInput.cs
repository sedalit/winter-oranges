using System;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    public event Action UseItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseItem?.Invoke();
        }
    }
}
