using UnityEngine;

public class DestructableCar : MonoBehaviour
{
    public int Direction = 0;
    public int Speed = 0;
    [SerializeField]
    public AudioClip[] CrashSounds;

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
            Speed = 0;
            GetComponent<SpriteRenderer>().sortingOrder = 2;
            GetComponent<AudioSource>().PlayOneShot(CrashSounds[Random.Range(0, CrashSounds.Length)]);
            GetComponent<Animator>().enabled = true;
        }
    }

    void DestroyCar()
    {
        Destroy(gameObject);
    }
}

