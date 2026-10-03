using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PowerUpSO powerUp; // Array of power-up prefabs

    PlayerController playerController;
    SpriteRenderer spriteRenderer;
    
    float timeLeft;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerUp.GetTime();
    }

    void Update()
    {
        CountDownTimer();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        
        if(collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false; // Disable the sprite renderer to hide the power-up
            playerController.ActivatePowerUp(powerUp);
        }
    }

    void CountDownTimer()
    {
        if(spriteRenderer.enabled == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    playerController.DeactivatePowerUp(powerUp);
                }
            }
        }
    }
}
