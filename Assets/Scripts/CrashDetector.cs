using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if(collision.gameObject.layer == layerIndex)
        {
            crashEffect.Play();
            Invoke("RestartGame", delay);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
