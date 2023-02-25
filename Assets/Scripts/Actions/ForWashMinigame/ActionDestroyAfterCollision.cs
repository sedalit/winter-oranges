using UnityEngine;

[CreateAssetMenu(fileName = "New Destroy After Collision", menuName = "Destroy After Collision")]
public class ActionDestroyAfterCollision : BaseAction
{
    [SerializeField] private float timeToDestroy;
    private float timer = 0f;

    public override void Interact(Transform attachedObject)
    {
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            //attachedObject.GetComponent<InteractableObject>().PrintSome(timer);
            attachedObject.transform.localScale = Vector3.MoveTowards(attachedObject.transform.localScale, Vector3.zero, Time.deltaTime);
            if (timer > timeToDestroy)
            {
                timer = 0f;
            }
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
