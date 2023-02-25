using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Mover playerMover;

    private Camera mainCamera;
    private bool movementEnabled = true;

    public Mover PlayerMover => playerMover;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (InteractWithUI()) return;
        if (InteractWithComponent()) return;
        if (InteractWithMovement()) return;
    }

    public void SetMovementEnabled(bool enabled)
    {
        movementEnabled = enabled;
    }

    public Vector3 GetWorldMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private bool InteractWithMovement()
    {
        if (movementEnabled == false) return false;
        if (MoveWithKeyboard()) return true;
        //if (MoveWithMouse()) return true;
        return false;
    }

    private bool MoveWithKeyboard()
    {
        if (InteractWithUI()) return false;

        var inputX = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            inputX = -1;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            inputX = 1;
        }
        playerMover.DirectionControl = new Vector2(inputX, playerMover.transform.position.y);
        
        if (inputX != 0)
        {
            playerMover.NormalizedDirectionX = inputX;
            return true;
        }
        return false;
    }

    private bool MoveWithMouse()
    {
        var target = GetWorldMousePosition();
        if (Input.GetMouseButton(0) && InteractWithUI() == false)
        {
            //playerMover.MovePosition = new Vector2(target.x, playerMover.transform.position.y);
            playerMover.NormalizedDirectionX = target.normalized.x;
            return true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            playerMover.DirectionControl = Vector2.zero;
        }

        return false;
    }

    private bool InteractWithComponent()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(GetWorldMousePosition(), Vector2.down, 1f);
        foreach (var hit in hits)
        {
            IRaycastable[] raycastables = hit.transform.GetComponents<IRaycastable>();
            foreach (var raycastable in raycastables)
            {
                if (raycastable.HandleRaycast(this))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool InteractWithUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
