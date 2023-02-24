using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    public Vector2 DirectionControl { get; set; }
    public Vector2 TeleportPosition { get; set; }

    public float LastDirectionX { get; private set; }

    [Range(1f, 10f)]
    [SerializeField] private float movementSpeed;

    private void Update()
    {
        if (DirectionControl.x != 0) LastDirectionX = DirectionControl.x;
        var targetPosition = transform.position + new Vector3(DirectionControl.x, DirectionControl.y, 0);
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    public void TeleportToPosition()
    {
        if (TeleportPosition != Vector2.zero)
        {
            transform.position = new Vector3(TeleportPosition.x, TeleportPosition.y, transform.position.z);
        }
    }
}
