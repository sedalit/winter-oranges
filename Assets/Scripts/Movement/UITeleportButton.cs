using System.Collections;
using UnityEngine;

public class UITeleportButton : MonoBehaviour
{
    [SerializeField] private Mover targetMover;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private float fadeInTime = 1.5f;

    private ActionTeleport activeTeleport;

    public void StartTeleport()
    {
        StartCoroutine(targetMover.ActiveTeleport.StartTeleport(targetMover));
    }
}
