using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerDownHandler
{
    public virtual void OnPointerDown(PointerEventData eventData)
    {
    }
}
