using UnityEngine;

public class LifeOrb : MonoBehaviour
{
    public float lifeToAdd;
    private void Start()
    {
        gameObject.tag = "LifeOrb";
    }
}
