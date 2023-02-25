using UnityEngine;

[CreateAssetMenu(fileName = "New Destroy After Collision", menuName = "Destroy After Collision")]
public class ActionDestroyAfterCollision : BaseAction
{
    [Range(0f, 1f)]
    [SerializeField] private float scaleDecreaseTime = 0.5f;

    public override void Interact(Transform attachedObject)
    {
        if (Input.GetMouseButton(0))
        {
            attachedObject.transform.localScale = Vector3.MoveTowards(attachedObject.transform.localScale, Vector3.zero, Time.deltaTime * scaleDecreaseTime);
        }
    }

    public override bool IsInteractCompleted(Transform attachedObject)
    {
        var isEnded = attachedObject.localScale.z <= 0.05f;
        if (isEnded)
        {
            attachedObject.gameObject.SetActive(false);
        }
        return isEnded;
    }
}
