using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    [SerializeField]
    private float speed = 2f; // Cloud's movement speed to the right
    
    void Update()
    {
        // Move the cloud to the right each frame
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}