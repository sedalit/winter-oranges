using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    public event UnityAction<float, float> DirectionChanged;

    public Vector2 DirectionControl { get; set; }
    public ActionTeleport ActiveTeleport { get; set; }
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

    public float LastDirectionX { get; private set; }

    [Range(1f, 10f)]
    [SerializeField] private float movementSpeed;

    private float normalizedDirectionX = 0f;
    private bool isStopped = false;

    private void Update()
    {
        if (isStopped) return;

        var targetPositionX = transform.position.x + DirectionControl.x;
        var targetPositionY = transform.position.y;
        var targetVector = new Vector3(targetPositionX, targetPositionY, transform.position.z);

        if (DirectionControl.x != 0)
        {
            LastDirectionX = DirectionControl.x;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetVector, movementSpeed * Time.deltaTime);
    }

    public void TeleportToPosition(Transform target)
    {
        transform.position = target.position;
    }

    public void SetStopped(bool stopped)
    {
        isStopped = stopped;
    }
}
