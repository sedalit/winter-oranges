using UnityEngine;

public class InteractableObject : MonoBehaviour, IRaycastable
{
    [SerializeField] private InteractionEffect interactionEffect;
    [SerializeField] private ParticleSystem particleSystemPrefab;

    private ParticleSystem activeParticleSystem;
    private Vector3 particlesPosition;

    public bool HandleRaycast(MonoBehaviour callingController)
    {
        interactionEffect.Act(transform);
        if (particleSystemPrefab)
        {
            if (activeParticleSystem == null) activeParticleSystem = Instantiate(particleSystemPrefab);
            if (callingController.TryGetComponent(out PlayerInputController playerInputController))
            {
                particlesPosition = playerInputController.GetWorldMousePosition();
            }
            activeParticleSystem.transform.position = new Vector3(particlesPosition.x, particlesPosition.y, 0);
            activeParticleSystem.Play();
        }
        return true;
    }

    public bool IsCompleted()
    {
        var isCompleted = interactionEffect.IsCompleted(transform);
        if (isCompleted)
        {
            if (activeParticleSystem != null)
            {
                Destroy(activeParticleSystem.gameObject);
            }
        }
        return isCompleted;
    }
}
