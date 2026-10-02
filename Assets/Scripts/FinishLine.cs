using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        
        if(collision.gameObject.layer == layerIndex)
        {
            finishEffect.Play();
            Invoke("RestartGame", delay);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
