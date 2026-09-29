using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison) 
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if(collison.gameObject.layer == layerIndex)
        {
            SceneManager.LoadScene(0);
        }
    }
}
