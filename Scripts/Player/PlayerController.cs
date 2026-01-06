 using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float zClamp = 3f;
    Vector2 Movement;
    Rigidbody rb;

     void Awake()
    {
      rb = GetComponent<Rigidbody>();  
    }

     void FixedUpdate()
    {
        HandleMovement();        
    }
    public void Move(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>(); 
    }

    void HandleMovement()
    {
        Vector3 currentpos = rb.position;
        Vector3 moveDirection = new Vector3(Movement.x, 0f, Movement.y);
        Vector3 newPosition = currentpos + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp , xClamp);
        newPosition.x = Mathf.Clamp(newPosition.x, -zClamp, zClamp);

        rb.MovePosition(newPosition);
    }
}
