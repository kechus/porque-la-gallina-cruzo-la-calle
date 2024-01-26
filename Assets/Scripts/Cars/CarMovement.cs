using UnityEngine;

public class CarMovement : MonoBehaviour
{
    readonly float SPEED = 17f;

    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0,-1,0) * SPEED * Time.deltaTime);
    }
}
