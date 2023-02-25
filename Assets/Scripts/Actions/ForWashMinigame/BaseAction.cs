using UnityEngine;

public abstract class BaseAction : ScriptableObject
{
    public abstract void Interact(Transform attachedObject);
    public abstract bool IsInteractCompleted(Transform attachedObject);
}
