using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camionsoteSpawner : MonoBehaviour
{
    [SerializeField] GameObject camionsote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(camionsote, new Vector2(this.transform.position.x, this.transform.position.y + 10f), this.transform.rotation);
        }
    }
}
