using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KFC_Attack : MonoBehaviour
{
    [SerializeField] GameObject lines;
    [SerializeField] GameObject cheffs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Gallina>().getDie())
        {
            lines.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && FindObjectOfType<cheff>() == null)
        {
            lines.SetActive(false);
            Instantiate(cheffs, new Vector2(12.8f, 3.22f), this.transform.rotation);
        }
    }
}
