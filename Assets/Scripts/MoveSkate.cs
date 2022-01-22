using UnityEngine;

public class MoveSkate : MonoBehaviour
{
    Rigidbody2D rig;
    Animator anim;
    [SerializeField] float accereration, deaccereration, rotationForce, maxSpeed;
    float speed;
    float rotation;
    bool jump;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.localRotation.z;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float rotationSpeedMod = (((speed / maxSpeed) -1f) * -1f) + 0.2f;
        
        

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,0,-rotationForce * rotationSpeedMod));
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0,rotationForce * rotationSpeedMod));
        }



        if (Input.GetKey(KeyCode.W))
        {
            speed += accereration;
        }else if (speed > 0)
        {
            speed -= deaccereration;
        }

        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        rig.velocity = transform.up * speed;
    }

    void Jump()
    {
        jump = true;
        anim.SetTrigger("Jump");
    }
    void EndJump()
    {
        jump = false;
    }
}
