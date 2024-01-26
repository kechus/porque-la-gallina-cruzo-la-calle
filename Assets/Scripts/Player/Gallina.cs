using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D RB;
    private const float MOVE_VELOCITY = 15f;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Obtener input de usuario
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Movimiento basico
        movement.Normalize();
        RB.MovePosition(RB.position + (Time.fixedDeltaTime * MOVE_VELOCITY * movement));
    }
}
