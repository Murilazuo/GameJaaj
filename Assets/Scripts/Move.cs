using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rig;
    [SerializeField] private float acceleration = 0.3f;
    [SerializeField] private float deacceleration = 0.1f;


    float speedX, speedY;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W)){
            speedY += acceleration;
        }else if (Input.GetKey(KeyCode.S))
        {
            speedY -= acceleration;
        }
        else if(speedY > 0)
        {
            speedY -= deacceleration;
        }else if(speedY < 0)
        {
            speedY += deacceleration;
        }

        if (Input.GetKey(KeyCode.D))
        {
            speedX += acceleration;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speedX -= acceleration;
        }
        else if (speedX > 0)
        {
            speedX -= deacceleration;
        }
        else if (speedX < 0)
        {
            speedX += deacceleration;
        }

        rig.velocity = new Vector2(speedX,speedY);
    }
}
