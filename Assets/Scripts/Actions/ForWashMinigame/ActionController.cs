using UnityEngine;
using UnityEngine.Events;

public class ActionController : MonoBehaviour
{
    public event UnityAction<bool> OnActionEnd;

    public UnityEvent OnActionStartEvent;
    public UnityEvent<bool> OnActionEndEvent;

    [SerializeField] private InteractableObject[] interactableObjects;

    private bool isActionStarted = false;

    private void Update()
    {
        if (!isActionStarted) return;
        foreach (var interactable in interactableObjects)
        {
            if (interactable.IsCompleted() == false)
            {
                return;
            }
        }
        EndAction(true);
    }

    public void StartAction()
    {
        OnActionStartEvent?.Invoke();
        isActionStarted = true;
        print("Action Started");
    }

    public void EndAction(bool success)
    {
        OnActionEnd?.Invoke(success);
        OnActionEndEvent?.Invoke(success);
        isActionStarted = false;
        print("Action Ended");
    }
}
