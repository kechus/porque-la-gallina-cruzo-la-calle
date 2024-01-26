using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public int Direction = 0;
    public int Speed = 0;

    void Start(){
        if(Random.Range(0, 100) == 0)
        {
            GetComponent<AudioSource>().Play(0);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0,Direction,0) * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CarDestroyer"))
        {
            Destroy(gameObject);
        }
    }
}
