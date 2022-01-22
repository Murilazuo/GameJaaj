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
        transform.position = new Vector3(target.position.x,target.position.y, transform.position.z);
    }
}
