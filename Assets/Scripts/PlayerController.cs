using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction inputActions;
    Rigidbody2D rigidbody2D;

    [SerializeField] float torqueAmount = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = InputSystem.actions.FindAction("Move");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = inputActions.ReadValue<Vector2>();

        if(moveVector.x < 0)
        {
            rigidbody2D.AddTorque(torqueAmount);
        }

        else if(moveVector.x > 0)
        {
            rigidbody2D.AddTorque(-torqueAmount);
        }
    }
}
