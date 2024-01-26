using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    readonly float SPEED = 17f;

    void Start()
    {
        
    }

    void fixedUpdate()
    {
        transform.position += transform.forward * SPEED * Time.deltaTime;
    }

    void Update()
    {
        
    }
}
