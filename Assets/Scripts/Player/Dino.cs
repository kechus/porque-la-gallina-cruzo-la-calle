using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D RB;
    Animator animator;
    private const float MOVE_VELOCITY = 1.5f;
    bool die = false;

    private float ShakeTimer = 0f;
    [SerializeField]
    AudioClip StompSound;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.CurrentGameState != GameController.GameState.Game)
        {
            animator.SetBool("Move", false);
            return;
        }

        //Obtener input de usuario
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Movimiento basico
        if (!die)
        {
            movement.Normalize();
            RB.MovePosition(RB.position + (Time.fixedDeltaTime * MOVE_VELOCITY * movement));

            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetBool("Move", true);
                ShakeInIntervals();
            }
            else
            {
                animator.SetBool("Move", false);
            }

            if (movement.x != 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, movement.x < 0 ? 180f : 0f, 0f);
            }

        }
    }

    void ShakeInIntervals()
    {
        //Shake
        if (ShakeTimer <= 1f)
        {
            ShakeTimer += Time.deltaTime;
        }
        else
        {
            ShakeTimer = 0;
            FindObjectOfType<Shake>().shakeDuration = 0.3f;
            GetComponent<AudioSource>().PlayOneShot(StompSound);
        }
    }
}
