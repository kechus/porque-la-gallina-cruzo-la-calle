using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cheff : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed = 4;
    private Animator animator;
    private Vector2 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Gallina>().gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) {
            player = FindObjectOfType<Gallina>().gameObject;
        }

        if(player != null && !player.GetComponent<Gallina>().getDie())
        {
            oldPos = this.transform.position;
            var movementVector = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
            gameObject.transform.position = movementVector;
            
            if(oldPos.x < movementVector.x)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            

            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }
}
