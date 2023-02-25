using UnityEngine;

public class CharacterFacingController : MonoBehaviour
{
    [SerializeField] private Mover mover;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        mover.DirectionChanged += OnDirectionChanged;
    }

    private void OnDisable()
    {
        mover.DirectionChanged -= OnDirectionChanged;
    }

    private void OnDirectionChanged(float lastDirection, float currentDirection)
    {
        spriteRenderer.flipX = currentDirection < lastDirection;
    }
}
