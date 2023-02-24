using UnityEngine;

public class CharacterFacingController : MonoBehaviour
{
    [SerializeField] private Mover mover;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Update()
    {
        spriteRenderer.flipX = mover.LastDirectionX < 0;
    }
}
