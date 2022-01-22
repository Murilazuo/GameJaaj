using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = target.position;
    }
}
