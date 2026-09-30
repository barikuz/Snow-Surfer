using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    InputAction inputActions;
    Rigidbody2D rigidbody2D;
    SurfaceEffector2D surfaceEffector2D;

    Vector2 moveVector;

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 13f;
    [SerializeField] float boostSpeed = 20f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = InputSystem.actions.FindAction("Move");
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = inputActions.ReadValue<Vector2>();
        
        RotatePlayer();
        BoostPlayer();
       
    }

    void RotatePlayer()
    {
        if(moveVector.x < 0)
        {
            rigidbody2D.AddTorque(torqueAmount);
        }

        else if(moveVector.x > 0)
        {
            rigidbody2D.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
