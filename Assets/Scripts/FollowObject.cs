using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]string tagToFollow;
    Transform target;
    private void OnEnable()
    {
        target = GameObject.FindWithTag(tagToFollow).transform;
    }

    void Update()
    {
        if(target != null)
        transform.position = new Vector3(target.position.x,target.position.y, transform.position.z);
    }
}
