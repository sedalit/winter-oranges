using UnityEngine;
using UnityEngine.EventSystems;

public class UIMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Mover targetMover;
    [SerializeField] private Vector2 direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        targetMover.DirectionControl = direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetMover.DirectionControl = Vector2.zero;
    }
}
