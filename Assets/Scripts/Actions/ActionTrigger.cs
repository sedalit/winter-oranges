using UnityEngine;
using UnityEngine.Events;

public class ActionTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerEvent;
    public UnityEvent OnTriggerExitEvent;

    [SerializeField] private bool canInteractMoreOneTime = true;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            OnTriggerEvent?.Invoke();
            if (!canInteractMoreOneTime)
            {
                DeactivateTrigger();
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerExitEvent?.Invoke();
    }

    private void DeactivateTrigger()
    {
        OnTriggerExitEvent?.Invoke();
        gameObject.SetActive(false);
    }
}
