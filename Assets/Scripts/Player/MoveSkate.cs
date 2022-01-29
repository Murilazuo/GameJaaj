using UnityEngine;

public class MoveSkate : MonoBehaviour
{
    Rigidbody2D rig;
    Animator anim;
    [SerializeField] internal float accereration, deaccereration, brake,rotationForce, maxSpeed;
    internal float speed;
    bool jump;
    public bool inAntibiotic;
    SoundManager soundManager;
    [SerializeField] ParticleSystem breakParticle;
    PlayerManager playerManager;

    void Start()
    {
        soundManager = SoundManager.soundManager;
        
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerManager = PlayerManager.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jump && Time.timeScale > 0)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        try
        {
            float rotationSpeedMod = 0;

            if (speed > maxSpeed / 5)
            {
                rotationSpeedMod = ((((speed / maxSpeed) - 1f) * -1f) * 0.8f) + 0.2f;
            }
            else
            {
                rotationSpeedMod = ((((-speed / maxSpeed) - 1f) * -1f) * 0.8f) - 0.2f;
            }

            if (speed > -0.5 && speed < 0.5)
            {
                rotationSpeedMod = 0;

                if (soundManager.GetSound("WalkAntibiotic").isPlaying)
                {
                    soundManager.StopSound("WalkAntibiotic");
                }
            }
            else
            {
                if (inAntibiotic && !soundManager.GetSound("WalkAntibiotic").isPlaying)
                {
                    soundManager.PlaySound("WalkAntibiotic");
                }
            }

            if (speed < 0)
            {
                rotationSpeedMod *= -1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 0, -rotationForce * rotationSpeedMod));
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 0, rotationForce * rotationSpeedMod));
            }


            if (Input.GetKey(KeyCode.W))
            {
                speed += accereration;

            }

            if (speed > 0 && (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.LeftShift))))
            {
                speed -= brake;
                if (breakParticle.isStopped)
                {
                    breakParticle.Play();
                }

                //Debug.Log("braking:" + rotationForce);
                if (speed < 0)
                {
                    speed -= brake * 6;
                }
            }
            else if (breakParticle.isPlaying)
            {
                breakParticle.Stop();
            }

            /*else if (speed > 0.3f)
            {
                speed -= deaccereration;
            }else if (speed < -0.3f)
            {
                speed += deaccereration;
            }
            else
            {
                speed = 0;   
            }*/


            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            else if (speed < -(maxSpeed / 2))
            {
                speed = -(maxSpeed / 2);
            }

            if(!jump)
            {
                if(speed > 0)
                {
                    anim.speed = speed / maxSpeed;
                }
                else
                {
                    anim.speed = -speed / maxSpeed;
                }
            }

            rig.velocity = transform.up * speed;
        }
        catch
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }

    }

    void Jump()
    {
        jump = true;
        anim.speed = 1;
        anim.SetTrigger("Jump");
    }
    void EndJump()
    {
        jump = false;
        int levelId = 1;
        switch (playerManager.level)
        {
            case 3:
            case 4:
                levelId = 2;
                break;
            case 5:
            case 6:
                levelId = 2;
                break;
            case 7:
            case 8:
                levelId = 2;
                break;
            case 9:
            case 10:
                levelId = 2;
                break;
        }
        anim.SetInteger("Level", levelId);
    }
}
