using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    InputAction inputActions;
    Rigidbody2D rigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    ScoreManager scoreManager;

    Vector2 moveVector;

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 13f;
    [SerializeField] float boostSpeed = 20f;

    public bool canControl = true;

    float currentRotation;
    float previousRotation;
    float totalRotation;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = InputSystem.actions.FindAction("Move");
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = inputActions.ReadValue<Vector2>();
        if (canControl)
        {
            RotatePlayer();
            CalculateFlips();
            BoostPlayer();
        }      
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

    public void DisableControls()
    {
        canControl = false;
    }

    void CalculateFlips()
    {
        currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if(totalRotation > 340 || totalRotation < -340)
        {
            totalRotation = 0;
            scoreManager.AddScore(10);
        }

        previousRotation = currentRotation;

    }
}
