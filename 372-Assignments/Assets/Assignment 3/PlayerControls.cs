using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask groundLayers;

    private CharacterController controller;

    private Vector3 movement = new();
    private Vector2 mouseDelta = new();

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float xRotation;
    Vector3 fallVelocity;
    bool isGrounded;

    private void Update()
    {

        controller.Move((movement.x * transform.right + movement.z * transform.forward) * movementSpeed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(transform.position - Vector3.up, 0.01f, groundLayers);

        if (controller.isGrounded && fallVelocity.y < 0)
        {
            fallVelocity.y = -2f;
        }

        fallVelocity.y += Physics.gravity.y * Time.deltaTime;

        controller.Move(fallVelocity * Time.deltaTime);

        xRotation -= mouseDelta.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(mouseDelta.x * mouseSensitivity * Time.deltaTime * Vector3.up);
        
    }

    public void SetMovementDirection(Vector2 movement)
    {
        this.movement = new(movement.x, this.movement.y, movement.y);
        this.movement.Normalize();
    }

    public void SetMouseDelta(Vector2 mouseDelta)
    {
        this.mouseDelta = mouseDelta;
    }
}
