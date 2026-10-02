using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PowerUpSO powerUp; // Array of power-up prefabs

    PlayerController playerController;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
}
