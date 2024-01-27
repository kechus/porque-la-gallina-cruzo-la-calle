using UnityEngine;

public class DestructableCar : MonoBehaviour
{
    public int Direction = 0;
    public int Speed = 0;

    void Start(){
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0,Direction,0) * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
