using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : MonoBehaviour
{
    //-7.5 , 0
    Vector2 movement;
    Rigidbody2D RB;
    Animator animator;
    private const float MOVE_VELOCITY = 5f;
    bool die = false;

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
        if(!die) {
            movement.Normalize();
            RB.MovePosition(RB.position + (Time.fixedDeltaTime * MOVE_VELOCITY * movement));

            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetBool("Move", true);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Carro")
        {
            animator.SetTrigger("Die");
            die = true;
            GetComponent<AudioSource>().Play(0);

            if (collision.gameObject.name == "Camionsote(Clone)")
            {
                Invoke(nameof(punchline), 1f);
            }
            else
            {
                Invoke(nameof(respawn), 1f);
            } 
        }
    }

    private void punchline()
    {
        
    }

    private void respawn()
    {
        Destroy(gameObject);
        FindObjectOfType<PlayerSpawn>().createPlayer();
        die = false;
    }
}
