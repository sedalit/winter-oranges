using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    public event UnityAction<float, float> DirectionChanged;

    public Vector2 DirectionControl { get; set; }
    public Vector2 MovePosition { get; set; }
    public Vector2 TeleportPosition { get; set; }
    public float NormalizedDirectionX { 
        get
        {
            return normalizedDirectionX;
        } 
        set
        {
            DirectionChanged?.Invoke(normalizedDirectionX, value);
            normalizedDirectionX = value;
        }
    }

    [Range(1f, 10f)]
    [SerializeField] private float movementSpeed;

    private float normalizedDirectionX = 0f;

    private void Update()
    {
        var targetPosition = MovePosition;
        if (DirectionControl != Vector2.zero)
        {
            targetPosition = transform.position + new Vector3(DirectionControl.x, DirectionControl.y, 0);
        }
        if (targetPosition != Vector2.zero)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            if (transform.position == new Vector3(targetPosition.x, targetPosition.y, transform.position.z))
            {
                MovePosition = Vector2.zero;
            }
        }
    }

    public void TeleportToPosition()
    {
        if (TeleportPosition != Vector2.zero)
        {
            transform.position = new Vector3(TeleportPosition.x, TeleportPosition.y, transform.position.z);
        }
    }
}
