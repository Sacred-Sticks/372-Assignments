using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [System.Serializable] public struct Names
    {
        public string map;
        public string movement;
        public string mouse;
    }

    private struct Actions
    {
        public InputAction movement;
        public InputAction mouse;
    }

    [SerializeField] private InputActionAsset inputAsset;
    [SerializeField] private Names names;
    [SerializeField] private UnityEvent<Vector2> movementEvent;
    [SerializeField] private UnityEvent<Vector2> mouseEvent;

    private Actions actions;

    private Vector2 movement;
    private Vector2 mouse;

    private void Awake()
    {
        var map = inputAsset.FindActionMap(names.map);

        actions.movement = map.FindAction(names.movement);
        actions.mouse = map.FindAction(names.mouse);

        actions.movement.performed += OnMovementChange;
        actions.movement.canceled += OnMovementChange;
        actions.movement.Enable();

        actions.mouse.performed += OnMouseChange;
        actions.mouse.canceled += OnMouseChange;
        actions.mouse.Enable();
    }

    private void OnMovementChange(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        movementEvent.Invoke(movement);
    }

    private void OnMouseChange(InputAction.CallbackContext context)
    {
        mouse = context.ReadValue<Vector2>();
        mouseEvent.Invoke(mouse);
    }
}
