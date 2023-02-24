using UnityEngine;

public class ActionTeleport : ActionTrigger
{
    [SerializeField] private Transform teleportPoint;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent(out Mover mover))
        {
            mover.TeleportPosition = teleportPoint.position;
        }
        base.OnTriggerEnter2D(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent(out Mover mover))
        {
            mover.TeleportPosition = teleportPoint.position;
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if (collision.transform.root.TryGetComponent(out Mover mover))
        {
            mover.TeleportPosition = Vector2.zero;
        }
    }
}
