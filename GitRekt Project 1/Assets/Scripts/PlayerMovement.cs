using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveInput;

    private InputAction movementAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //Freeze Y position to keep the player on a flat plane.
        //REMOVE IF jumping will be desired in the future
       rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        // setup the input action with a 2D composite binding for the arrow keys
        movementAction = new InputAction("Movement", InputActionType.Value);
        movementAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");
    }

    private void OnEnable()
    {
        movementAction.Enable();
    }

    private void OnDisable()
    {
        movementAction.Disable();
    }

    private void FixedUpdate()
    {
        //Read the input as a Vector2
        Vector2 input = movementAction.ReadValue<Vector2>();

        // Map input x to movement.x an input y to movement.z. Leaves Y unchanged
        Vector3 movement = new Vector3(input.x, 0f, input.y) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}