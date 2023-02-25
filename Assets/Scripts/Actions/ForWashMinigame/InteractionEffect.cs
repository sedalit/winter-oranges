using UnityEngine;

[CreateAssetMenu(fileName = "New Interaction", menuName = "Interactions")]
public class InteractionEffect : ScriptableObject
{
    [SerializeField] private BaseAction action;

    public void Act(Transform attachedObject)
    {
        action.Interact(attachedObject);
    }

    public bool IsCompleted(Transform attachedObject)
    {
        return action.IsInteractCompleted(attachedObject);
    }
}
