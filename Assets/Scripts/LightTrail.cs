using UnityEngine;

public class LightTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem lightTrailEffect;

    int layerIndex;

    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Floor");
    }

    private void OnCollisionEnter2D(Collision2D collison) 
    {
        if(collison.gameObject.layer == layerIndex)
        {
            lightTrailEffect.Play();
        }
        
    }
    
    private void OnCollisionExit2D(Collision2D collison) 
    {
        if(collison.gameObject.layer == layerIndex)
        {
            lightTrailEffect.Stop();
        }
    }
}
