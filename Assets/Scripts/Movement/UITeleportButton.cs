using System.Collections;
using UnityEngine;

public class UITeleportButton : MonoBehaviour
{
    [SerializeField] private Mover targetMover;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private float fadeInTime = 1.5f;

    public void StartTeleport()
    {
        StartCoroutine(TeleportMoverAfterFade());
    }

    private IEnumerator TeleportMoverAfterFade()
    {
        var fader = FindObjectOfType<Fader>();
        yield return fader.FadeOut(fadeOutTime);
        targetMover.TeleportToPosition();
        yield return fader.FadeIn(fadeInTime);
    }

}
