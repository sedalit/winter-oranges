using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Mover playerMover;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (InteractWithMovement()) return;
    }

    private bool InteractWithMovement()
    {
        if (MoveWithKeyboard()) return true;
        if (MoveWithMouse()) return true;
        return false;
    }

    private bool MoveWithKeyboard()
    {
        var inputX = Input.GetAxis("Horizontal");
        if (inputX != 0)
        {
            playerMover.DirectionControl = new Vector2(Mathf.Clamp(inputX, -1f, 1f), playerMover.transform.position.y);
            return true;
        }
        return false;
    }

    private bool MoveWithMouse()
    {
        var mousePos = Input.mousePosition;
        var target = mainCamera.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButton(0) && InteractWithUI() == false)
        {
            playerMover.MovePosition = new Vector2(target.x, playerMover.transform.position.y);
            playerMover.NormalizedDirectionX = target.normalized.x;
            return true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            playerMover.DirectionControl = Vector2.zero;
        }

        return false;
    }

    private bool InteractWithUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
