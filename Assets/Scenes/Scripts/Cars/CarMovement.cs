using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    readonly float SPEED = 17f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * SPEED;
    }

    void Update()
    {
        
    }
}
