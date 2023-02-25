using System.Collections;
using UnityEngine;

public class ActionTeleport : ActionTrigger, IRaycastable
{
    [SerializeField] private Transform teleportPoint;
    [SerializeField] private AudioClip newLocationAudio;

    private Mover lastEnteredMover;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent(out Mover mover))
        {
            lastEnteredMover = mover;
            mover.ActiveTeleport = this;
        }
        base.OnTriggerEnter2D(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent(out Mover mover))
        {
            lastEnteredMover = mover;
            mover.ActiveTeleport = this;
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if (collision.transform.root.TryGetComponent(out Mover mover))
        {
            mover.ActiveTeleport = null;
        }
    }

    public bool HandleRaycast(MonoBehaviour callingController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mover = callingController.GetComponent<PlayerInputController>().PlayerMover;
            StartCoroutine(StartTeleport(mover));
            return true;
        }
        return false;
    }

    public IEnumerator StartTeleport(Mover targetMover)
    {
        var fader = FindObjectOfType<Fader>();
        var audioManager = FindObjectOfType<AudioManager>();

        if (!targetMover) targetMover = FindObjectOfType<PlayerInputController>().PlayerMover;
        targetMover.SetStopped(true);

        audioManager.SetAuidoClip(newLocationAudio);
        yield return fader.FadeOut(1f);

        if (!targetMover) targetMover = FindObjectOfType<PlayerInputController>().PlayerMover;

        targetMover.TeleportToPosition(teleportPoint);
        targetMover.SetStopped(false);

        yield return fader.FadeIn(1.5f);
    }
}
