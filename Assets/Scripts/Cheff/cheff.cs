using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cheff : MonoBehaviour
{
    private GameObject player;
    private int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Gallina>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) {
            player = FindObjectOfType<Gallina>().gameObject;
        }

        if(player != null && !player.GetComponent<Gallina>().getDie())
        {
            var movementVector = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
            gameObject.transform.position = movementVector;
        }   
    }
}
