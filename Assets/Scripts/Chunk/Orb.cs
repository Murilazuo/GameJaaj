using UnityEngine;

public class Orb : MonoBehaviour
{
    public string _tag;
    public float lifeToAdd;
    private void Start()
    {
        gameObject.tag = _tag;
    }
}
