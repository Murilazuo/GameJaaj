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
        float rotationSpeedMod = 0;

        if(speed > maxSpeed / 2)
        {
            rotationSpeedMod = (((speed / maxSpeed) - 1f) * -1f) + 0.2f;
        } 
        else if (speed > 0)
        {
            rotationSpeedMod = ((speed / maxSpeed));
        }else if (speed < 0)
        {
            rotationSpeedMod = ((speed / -maxSpeed));
        }
        else
        {
            rotationSpeedMod = (((speed / -maxSpeed) - 1f) * -1f) + 0.2f;
        }

        rotationSpeedMod = Mathf.Clamp01(rotationSpeedMod);

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
        }else if (Input.GetKey(KeyCode.S))
        {
            speed -= accereration;
        }else if (speed > 0.3f)
        {
            speed -= deaccereration;
        }else if (speed < -0.3f)
        {
            speed += deaccereration;
        }
        else
        {
            speed = 0;   
        }


        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }else if (speed < -(maxSpeed / 2))
        {
            speed = -(maxSpeed / 2);
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
