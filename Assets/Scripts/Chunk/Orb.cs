using UnityEngine;


public class Orb : MonoBehaviour
{
    public string _tag;
    public float lifeToAdd;

    [SerializeField]ParticleSystem particle;
    [SerializeField]Collider2D coll;
    [SerializeField]SpriteRenderer spr;
    
    private void Awake()
    {
        gameObject.tag = _tag;
    }
    public void Spawn()
    {
        coll.enabled = true;
        spr.enabled = true;
    }
    public void Collect()
    {
        particle.Play();
        
        coll.enabled = false;
        spr.enabled = false;
    }
}
